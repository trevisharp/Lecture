namespace Lecture.Numerics;

using Sets;

public abstract class Number : Set
{
    public abstract Number Add(Number n);
    public abstract Number Sub(Number n);
    public abstract Number Mul(Number n);
    public abstract Number Div(Number n);
    public abstract Number Mod(Number n);
    public abstract Number Positive();
    public abstract long Compare(Number n);
}