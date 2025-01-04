using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;

public class PowerRailway : Railway
{
    public double Power { get; }

    public PowerRailway(double length, double power) : base(length)
    {
        Power = power;
    }

    public override SuccessInfo SuccessWay(ITrain train, double accuracy)
    {
        var successInfo = new SuccessInfo { };

        if (!train.ApplyPower(Power))
        {
            return FailedSimulation(successInfo);
        }

        successInfo = train.CalculateTime(Length, accuracy);

        if (!IsPostiveSuccessTime(successInfo.TimeSuccess))
        {
            return FailedSimulation(successInfo);
        }

        return SuccessSimulation(successInfo);
    }

    private SuccessInfo FailedSimulation(SuccessInfo successInfo)
    {
        successInfo.TimeSuccess = successInfo.TimeSuccess;
        successInfo.IsSuccess = false;

        return successInfo;
    }

    private SuccessInfo SuccessSimulation(SuccessInfo successInfo)
    {
        successInfo.TimeSuccess = successInfo.TimeSuccess;
        successInfo.IsSuccess = true;

        return successInfo;
    }

    private bool IsPostiveSuccessTime(double time)
    {
        return time > 0;
    }
}