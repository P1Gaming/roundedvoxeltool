using System.Collections;

public abstract class Command
{
    public abstract void Undo();
    public abstract void Execute();

}
public class ChangeValueCommand : Command
{
    readonly int value;
    readonly int oldValue;
    readonly MyValue myValue;

    public ChangeValueCommand(int value, MyValue myValue)
    {
        oldValue = myValue.Value;
        this.value = value;
        this.myValue = myValue;
    }
    public override void Execute()
    {
        myValue.ChangeValue(value);
    }

    public override void Undo()
    {
        myValue.ChangeValue(oldValue);
    }
}
