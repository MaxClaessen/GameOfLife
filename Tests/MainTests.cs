using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void X()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestGridCreation()
        {
            var grid = new Grid();
            var result = grid.CreateGrid(1, 2);

            Assert.AreEqual(typeof(bool[,]), result.GetType());
        }
    }
}
