namespace GuiLabs.Undo
{
    /// <summary>
    /// Encapsulates a user action (actually two actions: Do and Undo)
    /// Can be anything.
    /// You can give your implementation any information it needs to be able to
    /// execute and rollback what it needs.
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// Apply changes encapsulated by this object.
        /// </summary>
        /// <remarks>
        /// ExecuteCount++
        /// </remarks>
        void Execute();

        /// <summary>
        /// Undo changes made by a previous Execute call.
        /// </summary>
        /// <remarks>
        /// ExecuteCount--
        /// </remarks>
        void UnExecute();

        /// <summary>
        /// For most Actions, CanExecute is true when ExecuteCount = 0 (not yet executed)
        /// and false when ExecuteCount = 1 (already executed once)
        /// </summary>
        /// <returns>true if an encapsulated action can be applied</returns>
        bool CanExecute();

        /// <returns>true if an action was already executed and can be undone</returns>
        bool CanUnExecute();

        /// <summary>
        /// Attempts to take a new incoming action and instead of recording that one
        /// as a new action, just modify the current one so that it's summary effect is 
        /// a combination of both.
        /// </summary>
        /// <param name="followingAction"></param>
        /// <returns>true if the action agreed to merge, false if we want the followingAction
        /// to be tracked separately</returns>
        bool TryToMerge(IAction followingAction);

        /// <summary>
        /// Defines if the action can be merged with the previous one in the Undo buffer
        /// This is useful for long chains of consecutive operations of the same type,
        /// e.g. dragging something or typing some text
        /// </summary>
        bool AllowToMergeWithPrevious { get; set; }
    }
}
