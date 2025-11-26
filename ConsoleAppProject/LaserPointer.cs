namespace Gadgets;

public sealed class LaserPointer : GadgetBase
{
    public int MilliWatts { get; }
    private readonly Random _rng = new();

    public LaserPointer(string name, int mW) : base(name) => MilliWatts = mW;

    protected override void OnActivated()
    {
        BattleUI.TypeLine($"{Name}: targeting hostile scout…");
        BattleUI.Spinner("Calibrating optics");
        BattleUI.Beam("HUMANS", "ALIENS");
        bool hit = _rng.Next(100) < 70;   // 70% hit chance
#if WINDOWS
                        Console.Beep(1000, 120);          // pew
                        Console.Beep(1400, 120);
#endif
        BattleUI.Outcome(hit);
        Console.WriteLine($"{Name} emits a focused {MilliWatts} mW beam.");
    }
    protected override void OnDeactivated()
    {
        BattleUI.PauseDots("Cooling emitter");
        Console.WriteLine($"{Name} powers down; the red dot fades.");
    }
    public override string Describe() => $"{base.Describe()} • Power: {MilliWatts} mW";
}
