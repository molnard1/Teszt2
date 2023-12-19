namespace Teszt2.Tests.NUnit
{
    public class Tests
    {
        #region Ne figyelj erre!
        [SetUp, TearDown] public static void DoNothing() { }
        #endregion

        [TestCase(7, '1')]
        [TestCase(8, '2')]
        [TestCase(10, '0')]
        public void OsztokTeszt1(long input, char expected)
        {
            Assert.That(Program.DoCalc(input), Is.EqualTo(expected));
        }

        [TestCase(2, '0')]
        [TestCase(4, '2')]
        [TestCase(6, '0')]
        [TestCase(8, '2')]
        [TestCase(10, '0')]
        public void OsztokTeszt2(long input, char expected)
        {
            Assert.That(Program.DoCalc(input), Is.EqualTo(expected));
        }

        [TestCase(1000000000000, '2')]
        [Repeat(1000)]
        [Timeout(5000)]
        public void IdotullepesTeszt(long input, char expected)
        {
            Assert.That(Program.DoCalc(input), Is.EqualTo(expected));
        }

        [TestCase("macska")]
        [TestCase(null)]
        public void HibaTeszt(dynamic input)
        {
            Assert.That(() => Program.DoCalc(input), Throws.Exception);
        }
    }
}