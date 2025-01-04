using Itmo.ObjectOrientedProgramming.Lab1.RouteSegment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Transport;

public class Train : ITrain
{
    public double Mass { get; }

    public double Speed { get; private set; }

    public double Acceleration { get; private set; }

    public double MaxPower { get; }

    public Train(double mass, double maxPower)
    {
        Mass = mass;
        Speed = 0;
        Acceleration = 0;
        MaxPower = maxPower;
    }

    public SuccessInfo CalculateTime(double distance, double accuracy)
    {
        var info = new SuccessInfo { };
        double totalTimeDistance = 0;
        while (distance > 0)
        {
            if (IsStopped())
            {
                info.TimeSuccess = 0;
                info.IsSuccess = false;
                return info; // не делать так
            }

            UpdateSpeed(accuracy);

            double distanceTraveled = CalculateDistanceTravelled(accuracy);

            distance -= distanceTraveled;

            totalTimeDistance += accuracy;
        }

        info.TimeSuccess = totalTimeDistance;
        info.IsSuccess = true;

        return info;
    }

    public bool ApplyPower(double power)
    {
        double absPower = double.Abs(power);

        if (!IsPowerCorrect(absPower))
        {
            return false;
        }

        SetAcceleration(power);

        return true;
    }

    public void SetAcceleration(double power)
    {
        Acceleration = power / Mass;
    }

    private bool IsStopped()
    {
        return Speed <= 0 && Acceleration <= 0;
    }

    private void UpdateSpeed(double accuracy)
    {
        Speed += accuracy * Acceleration;
    }

    private double CalculateDistanceTravelled(double accuracy)
    {
        return Speed * accuracy;
    }

    private bool IsPowerCorrect(double absPower)
    {
        return absPower <= MaxPower;
    }
}
