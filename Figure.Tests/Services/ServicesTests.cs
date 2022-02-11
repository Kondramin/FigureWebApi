using Figure.Data.Entity.Entities;
using Figure.Services.MathOperatoins;
using NUnit.Framework;

namespace Figure.Tests.Services
{
    [TestFixture]
    public class ServicesTests
    {
        [Test]
        public void CalculateTriangleAreaTest()
        {
            // Arrange
            var mathOperation = new MathOperation();
            var triangle = new Triangle() { CountOfAngles = 3, SideA = 10, SideB = 10, SideC = 10 };
            var area = 43.301;


            // Act - Assert
            var result = mathOperation.CalculateArea(triangle);


            // Assert
            Assert.AreEqual(area, result);
        }

        [Test]
        public void CalculateCircleAreaTest()
        {
            // Arrange
            var mathOperation = new MathOperation();
            var circle = new Circle() { CountOfAngles = 0, Radius = 15 };
            var area = 706.858;


            // Act - Assert
            var result = mathOperation.CalculateArea(circle);


            // Assert
            Assert.AreEqual(area, result);
        }
    }
}
