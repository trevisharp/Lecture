using System.Collections.Generic;
using System.Text;

namespace Lecture.Sets;

public abstract record Set
{
    public abstract bool Contains(Set set);
    public abstract bool IsSubset(Set set);
    public abstract IEnumerable<Set> Collection { get; }

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

    private static Set empty = new EmptySet();
    public static Set Empty => empty;

    public static Set FromElements(params Set[] sets)
        => new FiniteSet(sets);
}