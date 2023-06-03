using System.Collections.Generic;

namespace Lecture.Sets;

public class EmptySet : Set
{
    public override bool Contains(Set set)
        => false;

    public override bool IsSubset(Set set)
        => true;

    public override IEnumerable<Set> Collection
    {
        get
        {
            yield break;
        }
    }

    public override string ToString() => "{}";
}