using System.Collections.Generic;

namespace Lecture.Sets;

public record IntersectSet : Set
{
    public Set SetA { get; init; }
    public Set SetB { get; init; }

    public override IEnumerable<Set> Collection
    {
        get
        {
            HashSet<Set> hash = new HashSet<Set>();
            foreach (var el in SetA.Collection)
                hash.Add(el);
            
            foreach (var el in SetB.Collection)
                if (hash.Contains(el))
                    yield return el;
        }
    }

    public override bool Contains(Set set)
        => SetA.Contains(set) && SetB.Contains(set);

    public override bool IsSubset(Set set)
    {
        foreach (var el in Collection)
        {
            if (set.Contains(el))
                continue;
            
            return false;
        }
        return true;
    }

    public override string ToString()
        => base.ToString();
}