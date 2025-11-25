using System;

namespace Gadgets;

public sealed class HologramProjector : GadgetBase
{
    public double FieldOfViewDegrees { get; }

    public HologramProjector(string name, double fovDeg = 120) : base(name)
    {
        FieldOfViewDegrees = fovDeg;
    }

    protected override void OnActivated()   => Console.WriteLine($"{Name} paints a volumetric image (FOV {FieldOfViewDegrees:0.#}°).");
    protected override void OnDeactivated() => Console.WriteLine($"{Name} collapses the hologram.");

    public override string Describe() => $"{base.Describe()} • FOV: {FieldOfViewDegrees:0.#}°";
}
