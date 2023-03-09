using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    public static ServiceLocator Instance;

    private CommandHistory commandHistory;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("You are trying to implement a new Service Locator, only one is allowed " + gameObject);
            Destroy(gameObject);
        }
    }

    public CommandHistory GetCommandHistory()
    {
        if(commandHistory == null)
        {
            commandHistory = new CommandHistory();
        }
        
        return commandHistory;
    }
}
