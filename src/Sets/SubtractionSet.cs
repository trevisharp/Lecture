using System.Collections.Generic;

namespace Lecture.Sets;

public class SubtractionSet : Set
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
            
            this.elements = new HashSet<Set>(SetA.Collection);
            foreach (var el in SetB.Collection)
                this.elements.Remove(el);
            
            return this.elements;
        }
    }

    public override bool Contains(Set set)
        => SetA.Contains(set) && !SetB.Contains(set);
}