using Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Transport;

public interface ITrain
{
    double Mass { get; }

    double Speed { get; }

    double Acceleration { get; }

    double MaxPower { get; }

    SuccessInfo CalculateTime(double distance, double accuracy);

    bool ApplyPower(double power);

    void SetAcceleration(double power);
}
