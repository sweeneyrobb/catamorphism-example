namespace catamorphism.models
{
    public class Section: IThing
    {
        public string Title { get; set; }
        public Subsection[] Subsections { get; set; } = new Subsection[] { };
    }
}