class AddClassCommand : ICommand
{
    private LightElementNode element;
    private string className;

    public AddClassCommand(
        LightElementNode element,
        string className)
    {
        this.element = element;
        this.className = className;
    }

    public void Execute()
    {
        element.AddClass(className);
    }
}