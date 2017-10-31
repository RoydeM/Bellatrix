using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Bellatrix.Infrastructure.AdoNetRepository;
using Bellatrix.Core;

namespace Test.Services.DbLogger
{
    [TestClass]
    public class DbLoggerTest
    {
        [TestMethod]
        public void TestLogMethod()
        {
            Mock<AdoNetRepository> repo = new Mock<AdoNetRepository>();
            ILogger logger = new Bellatrix.Services.Logger.DbLogger.DbLogger(repo.Object);
            logger.Log(LogLevel.Success, "Sample");
        }
    }
}