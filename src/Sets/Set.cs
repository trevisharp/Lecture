using System;
using System.Text;
using System.Collections.Generic;

namespace Lecture.Sets;

using Numerics;

public abstract class Set
{
    public abstract bool Contains(Set set);
    public abstract IEnumerable<Set> Collection { get; }

    public virtual bool IsSubset(Set set)
    {
        foreach (var el in Collection)
        {
            if (set.Contains(el))
                continue;
            
            return false;
        }
        return true;
    }

    public virtual Set Union(Set set)
    {
        var union = new UnionSet
        {
            SetA = this,
            SetB = set
        };
        return union;
    }

    public virtual Set Intersect(Set set)
    {
        var union = new IntersectSet
        {
            SetA = this,
            SetB = set
        };
        return union;
    }

    public virtual Set Subtract(Set set)
    {
        var sub = new SubtractionSet
        {
            SetA = this,
            SetB = set
        };
        return sub;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append("{");
        foreach (var el in Collection)
        {
            sb.Append(el);
            sb.Append(", ");
        }
        if (sb.Length > 2)
            sb.Remove(sb.Length - 2, 2);
        sb.Append("}");
        
        return sb.ToString();
    }

    public static Set operator |(Set a, Set b)
        => a.Union(b);
        
    public static Set operator &(Set a, Set b)
        => a.Intersect(b);

    public static implicit operator Set(ulong n)
        => new Natural(n);

    public static Set operator +(Set a, Set b)
    {
        if (a is Number n && b is Number m)
            return n.Add(m);
        
        return a.Union(b);
    }

    public static Set operator -(Set a, Set b)
    {
        if (a is Number n && b is Number m)
            return n.Sub(m);
        
        return a.Subtract(b);
    }

    public static Set operator *(Set a, Set b)
    {
        if (a is Number n && b is Number m)
            return n.Sub(m);
        
        throw new InvalidOperationException(
            $"""
            {a} and {b} don't be a number to operate with * operator.
            To cartesian product consider using Subtract method.
            """
        );
    }

    public static bool operator ==(Set a, Set b)
    {
        if (a is Number n && b is Number m)
            return n.Equals(m);
        
        return a.IsSubset(b) && b.IsSubset(a);
    }
    
    public static bool operator !=(Set a, Set b)
        => !(a == b);

    private static Set empty = new EmptySet();
    public static Set Empty => empty;

    public static Set FromElements(params Set[] sets)
        => new FiniteSet(sets);
}