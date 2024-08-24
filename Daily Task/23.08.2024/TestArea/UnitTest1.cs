using UnitTesting;

namespace TestArea
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void TestSquare()
        {
            Area a = new Area();
            var result = a.Square(4);
            Assert.AreEqual(16, result);
        }
        [Test]
        public void TestCircle()
        {
            Area a = new Area();
            var result = a.Circle(1);
            Assert.AreEqual(3.14, result);
        }
        [Test]
        public void TestRectangle()
        {
            Area a = new Area();
            var result = a.Rectangle(2,4);
            Assert.AreEqual(8, result);
        }
    }
}