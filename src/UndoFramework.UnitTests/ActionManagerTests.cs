using System.Linq;
using System.Text;
using GuiLabs.Undo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UndoFramework.UnitTests
{
    [TestClass]
    public class ActionManagerTests
    {
        [TestMethod]
        public void TestEndToEnd1()
        {
            var actionManager = new ActionManager();
            var sb = new StringBuilder();
            var action1 = new CallMethodAction(
                () => sb.Append("execute1 "),
                () => sb.Append("unexecute1 "));
            var action2 = new CallMethodAction(
                () => sb.Append("execute2 "),
                () => sb.Append("unexecute2 "));

            Assert.IsFalse(actionManager.CanUndo);
            Assert.IsFalse(actionManager.CanRedo);
            Assert.AreEqual(0, actionManager.EnumUndoableActions().Count());
            Assert.AreEqual(0, actionManager.EnumRedoableActions().Count());

            actionManager.Execute(action1);
            Assert.AreEqual("execute1 ", sb.ToString());
            Assert.IsTrue(actionManager.CanUndo);
            Assert.IsFalse(actionManager.CanRedo);
            Assert.AreEqual(action1, actionManager.EnumUndoableActions().Single());
            Assert.AreEqual(0, actionManager.EnumRedoableActions().Count());

            actionManager.Execute(action2);
            Assert.AreEqual("execute1 execute2 ", sb.ToString());
            Assert.IsTrue(actionManager.CanUndo);
            Assert.IsFalse(actionManager.CanRedo);
            Assert.IsTrue(actionManager.EnumUndoableActions().SequenceEqual(new IAction[]
                { action1, action2 }));
            Assert.AreEqual(0, actionManager.EnumRedoableActions().Count());

            actionManager.Undo();
            Assert.AreEqual("execute1 execute2 unexecute2 ", sb.ToString());
            Assert.IsTrue(actionManager.CanUndo);
            Assert.IsTrue(actionManager.CanRedo);
            Assert.AreEqual(action1, actionManager.EnumUndoableActions().Single());
            Assert.AreEqual(action2, actionManager.EnumRedoableActions().Single());

            actionManager.Undo();
            Assert.AreEqual("execute1 execute2 unexecute2 unexecute1 ", sb.ToString());
            Assert.IsFalse(actionManager.CanUndo);
            Assert.IsTrue(actionManager.CanRedo);
            Assert.AreEqual(0, actionManager.EnumUndoableActions().Count());
            Assert.IsTrue(actionManager.EnumRedoableActions().SequenceEqual(new IAction[]
                { action1, action2 }));

            actionManager.Redo();
            Assert.AreEqual("execute1 execute2 unexecute2 unexecute1 execute1 ", sb.ToString());
            Assert.IsTrue(actionManager.CanUndo);
            Assert.IsTrue(actionManager.CanRedo);
            Assert.AreEqual(action1, actionManager.EnumUndoableActions().Single());
            Assert.AreEqual(action2, actionManager.EnumRedoableActions().Single());

            actionManager.Redo();
            Assert.AreEqual("execute1 execute2 unexecute2 unexecute1 execute1 execute2 ", sb.ToString());
            Assert.IsTrue(actionManager.CanUndo);
            Assert.IsFalse(actionManager.CanRedo);
            Assert.IsTrue(actionManager.EnumUndoableActions().SequenceEqual(new IAction[]
                { action1, action2 }));
            Assert.AreEqual(0, actionManager.EnumRedoableActions().Count());
        }

        [TestMethod]
        public void ShouldRaiseCollectionChangedEventForFirstAction()
        {
            int collectionChanges = 0;

            var actionManager = new ActionManager();
            actionManager.CollectionChanged += (sender, e) =>
            {
                collectionChanges++;
            };

            var action = new CallMethodAction(() => { }, () => { });
            actionManager.Execute(action);
            Assert.AreEqual(1, collectionChanges);
        }

        [TestMethod]
        public void ShouldRaiseCollectionChangedEventForFirstTransaction()
        {
            int collectionChanges = 0;

            var actionManager = new ActionManager();
            actionManager.CollectionChanged += (sender, e) =>
            {
                collectionChanges++;
            };

            var action = new CallMethodAction(() => { }, () => { });
            var transaction = actionManager.CreateTransaction();
            transaction.Add(action);
            transaction.Commit();
            Assert.AreEqual(1, collectionChanges);
        }

    }
}
