using Figure.Interfaces.Base.Entities;

namespace FigureWebApi.DtoModels
{
    public class CircleDto : IMappedEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Radius { get; set; }


        public double Area { get; set; }
    }
}
