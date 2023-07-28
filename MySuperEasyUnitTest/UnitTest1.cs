using MyBestDataClassEver.Helpers;

namespace MySuperEasyUnitTest {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestEasyCount() {
            Assert.AreEqual(2, CalcHelper.EvaluateExpression("1+1"));
        }
        [TestMethod]
        public void TestNotToEasyCount() {
            Assert.AreEqual(4, CalcHelper.EvaluateExpression("1+1+2"));
        }
        [TestMethod]
        public void TestHardCoreCount() {
            Assert.AreEqual(
               252909.47288266668,
                CalcHelper.EvaluateExpression("1+2+3/45-0.222+232136+41541.256432/2")
                );
        }
    }
}