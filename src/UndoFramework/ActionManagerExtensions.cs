using System.Collections.Generic;

namespace GuiLabs.Undo
{
    public static class Extensions
    {
        public static void Execute(this ActionManager actionManager, IAction action)
        {
            if (actionManager == null)
            {
                action.Execute();
            }
            else
            {
                actionManager.RecordAction(action);
            }
        }

        public static void SetProperty(this ActionManager actionManager, object instance, string propertyName, object value)
        {
            SetPropertyAction action = new SetPropertyAction(instance, propertyName, value);
            Execute(actionManager, action);
        }

        public static void AddItem<T>(this ActionManager actionManager, ICollection<T> list, T item)
        {
            AddItemAction<T> action = new AddItemAction<T>(list.Add, t => list.Remove(t), item);
            actionManager.Execute(action);
        }
    }
}
