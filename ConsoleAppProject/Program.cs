using System;
using System.Collections.Generic;
using Gadgets;

// ==============================================
// Intergalactic Control Earth Protection — Driver
// ==============================================
class Program
{
    static void Main()
    {
        // Enable colors/UTF-8 once
        VT.EnableIfWindows();
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var gadgets = new List<IGadget>
{
    new LaserPointer("LP-3 \"Dotty\"", 5),
    new HologramProjector("HOLO-Deck MkII", 120),
    new GravityBoots("G-Boosters", 250),
};

        // Banner + mission chatter
        BattleUI.Banner("Intergalactic Control Earth Protection — Humans vs Aliens");
        BattleUI.Comms("Ops", "Enemy signatures inbound. Weapons on standby.");
        VT.EnableIfWindows();               // turn on ANSI colors for Windows consoles
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        VT.Alert("Shields at 40% — brace!");
        BattleUI.Scoreboard(humans: 7, aliens: 7);        // cosmetic meter
        BattleUI.Divider("Engagement Alpha");
        BattleUI.Taunt();

        // Main loop — same interface, different behaviors per gadget
        foreach (var g in gadgets)
        {
            if (g is GadgetBase gb)
            {
                BattleUI.Divider(gb.Name);
                BattleUI.Comms("Ops", $"Authorize {gb.Name}? (Y to engage)");
                Console.Write("Activate the Intergalactic Control Earth Protection now? (Y/N):");
                string? yn = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(yn) &&
                    yn.StartsWith("y", StringComparison.OrdinalIgnoreCase))
                {
                    g.Activate();       // each class prints its own effects
                    BattleUI.Cheer();   // fun feedback line
                    g.Deactivate();
                    Console.WriteLine();
                }
            }
        }

        // Bonus 1: longest gadget name (manual scan — no LINQ required)
        var longest = (gadgets[0] as GadgetBase)!;
        for (int i = 1; i < gadgets.Count; i++)
        {
            var gb = (gadgets[i] as GadgetBase)!;
            if (gb.Name.Length > longest.Name.Length) longest = gb;
        }
        Console.WriteLine($"Longest name: {longest.Name} ({longest.Name.Length} chars)");

        // Bonus 2: user activates a specific gadget by number
        Console.WriteLine("\nPick a weapon to activate by number, or press Enter to quit:");
        for (int i = 0; i < gadgets.Count; i++)
            Console.WriteLine($"{i + 1}) {(gadgets[i] as GadgetBase)!.Name}");

        Console.Write("> ");
        string? choiceText = Console.ReadLine();
        if (int.TryParse(choiceText, out int choice) &&
            choice >= 1 && choice <= gadgets.Count)
        {
            var selected = gadgets[choice - 1];
            BattleUI.Divider($"Direct Command → {(selected as GadgetBase)!.Name}");
            selected.Activate();
            selected.Deactivate();
        }
        // Epilogue
        BattleUI.Divider("AAR Summary");
        BattleUI.Comms("Ops", "Skies are clear. Good work out there.");
        Console.WriteLine("The War is Over!. Press any key to exit.");
        Console.ReadKey(true);
    }
}