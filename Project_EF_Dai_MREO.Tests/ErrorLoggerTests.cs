using NUnit.Framework;
using DAI_MREO.Services;
using System;
using System.IO;

namespace DAI_MREO.Tests
{
    public class ErrorLoggerTests
    {
        private ErrorLogger logger;
        private const string LogFileName = "error_log.txt";

        [SetUp]
        public void Setup()
        {
            // Ensure no leftover log file
            if (File.Exists(LogFileName))
                File.Delete(LogFileName);

            logger = new ErrorLogger();
        }

        [Test]
        public void Log_Should_StoreMessage()
        {
            var ex = new Exception("Test error");

            logger.Log(ex);

            string all = logger.GetAllMessagesAsString();

            Assert.That(all, Does.Contain("Test error"));
        }

        [Test]
        public void GetAllMessagesAsString_WhenNoMessages_ReturnsNoErrorsText()
        {
            string result = logger.GetAllMessagesAsString();
            Assert.AreEqual("Помилок не зафіксовано.", result.Trim());
        }

        [Test]
        public void SaveToFile_Should_CreateLogFile_WhenMessagesExist()
        {
            logger.Log(new Exception("File error"));

            logger.SaveToFile();

            Assert.IsTrue(File.Exists(LogFileName));

            var content = File.ReadAllText(LogFileName);
            Assert.That(content, Does.Contain("File error"));
        }
    }
}
