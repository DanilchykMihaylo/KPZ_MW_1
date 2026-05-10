using System.Text;

class LightElementNode : LightNode
{
    private string tagName;
    private string displayType;
    private bool isSelfClosing;

    private List<string> classes = new List<string>();
    private List<LightNode> children = new List<LightNode>();

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

        return sb.ToString();
    }
}