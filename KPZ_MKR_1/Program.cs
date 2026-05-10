class Program
{
    static void Main()
    {
        LightElementNode ul =
            new LightElementNode("ul", "block", false);

        ul.AddClass("menu");

        LightElementNode li1 =
            new LightElementNode("li", "block", false);

        li1.AddChild(new LightTextNode("Home"));

        LightElementNode li2 =
            new LightElementNode("li", "block", false);

        li2.AddChild(new LightTextNode("About"));

        ul.AddChild(li1);
        ul.AddChild(li2);

        Console.WriteLine(ul.OuterHTML());
        Console.WriteLine("\nDFS:");

        DepthFirstIterator iterator =
            new DepthFirstIterator(ul);

        while (iterator.HasNext())
        {
            Console.WriteLine(
                iterator.Next().OuterHTML());
        }
        ICommand command =
    new AddClassCommand(ul, "active");

        command.Execute();
        ul.SetState(new HiddenState());

        Console.WriteLine(ul.OuterHTML());
        TagCountVisitor visitor =
    new TagCountVisitor();

        ul.Accept(visitor);

        Console.WriteLine(visitor.Count);
    }
}