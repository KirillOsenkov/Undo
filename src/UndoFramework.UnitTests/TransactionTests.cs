using System;
using GuiLabs.Undo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UndoFramework.UnitTests
{
    [TestClass]
    public class TransactionTests
    {
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Transactions()
        {
            var instance = new Exception();
            instance.Source = "green";
            ActionManager am = new ActionManager();
            am.SetProperty(instance, "Source", "blue");
            Assert.AreEqual("blue", instance.Source);
            am.Undo();
            Assert.AreEqual("green", instance.Source);

            using (Transaction.Create(am))
            {
                am.SetProperty(instance, "Source", "red");
                Assert.AreEqual("green", instance.Source);
            }
            Assert.AreEqual(instance.Source, "red");
            am.Undo();
            Assert.AreEqual("green", instance.Source);
            am.Redo();
            Assert.AreEqual(instance.Source, "red");
        }

        [TestMethod]
        public void ThrowingActionInsideTransactionWillRollback()
        {
            ActionManager am = new ActionManager();
            var log = new LogAction();
            var throwing = new ThrowingAction();
            try
            {
                using (Transaction.Create(am))
                {
                    am.RecordAction(log);
                    am.RecordAction(throwing);
                }
            }
            catch (NotImplementedException)
            {
            }
            Assert.AreEqual(0, log.ExecutesCount);
            Assert.AreEqual(0, log.UnexecutesCount);
            Assert.AreEqual(0, am.TransactionStack.Count);
            Assert.AreEqual(false, am.ActionIsExecuting);
        }
    }

    public class LogAction : AbstractAction
    {
        public int ExecutesCount { get; set; }
        public int UnexecutesCount { get; set; }

        protected override void ExecuteCore()
        {
            ExecuteCount++;
        }

        protected override void UnExecuteCore()
        {
            UnexecutesCount++;
        }
    }

    public class FlagAction : AbstractAction
    {
        public bool Executed { get; set; }

        protected override void ExecuteCore()
        {
            Executed = true;
        }

        protected override void UnExecuteCore()
        {
            Executed = false;
        }
    }

    public class ThrowingAction : AbstractAction
    {
        protected override void ExecuteCore()
        {
            throw new NotImplementedException();
        }

        protected override void UnExecuteCore()
        {
            throw new NotImplementedException();
        }
    }
}
