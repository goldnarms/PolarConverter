using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL.Hjelpeklasser;
using Should;

namespace PolarConverter.Test
{
    [TestClass]
    public class StringHelperTest
    {
        [TestMethod]
        public void ShouldReturnNote()
        {
            const string note = "This is a note";
            const string textToTest = "[Note]\n" + note;
            var tabs = 0;
            var textOutput = StringHelper.LesLinjer(textToTest, "[Note]", out tabs);
            textOutput.Count.ShouldEqual(1);
            textOutput[0].ShouldEqual(note);
        }
    }
}
