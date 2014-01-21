using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolarConverter.BLL.Hjelpeklasser;
using Should;
using Should.Fluent;

namespace PolarConverter.Test
{
    using System.Collections.Generic;

    using BLL;

    [TestClass]
    public class DropboxTest
    {
        [TestMethod]
        public void SokEtterFiler()
        {
            DropboxHelper.LoginDropbox("0l9thfitgdijcrh", "a4yemhsnokuz4jm");
            DropboxHelper.SokOppFilerFraDropboxMappe(FilTyper.Hrm).ShouldBeType(typeof (List<string>));
            DropboxHelper.SokOppFilerFraDropboxMappe(FilTyper.Hrm).Should().Count.AtLeast(1);
        }
    }
}
