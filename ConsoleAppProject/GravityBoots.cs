namespace Gadgets;


public sealed class GravityBoots : GadgetBase
{
    public int MaxLiftKg { get; }

    public GravityBoots(string name, int maxLiftKg) : base(name) => MaxLiftKg = maxLiftKg;

    protected override void OnActivated()
    {
        VT.Warn("Brace! Hull vibrations increasing!");
        BattleUI.TypeLine($"{Name}: engage mag-clamps, brace for recoil!");
        BattleUI.Spinner("Aligning to ship hull");
        Console.WriteLine($"{Name} engages magnetic soles (max lift {MaxLiftKg} kg).");
        Console.WriteLine("You vault over debris and flank the invaders.");
    }

    protected override void OnDeactivated()
    {
        BattleUI.PauseDots("Equalizing gravity");
        Console.WriteLine($"{Name} releases; back to normal gravity.");
    }

    public override string Describe() => $"{base.Describe()} • Max lift: {MaxLiftKg} kg";
}