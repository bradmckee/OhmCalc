using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OhmCalc.Tests
{
    [TestClass]
    public class OhmCalc_Tests
    {

        [TestMethod]
        public void OhmCalc_GetDefinedColors_Test()
        {
            var cbi = new Models.ColorBandData();
            var cbiList = cbi.ColorBandItems;
            Assert.IsTrue(cbiList.Count == 13);     // 12 colors + "None" option
        }

        [TestMethod]
        public void OhmCalc_RedRedOrangeGoldIs22000_Test()
        {
            var calc = new Models.Calculator();
            var ohmResult = calc.CalculateOhmValue("Red", "Red", "Orange", "Gold");
            Assert.IsTrue(ohmResult == 22000);
        }

        [TestMethod]
        public void OhmCalc_YellowVioletBrownGoldIs470_Test()
        {
            var calc = new Models.Calculator();
            var ohmResult = calc.CalculateOhmValue("Yellow", "Violet", "Brown", "Gold");
            Assert.IsTrue(ohmResult == 470);
        }

        [TestMethod]
        public void OhmCalc_NullVioletBrownGoldIsMinus1_Test()
        {
            var calc = new Models.Calculator();
            var ohmResult = calc.CalculateOhmValue(null, "Violet", "Brown", "Gold");
            Assert.IsTrue(ohmResult == -1);
        }
    }
}
