using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;

public abstract class Railway
{
    public double Length { get; }

    protected Railway(double length)
    {
        Length = length;
    }

    public abstract SuccessInfo SuccessWay(ITrain train, double accuracy);
}
