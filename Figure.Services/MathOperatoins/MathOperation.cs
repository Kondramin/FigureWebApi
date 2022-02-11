using Figure.Data.Entity.Entities;
using Figure.Data.Entity.Entities.Base;
using Figure.Interfaces.MathOperations;
using System;

namespace Figure.Services.MathOperatoins
{
    public class MathOperation : IMathOperation
    {
        public double CalculateArea(FigureEntity figureEntity)
        {

            if (figureEntity.CountOfAngles == 0)
            {
                if (!(figureEntity is Circle circle)) throw new ArgumentException(nameof(figureEntity));
                return Math.Round(CalculateCircleArea(circle), 3);
            }
            
            if (!(figureEntity is Triangle triangle)) throw new ArgumentException(nameof(figureEntity));

            return Math.Round(CalculateTriangleArea(triangle), 3);
        }


        private double CalculateCircleArea(Circle circle)
        {
            return Math.PI * Math.Pow(circle.Radius, 2);
        }

        private double CalculateTriangleArea(Triangle triangle)
        {
            var hafPerimetr = (triangle.SideA + triangle.SideB + triangle.SideC) / 2;

            return Math.Sqrt(hafPerimetr * (hafPerimetr - triangle.SideA) * (hafPerimetr - triangle.SideB) * (hafPerimetr - triangle.SideC));
        }
    }
}
