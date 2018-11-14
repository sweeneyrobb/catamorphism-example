namespace catamorphism.models
{
    public class Subsection : IThing
    {
        public string Title { get; set; }
        public Clause[] Clauses { get; set; } = new Clause[] { };
    }

    public class SuperSubClause : IThing
    {
        public string Title { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}