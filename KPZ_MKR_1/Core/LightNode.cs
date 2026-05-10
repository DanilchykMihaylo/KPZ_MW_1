abstract class LightNode
{
    public LightNode()
    {
        OnCreated();
    }

    protected virtual void OnCreated() { }

    protected virtual void OnRendered() { }

    protected virtual void OnChildAdded(LightNode node) { }

    public abstract string OuterHTML();
    public abstract string InnerHTML();
}