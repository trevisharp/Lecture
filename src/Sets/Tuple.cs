using System.Collections.Generic;

namespace Lecture.Sets;

public class Tuple : Set
{
    public Set A { get; init; }
    public Set B { get; init; }

    public override IEnumerable<Set> Collection
    {
        get
        {
            yield return A;
            yield return B;
        }
    }

    public override bool Contains(Set set)
        => A == set || B == set;
}