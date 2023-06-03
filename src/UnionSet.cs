using System.Collections.Generic;

namespace Lecture.Sets;

public record UnionSet : Set
{
    public Set SetA { get; init; }
    public Set SetB { get; init; }

    public override IEnumerable<Set> Collection
    {
        get
        {
            foreach (var el in SetA.Collection)
                yield return el;
            
            foreach (var el in SetB.Collection)
                yield return el;
        }
    }

    public override bool Contains(Set set)
        => SetA.Contains(set) || SetB.Contains(set);

    public override bool IsSubset(Set set)
        => SetA.IsSubset(set) && SetB.IsSubset(set);

    public override string ToString()
        => base.ToString();
}