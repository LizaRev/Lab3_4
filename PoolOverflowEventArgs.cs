using System;

public class PoolOverflowEventArgs : EventArgs
{
    public double CurrentWater { get; }
    public double Volume { get; }
    public double OverflowAmount { get; }

    public PoolOverflowEventArgs(double currentWater, double volume, double overflowAmount)
    {
        CurrentWater = currentWater;
        Volume = volume;
        OverflowAmount = overflowAmount;
    }
}