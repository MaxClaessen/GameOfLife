using System;
using System.Runtime.InteropServices;
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
            var main = new Main();
            var result = main.CreateGrid(1, 2);

            Assert.AreEqual(typeof(System.Boolean[,]), result.GetType());
        }
    }
}
