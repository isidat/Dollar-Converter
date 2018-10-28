using Microsoft.VisualStudio.TestTools.UnitTesting;

using DollarConverterService.Model;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestParser()
        {
            Assert.AreEqual(new ParsedNumberModel
            {
                Dollars = 0
            }.ToString(), DollarConverterService.Parser.Parse("0").ToString());

            Assert.AreEqual(new ParsedNumberModel
            {
                Dollars = 1
            }.ToString(), DollarConverterService.Parser.Parse("1").ToString());

            Assert.AreEqual(new ParsedNumberModel
            {
                Dollars = 25,
                Cents = 10
            }.ToString(), DollarConverterService.Parser.Parse("25,1").ToString());

            Assert.AreEqual(new ParsedNumberModel
            {
                Dollars = 0,
                Cents = 1
            }.ToString(), DollarConverterService.Parser.Parse("0,01").ToString());

            Assert.AreEqual(new ParsedNumberModel
            {
                Dollars = 45100
            }.ToString(), DollarConverterService.Parser.Parse("45 100").ToString());

            Assert.AreEqual(new ParsedNumberModel
            {
                Dollars = 999999999,
                Cents = 99
            }.ToString(), DollarConverterService.Parser.Parse("999 999 999,99").ToString());
        }

        [TestMethod]
        public void TestConverter()
        {
            Assert.AreEqual("zero", DollarConverterService.Converter.NumberToWord(0));

            Assert.AreEqual("one", DollarConverterService.Converter.NumberToWord(1));

            Assert.AreEqual("twenty-five", DollarConverterService.Converter.NumberToWord(25));

            Assert.AreEqual("ninety-nine", DollarConverterService.Converter.NumberToWord(99));

            Assert.AreEqual("forty-five thousand one hundred", DollarConverterService.Converter.NumberToWord(45100));

            Assert.AreEqual("nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine", DollarConverterService.Converter.NumberToWord(999999999));
        }
    }
}
