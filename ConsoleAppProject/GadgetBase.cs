using System;

namespace Gadgets;

public abstract class GadgetBase : IGadget
{
    public string Name { get; }
    public bool IsActive { get; private set; }
    public string Status => IsActive ? "Active" : "Inactive";

    protected GadgetBase(string name)
    {
        Name = string.IsNullOrWhiteSpace(name) ? "Unnamed Gadget" : name.Trim();
    }

    // Interface methods provide the template; derived classes customize via hooks.
    public void Activate()
    {
        if (!IsActive)
        {
            IsActive = true;
            OnActivated();
        }
        else
        {
            Console.WriteLine($"{Name} is already active.");
        }
    }

    public void Deactivate()
    {
        if (IsActive)
        {
            IsActive = false;
            OnDeactivated();
        }
        else
        {
            Console.WriteLine($"{Name} is already inactive.");
        }
    }

    // “Hooks” for per-gadget behavior
    protected virtual void OnActivated()   => Console.WriteLine($"{Name} activated.");
    protected virtual void OnDeactivated() => Console.WriteLine($"{Name} deactivated.");

    public virtual string Describe() => $"{Name} [{Status}]";
}
