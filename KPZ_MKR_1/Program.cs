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
    }
}