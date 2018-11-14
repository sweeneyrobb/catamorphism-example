namespace catamorphism.models
{
    public class Clause : IThing
    {
        public string Title { get; set; }
        public Subclause[] Subclauses { get; set; } = new Subclause[] { };
    }
}