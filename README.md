# Undo
This is a very simple framework to add Undo/Redo functionality to your .NET applications. Supports unlimited undo-redo, nested transactions and action merging (to merge a series of consecutive and/or nested actions into one).

## NuGet:
[http://nuget.org/packages/guilabs.undo](http://nuget.org/packages/guilabs.undo)

## Sample:

    var actionManager = new ActionManager();
    var action1 = new CallMethodAction(
      () => sb.Append("execute1 "),
      () => sb.Append("unexecute1 "));
    var action2 = new CallMethodAction(
      () => sb.Append("execute2 "),
      () => sb.Append("unexecute2 "));

    actionManager.Execute(action1);
    actionManager.Execute(action2);
    actionManager.Undo();
    actionManager.Redo();

![Undo actions][1]

[1]: ActionsChart.png

## Blog posts:

 * [http://blogs.msdn.com/b/kirillosenkov/archive/2009/06/29/new-codeplex-project-a-simple-undo-redo-framework.aspx](http://blogs.msdn.com/b/kirillosenkov/archive/2009/06/29/new-codeplex-project-a-simple-undo-redo-framework.aspx)
 * [http://blogs.msdn.com/b/kirillosenkov/archive/2009/07/02/samples-for-the-undo-framework.aspx](http://blogs.msdn.com/b/kirillosenkov/archive/2009/07/02/samples-for-the-undo-framework.aspx)

Originally hosted at [http://undo.codeplex.com](http://undo.codeplex.com)
