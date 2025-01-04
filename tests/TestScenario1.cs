using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab1.Tests;

public class TestScenario1
{
    [Fact]
    public void Check_UpToAllowedMaxSpeedPath_ShouldBeSuccess()
    {
        // Arrange
        var train = new Train(1000, 100);
        var segments = new Collection<Railway>
        {
            new PowerRailway(10, 50),
            new UsualRailway(10),
        };

        var path = new TrainPath(segments, 50);

        var result = new SimulationInfo { };

        // Act
        result = path.Simulate(train, 1);

        // Assert
        Assert.True(result.IsSuccess);
    }
}