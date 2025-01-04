using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;

public class Station : Railway
{
    private readonly double _maxSpeedStation;

    private readonly double _timeStation;

    public Station(double maxSpeed, double time) : base(0)
    {
        _maxSpeedStation = maxSpeed;
        _timeStation = time;
    }

    public override SuccessInfo SuccessWay(ITrain train, double accuracy)
    {
        var result = new SuccessInfo { };

        if (!IsCorrectMaxSpeedStation(train))
        {
            return FailedSimulation(result);
        }

        result = CalculateTotalTime(train, accuracy);

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

    private bool IsCorrectMaxSpeedStation(ITrain train)
    {
        return train.Speed <= _maxSpeedStation;
    }

    private SuccessInfo CalculateTotalTime(ITrain train, double accuracy)
    {
        var result = new SuccessInfo { };
        result.TimeSuccess = _timeStation;
        result.TimeSuccess += train.CalculateTime(Length, accuracy).TimeSuccess;
        return result;
    }

    private bool IsPostiveSuccessTime(double time)
    {
        return time > 0;
    }
}