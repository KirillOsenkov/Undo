using System;
using System.Collections.Generic;
using GuiLabs.Undo;
using NUnit.Framework;

namespace UndoFramework.UnitTests
{
    [TestFixture]
    public class ActionsTests
    {
        [Test]
        public void AddItemActionWorks()
        {
            List<string> list = new List<string>();
            AddItemAction<string> action = new AddItemAction<string>(list.Add, s => list.Remove(s), "foo");
            ActionManager am = new ActionManager();
            am.RecordAction(action);
            Assert.AreEqual("foo", list[0]);
            am.Undo();
            Assert.AreEqual(0, list.Count);
            am.Redo();
            Assert.AreEqual("foo", list[0]);
        }

        [Test]
        public void CallMethodActionWorks()
        {
            bool capturedFlag = false;
            ActionManager am = new ActionManager();
            CallMethodAction action = new CallMethodAction(
                () => capturedFlag = true,
                () => capturedFlag = false);
            am.RecordAction(action);
            Assert.IsTrue(capturedFlag);
            am.Undo();
            Assert.IsFalse(capturedFlag);
            am.Redo();
            Assert.IsTrue(capturedFlag);
        }

        [Test]
        public void SetPropertyActionWorks()
        {
            var instance = new Exception();
            SetPropertyAction action = new SetPropertyAction(instance, "Source", "foo");
            ActionManager am = new ActionManager();
            am.RecordAction(action);
            Assert.AreEqual("foo", instance.Source);
            am.Undo();
            Assert.AreEqual(null, instance.Source);
            am.Redo();
            Assert.AreEqual("foo", instance.Source);
        }
    }
}