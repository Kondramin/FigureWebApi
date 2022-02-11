namespace Figure.Data.Entity.Entities.Base
{
    public abstract class FigureEntity : Entity
    {
        public string Name { get; set; }
        public int CountOfAngles { get; set; }
    }
}
