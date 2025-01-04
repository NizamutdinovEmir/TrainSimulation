using Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route;

public class TrainPath
{
    private readonly Collection<Railway> _trackSegments;
    private readonly double _maxEndSpeed;

    public TrainPath(Collection<Railway> segments, double speed)
    {
        _trackSegments = segments;
        _maxEndSpeed = speed;
    }

    public SimulationInfo Simulate(ITrain train, double accuracy)
    {
        double totalTime = 0;
        var simulationInfo = new SimulationInfo { };

        foreach (Railway segment in _trackSegments)
        {
            SuccessInfo successInfo = segment.SuccessWay(train, accuracy);

            if (!successInfo.IsSuccess)
            {
                return FailedSimulation(simulationInfo, totalTime);
            }

            totalTime += successInfo.TimeSuccess;
        }

        return SuccessEndWay(train, simulationInfo, totalTime);
    }

    private SimulationInfo FailedSimulation(SimulationInfo simulationInfo, double totalTime)
    {
        simulationInfo.TimeSuccess = totalTime;
        simulationInfo.IsSuccess = false;

        return simulationInfo;
    }

    private SimulationInfo SuccessSimulation(SimulationInfo simulationInfo, double totalTime)
    {
        simulationInfo.TimeSuccess = totalTime;
        simulationInfo.IsSuccess = true;

        return simulationInfo;
    }

    private SimulationInfo SuccessEndWay(ITrain train, SimulationInfo simulationInfo, double totalTime)
    {
        if (!IsCorrectEndSpeed(train))
        {
            return FailedSimulation(simulationInfo, totalTime);
        }

        return SuccessSimulation(simulationInfo, totalTime);
    }

    private bool IsCorrectEndSpeed(ITrain train)
    {
        return train.Speed <= _maxEndSpeed;
    }
}