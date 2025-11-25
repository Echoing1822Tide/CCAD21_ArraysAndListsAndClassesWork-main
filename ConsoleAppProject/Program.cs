using System;
using System.Collections.Generic;
using System.Linq;
using Gadgets;

var gadgets = new List<IGadget>
{
    new LaserPointer("LP-9 \"Red Comet\"", 10),
    new HologramProjector("Holo-Stage MkII", 140),
    new GravityBoots("MagStep X", 180)
};

Console.WriteLine("=== Demo: Polymorphism ===");
foreach (var g in gadgets)
{
    // The interface is the same, but each class runs its own behavior.
    g.Activate();
    g.Deactivate();

    // Describe() lives on the abstract base; cast to access it cleanly.
    if (g is GadgetBase gb)
        Console.WriteLine(gb.Describe());

    Console.WriteLine();
}

// Bonus 1: gadget with longest name
var longest = gadgets
    .Select(g => (g as GadgetBase)!)
    .OrderByDescending(gb => gb.Name.Length)
    .First();
Console.WriteLine($"Longest name: {longest.Name}");

// Bonus 2: user activates a specific gadget
Console.WriteLine("\nActivate one gadget by number:");
for (int i = 0; i < gadgets.Count; i++)
{
    var name = (gadgets[i] as GadgetBase)!.Name;
    Console.WriteLine($"{i + 1}) {name}");
}
Console.Write("Choice: ");
if (int.TryParse(Console.ReadLine(), out int choice) &&
    choice >= 1 && choice <= gadgets.Count)
{
    var selected = gadgets[choice - 1];
    selected.Activate();
    if (selected is GadgetBase gb2) Console.WriteLine(gb2.Describe());
}
else
{
    Console.WriteLine("Invalid choice.");
}
