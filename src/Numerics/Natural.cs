using System;
using System.Collections.Generic;

namespace Lecture.Numerics;

using Sets;

public class Natural : Number
{
    internal ulong value;
    internal Natural(ulong value)
        => this.value = value;

    public override IEnumerable<Set> Collection
    {
        get
        {
            for (ulong i = 0; i < value; i++)
                yield return new Natural(i);
        }
    }

    public override bool Contains(Set set)
    {
        if (set is Natural n)
            return n.value < this.value;
        
        return false;
    }

    public override bool IsSubset(Set set)
    {
        if (set is Natural m)
            return m.value >= this.value;
        
        return false;
    }

    public override Number Add(Number n)
    {
        if (n is Natural nat)
            return nat + this;
        
        return n.Add(this);
    }

    public override Number Sub(Number n)
    {
        if (n is Natural nat)
            return nat - this;
        
        return n.Sub(this);
    }

    public override Number Mul(Number n)
    {
        if (n is Natural nat)
            return nat * this;
        
        return n.Mul(this);
    }

    public override Number Div(Number n)
    {
        if (n is Natural nat)
            return nat / this;
        
        return n.Div(this);
    }

    public override Number Mod(Number n)
    {
        if (n is Natural nat)
            return nat % this;
        
        return n.Mod(this);
    }

    public override Number Positive() => +this;

    public override long Compare(Number n)
    {
        if (n is Natural nat)
            return (long)(this.value - nat.value);
        
        return n.Compare(this);
    }

    public override bool Equals(object obj)
    {
        if (obj is Natural n)
            return this.Compare(n) == 0;
        
        if (obj is Set s)
            return this.IsSubset(s) && s.IsSubset(this);

        return false;
    }

    public override int GetHashCode()
        => (int)value;

    public override string ToString()
        => this.value.ToString();

    public static implicit operator Natural(ulong value)
        => new Natural(value);
    
    public static implicit operator ulong(Natural nat)
        => nat.value;
    
    public static Natural operator +(Natural n)
        => n;
    
    public static Natural operator +(Natural n, Natural m)
        => new Natural(n.value + m.value);
    
    public static Natural operator -(Natural n, Natural m)
    {
        if (m.value > n.value)
            throw new InvalidOperationException(
                $"""
                The natural number {m.value} is bigger than {n.value}, so 
                {n.value} - {m.value} is negative. Consequently the result
                don't is a natural.
                """
            );
        return new Natural(n.value - m.value);
    }
        
    public static Natural operator *(Natural n, Natural m)
        => new Natural(n.value * m.value);
        
    public static Natural operator /(Natural n, Natural m)
    {
        if (n.value % m.value != 0)
            throw new InvalidOperationException(
                $"""
                The natural number {m.value} not divides {n.value}, so 
                {n.value} / {m.value} is rational. Consequently the result
                don't is a natural.
                """
            );

        return new Natural(n.value / m.value);
    }

    public static Natural operator %(Natural n, Natural m)
        => new Natural(n % m);
}