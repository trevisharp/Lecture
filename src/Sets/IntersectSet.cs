using System.Collections.Generic;

namespace Lecture.Sets;

public class IntersectSet : Set
{
    private HashSet<Set> elements = null;

    public Set SetA { get; init; }
    public Set SetB { get; init; }

    public override IEnumerable<Set> Collection
    {
        get
        {
            if (this.elements is not null)
                return this.elements;

            this.elements = new HashSet<Set>();
            foreach (var el in SetA.Collection)
                if (SetB.Contains(el))
                    this.elements.Add(el);
                
            return this.elements;
        }
    }

    public override bool Contains(Set set)
        => SetA.Contains(set) && SetB.Contains(set);

    public override string ToString()
        => base.ToString();
}