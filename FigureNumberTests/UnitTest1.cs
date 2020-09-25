using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureNumberTests;
using HappyTickets;

namespace FigureNumberTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            int k = 3;
            double[] actualArray = new double[28];            
            double[] expectedArray = new double[28] { 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 63, 69, 73, 75, 75, 73, 69, 63, 55, 45, 36, 28, 21, 15, 10, 6, 3, 1 };

            // Act
            for (int i = 0; i < actualArray.Length; i++)
            {
                actualArray[i] = Program.alternateFigureNumber(i, k);
            }

            // Assert
            for (int i = 0; i < actualArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], actualArray[i], $"Arrays are not equal on {i} position.");
            }
        }
    }
}
