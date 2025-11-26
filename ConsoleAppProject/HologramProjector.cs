namespace Gadgets;
public sealed class HologramProjector : GadgetBase
    {
        public double FieldOfViewDegrees { get; }

        public HologramProjector(string name, double fov) : base(name) => FieldOfViewDegrees = fov;

        protected override void OnActivated()
        {
            BattleUI.TypeLine($"{Name}: deploying decoy battalion…");
            BattleUI.Spinner("Projecting volumetric light");
            Console.WriteLine($"{Name} paints a volumetric image (FOV {FieldOfViewDegrees:0.#}°).");
            Console.WriteLine("Alien drones are confused and veer off course!");
        }

        protected override void OnDeactivated()
        {
            BattleUI.PauseDots("Collapsing light field");
            Console.WriteLine($"{Name} collapses the hologram.");
        }

        public override string Describe() => $"{base.Describe()} • FOV: {FieldOfViewDegrees:0.#}°";
    }
