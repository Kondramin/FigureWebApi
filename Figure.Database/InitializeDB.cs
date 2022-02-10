using Figure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Figure.Database
{
    public class InitializeDB
    {
        private readonly FigureDb _db;

        public InitializeDB(FigureDb db)
        {
            _db = db;
        }


        public void Initialize()
        {
            _db.Database.Migrate();
        }
    }
}
