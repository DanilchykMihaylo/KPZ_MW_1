class TagCountVisitor : IVisitor
{
    public int Count = 0;

    public void VisitTextNode(LightTextNode node)
    {
    }

    public void VisitElementNode(LightElementNode node)
    {
        Count++;
    }
}