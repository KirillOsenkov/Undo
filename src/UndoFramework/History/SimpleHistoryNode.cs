namespace GuiLabs.Undo
{
    /// <summary>
    /// Represents a node of the doubly linked-list SimpleHistory
    /// (StateX in the following diagram:)

    /// (State0) --- [Action0] --- (State1) --- [Action1] --- (State2)

    /// StateX (e.g. State1) has a link to the previous State, previous Action,
    /// next State and next Action.
    /// As you move from State1 to State2, an Action1 is executed (Redo).
    /// As you move from State1 to State0, an Action0 is un-executed (Undo).
    /// </summary>
    internal class SimpleHistoryNode
    {
        public SimpleHistoryNode(IAction lastExistingAction, SimpleHistoryNode lastExistingState)
        {
            PreviousAction = lastExistingAction;
            PreviousNode = lastExistingState;
        }

        public SimpleHistoryNode()
        {
        }

        public IAction PreviousAction { get; set; }
        public IAction NextAction { get; set; }
        public SimpleHistoryNode PreviousNode { get; set; }
        public SimpleHistoryNode NextNode { get; set; }
    }
}
