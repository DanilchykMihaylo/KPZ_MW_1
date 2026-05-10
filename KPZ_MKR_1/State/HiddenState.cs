class HiddenState : IElementState
{
    public string Handle(string html)
    {
        return "<!-- hidden -->";
    }
}