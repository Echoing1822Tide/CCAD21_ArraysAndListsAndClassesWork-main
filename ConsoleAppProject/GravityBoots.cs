using System;

namespace Gadgets;

public sealed class GravityBoots : GadgetBase
{
    public int MaxLiftKg { get; }

    public GravityBoots(string name, int maxLiftKg = 150) : base(name)
    {
        MaxLiftKg = maxLiftKg;
    }

    protected override void OnActivated()   => Console.WriteLine($"{Name} engages magnetic soles (max lift {MaxLiftKg} kg).");
    protected override void OnDeactivated() => Console.WriteLine($"{Name} releases; back to normal gravity.");

    public override string Describe() => $"{base.Describe()} • Max lift: {MaxLiftKg} kg";
}
