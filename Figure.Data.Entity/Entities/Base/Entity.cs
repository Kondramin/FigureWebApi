using Figure.Interfaces.Base.Entities;

namespace Figure.Data.Entity.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
