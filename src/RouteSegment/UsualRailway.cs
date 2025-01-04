using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;

public class UsualRailway : Railway
{
    public UsualRailway(double length) : base(length) { }

    public override SuccessInfo SuccessWay(ITrain train, double accuracy)
    {
        var result = new SuccessInfo { };

        ResetTrainAcceleration(train);

        result = train.CalculateTime(Length, accuracy);

        if (!IsPostiveSuccessTime(result.TimeSuccess))
        {
            return FailedSimulation(result);
        }

        return SuccessSimulation(result);
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

    private void ResetTrainAcceleration(ITrain train)
    {
        train.SetAcceleration(0);
    }
}