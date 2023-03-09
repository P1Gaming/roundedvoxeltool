using System.Collections.Generic;
using UnityEngine;

public class CommandHistory
{
    private readonly Stack<Command> commandUndoStack = new Stack<Command>();
    private readonly Stack<Command> commandRedoStack = new Stack<Command>();
    bool UndoAvailable => commandUndoStack.Count > 0;
    bool RedoAvailable => commandRedoStack.Count > 0;

    public void RecordCommand(Command command)
    {
        commandRedoStack.Clear();
        commandUndoStack.Push(command);
        command.Execute();
    }

    public void Undo()
    {

        if (!UndoAvailable)
            return;

        var undoCommand = commandUndoStack.Pop();
        commandRedoStack.Push(undoCommand);
        undoCommand.Undo();
    }
    public void Redo()
    {
        if (!RedoAvailable)
            return;

        var redoCommand = commandRedoStack.Pop();
        commandUndoStack.Push(redoCommand);
        redoCommand.Execute();
    }

}