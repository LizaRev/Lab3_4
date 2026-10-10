using System;

public class Pool
{
    public double Length { get; private set; }
    public double Width { get; private set; }
    public double Depth { get; private set; }

    public double CurrentWater { get; private set; }

    public double Volume
    {
        get
        {
            return Length * Width * Depth * 1000;
        }
    }

    public Pool(double length, double width, double depth)
    {
        Length = length;
        Width = width;
        Depth = depth;
        CurrentWater = 0;
    }

    public event EventHandler<PoolOverflowEventArgs>? PoolOverflow;

    public void AddWater(double liters)
    {
        CurrentWater += liters;

        if (CurrentWater > Volume)
        {
            double overflowAmount = CurrentWater - Volume;

            PoolOverflowEventArgs args =
                new PoolOverflowEventArgs(
                    CurrentWater,
                    Volume,
                    overflowAmount);

            OnPoolOverflow(args);
        }
    }

    public void RemoveWater(double liters)
    {
        CurrentWater -= liters;

        if (CurrentWater < 0)
        {
            CurrentWater = 0;
        }
    }

    protected virtual void OnPoolOverflow(PoolOverflowEventArgs e)
    {
        PoolOverflow?.Invoke(this, e);
    }
}
