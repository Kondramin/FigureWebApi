using Figure.Interfaces.Base.Entities;

namespace FigureWebApi.DtoModels
{
    public class TriangleDto : IMappedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }


        public double Area { get; set; }
    }
}
