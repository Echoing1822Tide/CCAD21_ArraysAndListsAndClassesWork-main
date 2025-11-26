namespace Gadgets;

public abstract class GadgetBase : IGadget
{
    public string Name { get; }
    public string Status { get; private set; } = "Idle";

    protected GadgetBase(string name) => Name = name;

    // Template Method pattern: fixed outer flow, virtual inner hooks.
    public void Activate()
    {
        Status = "Activated";
        OnActivated();
    }

    public void Deactivate()
    {
        Status = "Deactivated";
        OnDeactivated();
    }

    protected virtual void OnActivated() { }
    protected virtual void OnDeactivated() { }

    // IMPORTANT: keep this returning a string (callers depend on it).
    public virtual string Describe() => $"{Name} [{Status}]";
}
