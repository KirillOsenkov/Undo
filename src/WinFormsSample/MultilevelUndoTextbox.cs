using System;
using System.Windows.Forms;
using GuiLabs.Undo;

namespace WinFormsSample
{
    partial class Form1
    {
        private bool guard = false;

        private void MultilevelTextbox_TextChanged(object sender, EventArgs e)
        {
            if (guard)
            {
                return;
            }
            guard = true;

            var action = new MultilevelUndoTextboxChangeAction(MultilevelTextbox, oldText, oldSelectionStart, oldSelectionLength);
            multilevelTextboxActionManager.RecordAction(action);
            oldText = MultilevelTextbox.Text;
            oldSelectionStart = MultilevelTextbox.SelectionStart;
            oldSelectionLength = MultilevelTextbox.SelectionLength;
            UpdateMultilevelUndoRedoButtons();

            guard = false;
        }

        private void UpdateMultilevelUndoRedoButtons()
        {
            MultilevelTextboxRedoButton.Enabled = multilevelTextboxActionManager.CanRedo;
            MultilevelTextboxUndoButton.Enabled = multilevelTextboxActionManager.CanUndo;
        }

        private string oldText = "";
        private int oldSelectionStart = 0;
        private int oldSelectionLength = 0;

        private ActionManager multilevelTextboxActionManager = new ActionManager();

        private void MultilevelTextboxUndoButton_Click(object sender, EventArgs e)
        {
            if (guard)
            {
                return;
            }
            guard = true;
            multilevelTextboxActionManager.Undo();
            UpdateMultilevelUndoRedoButtons();
            oldText = MultilevelTextbox.Text;
            guard = false;
        }

        private void MultilevelTextboxRedoButton_Click(object sender, EventArgs e)
        {
            if (guard)
            {
                return;
            }
            guard = true;
            multilevelTextboxActionManager.Redo();
            UpdateMultilevelUndoRedoButtons();
            oldText = MultilevelTextbox.Text;
            guard = false;
        }
    }

    public class MultilevelUndoTextboxChangeAction : AbstractAction
    {
        private readonly TextBox textbox;

        private readonly string oldText;
        private readonly int oldSelectionStart;
        private readonly int oldSelectionLength;
        private string newText;
        private int newSelectionStart;
        private int newSelectionLength;
        
        private readonly DateTime timestamp;
        private bool firstTime = true;

        public MultilevelUndoTextboxChangeAction(TextBox textbox, string oldText, int oldSelectionStart, int oldSelectionLength)
        {
            this.oldText = oldText;
            this.oldSelectionStart = oldSelectionStart;
            this.oldSelectionLength = oldSelectionLength;
            this.newText = textbox.Text;
            this.newSelectionStart = textbox.SelectionStart;
            this.newSelectionLength = textbox.SelectionLength;
            this.textbox = textbox;
            this.timestamp = DateTime.Now;
        }

        protected override void ExecuteCore()
        {
            if (firstTime)
            {
                firstTime = false;
                return;
            }
            SetText(newText, newSelectionStart, newSelectionLength);
        }

        private void SetText(string text, int selectionStart, int selectionLength)
        {
            textbox.Text = text;
            textbox.SelectionStart = selectionStart;
            textbox.SelectionLength = selectionLength;
            textbox.Focus();
        }

        protected override void UnExecuteCore()
        {
            SetText(oldText, oldSelectionStart, oldSelectionLength);
        }

        public override bool TryToMerge(IAction followingAction)
        {
            MultilevelUndoTextboxChangeAction action = followingAction as MultilevelUndoTextboxChangeAction;
            if (action == null)
            {
                return false;
            }

            var timeDelta = action.timestamp.Subtract(this.timestamp);
            if (timeDelta.Seconds > 3)
            {
                return false;
            }

            this.newText = action.newText;
            this.newSelectionStart = action.newSelectionStart;
            this.newSelectionLength = action.newSelectionLength;
            SetText(newText, newSelectionStart, newSelectionLength);
            return true;
        }
    }
}
