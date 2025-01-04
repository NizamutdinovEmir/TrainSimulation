using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab1.Tests;

public class TestScenario8
{
    [Fact]
    public void Check_PowerWay_PositiveAndNegativePower_ShouldBeFailure()
    {
        // Arrange
        var train = new Train(1000, 100);
        var segments = new Collection<Railway>
        {
            new PowerRailway(50, 100),
            new PowerRailway(50, -200),
        };

        var path = new TrainPath(segments, 10);

        var result = new SimulationInfo { };

        // Act
        result = path.Simulate(train, 1);

        // Assert
        Assert.True(!result.IsSuccess);
    }
}