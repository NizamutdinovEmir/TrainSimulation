using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab1.Tests;

public class TestScenario6
{
    [Fact]
    public void Check_UpToNotAllowedSpeedStationAndPath_DownToAllowedSpeedStationAndPath_ShouldBeSuccess()
    {
        // Arrange
        var train = new Train(1000, 1000);
        var segments = new Collection<Railway>
        {
            new PowerRailway(100, 900),
            new UsualRailway(10),
            new PowerRailway(100, -500),
            new Station(10, 10),
            new UsualRailway(20),
            new PowerRailway(100, 900),
            new UsualRailway(10),
            new PowerRailway(100, -300),
        };
        var path = new TrainPath(segments, 15);

        var result = new SimulationInfo { };

        // Act
        result = path.Simulate(train, 1);

        // Assert
        Assert.True(result.IsSuccess);
    }
}