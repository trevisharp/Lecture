using static System.Console;
using Lecture.Sets;

var s = Set.Empty;
var fs = Set.FromElements(s);
var A = Set.FromElements(fs);
var cond = A.IsSubset(s);

WriteLine(s);
WriteLine(fs);
WriteLine(A);