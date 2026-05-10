using System.Text;

class LightElementNode : LightNode
{

    private string tagName;
    private string displayType;
    private bool isSelfClosing;

    private List<string> classes = new List<string>();
    private List<LightNode> children = new List<LightNode>();
    private IElementState state =
    new NormalState();

    public void SetState(IElementState state)
    {
        this.state = state;
    }
    public LightElementNode(
        string tagName,
        string displayType,
        bool isSelfClosing)
    {
        this.tagName = tagName;
        this.displayType = displayType;
        this.isSelfClosing = isSelfClosing;
    }

    public void AddClass(string className)
    {
        classes.Add(className);
    }

    public void AddChild(LightNode node)
    {
        children.Add(node);
        OnChildAdded(node);
    }

    public List<LightNode> GetChildren()
    {
        return children;
    }

    public override string InnerHTML()
    {
        StringBuilder sb = new StringBuilder();

        foreach (LightNode child in children)
        {
            sb.Append(child.OuterHTML());
        }

        return sb.ToString();
    }

    public override string OuterHTML()
    {
        OnRendered();
        StringBuilder sb = new StringBuilder();

        string classText = "";

        if (classes.Count > 0)
        {
            classText =
                $" class=\"{string.Join(" ", classes)}\"";
        }

        if (isSelfClosing)
        {
            sb.Append($"<{tagName}{classText}/>");
        }
        else
        {
            sb.Append($"<{tagName}{classText}>");
            sb.Append(InnerHTML());
            sb.Append($"</{tagName}>");
        }
        return state.Handle(sb.ToString());

    }
    protected override void OnCreated()
    {
        Console.WriteLine($"{tagName} created");
    }

    protected override void OnRendered()
    {
        Console.WriteLine($"{tagName} rendered");
    }

    protected override void OnChildAdded(LightNode node)
    {
        Console.WriteLine($"Child added to {tagName}");
    }
    public override void Accept(IVisitor visitor)
    {
        visitor.VisitElementNode(this);

        foreach (var child in children)
        {
            child.Accept(visitor);
        }
    }
}