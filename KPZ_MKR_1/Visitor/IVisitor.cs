interface IVisitor
{
    void VisitTextNode(LightTextNode node);
    void VisitElementNode(LightElementNode node);
}