using System.Collections;
using System.Collections.Generic;

namespace Lecture.Sets;

public record FiniteSet : Set, IEnumerable<Set>
{
    private HashSet<Set> hash = new HashSet<Set>();

    public FiniteSet(params Set[] sets)
    {
        foreach (var set in sets)
            hash.Add(set);
    }
    
    public override bool Contains(Set set)
        => hash.Contains(set);

    public override IEnumerable<Set> Collection => hash;

    public override bool IsSubset(Set set)
    {
        if (set is FiniteSet fs)
            return hash.IsSubsetOf(fs);
        
        foreach (var el in hash)
        {
            if (set.Contains(el))
                continue;
            
            return false;
        }
        return true;
    }

    public IEnumerator<Set> GetEnumerator()
        => hash.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => hash.GetEnumerator();

    public override string ToString()
        => base.ToString();
}