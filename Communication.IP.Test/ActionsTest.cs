using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Communication.IP;

namespace Communication.IP.Test
{
    [TestClass]
    public class ActionsTest
    {
        [TestMethod]
        public void ShutdownTest()
        {
            Actions.Shutdown();
        }
    }
}
