using Microsoft.CSharp.RuntimeBinder;

namespace Teszt2.Tests.MSTest
{
    [TestClass]
    public class Tests
    {
        #region Ne figyelj erre!

        [TestInitialize, TestCleanup]
        public void DoNothing()
        {
        }

        #endregion

        [TestMethod]
        [DataRow(7, '1')]
        [DataRow(8, '2')]
        [DataRow(10, '0')]
        public void OsztokTeszt1(long input, char expected)
        {
            Assert.AreEqual(expected, Program.DoCalc(input));
        }

        [TestMethod]
        [DataRow(2, '0')]
        [DataRow(4, '2')]
        [DataRow(6, '0')]
        [DataRow(8, '2')]
        [DataRow(10, '0')]
        public void OsztokTeszt2(long input, char expected)
        {
            Assert.AreEqual(expected, Program.DoCalc(input));
        }

        [TestMethod]
        [DataRow(1000000000000, '2')]
        [Timeout(5000)]
        public void IdotullepesTeszt(long input, char expected)
        {
            for (int i = 0; i < 1000; i++)
            {
                // MSTestben nincs [Repeat] :(
                Assert.AreEqual(expected, Program.DoCalc(input));
            }
        }

        [TestMethod]
        [DataRow("macska")]
        [DataRow(null)]
        [ExpectedException(typeof(RuntimeBinderException))]
        public void HibaTeszt(dynamic input)
        {
            Program.DoCalc(input);
        }
    }
}