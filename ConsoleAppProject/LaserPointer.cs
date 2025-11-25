using System;

namespace Gadgets;

public sealed class LaserPointer : GadgetBase
{
    public int MilliWatts { get; }

    public LaserPointer(string name, int milliWatts = 5) : base(name)
    {
        MilliWatts = milliWatts;
    }

    protected override void OnActivated()   => Console.WriteLine($"{Name} emits a focused {MilliWatts}mW beam.");
    protected override void OnDeactivated() => Console.WriteLine($"{Name} powers down; beam fades.");

    public override string Describe() => $"{base.Describe()} • Power: {MilliWatts}mW";
}
