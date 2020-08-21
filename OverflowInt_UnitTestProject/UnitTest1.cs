using Microsoft.VisualStudio.TestTools.UnitTesting;
using OverflowInt_App;

namespace OverflowInt_UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestarSeRetornaInteiroPositivo()
        {
            Calculos calculos = new Calculos();
            int velocity = 6;

            int[] floatPoints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            foreach (var point in floatPoints)
            {
                var x = calculos.CalculoTrajetoria(point, velocity);
                Assert.IsFalse(x < 0);
            }
        }
    }
}
