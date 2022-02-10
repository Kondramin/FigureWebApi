using Figure.Data.Entity.Entities.Base;

namespace Figure.Data.Entity.Entities
{
    public class Triangle : FigureEntity
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
    }
}