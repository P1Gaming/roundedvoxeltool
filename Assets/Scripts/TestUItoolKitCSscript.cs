using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TestUItoolKitCSscript : MonoBehaviour, IPointerDownHandler
{
    CommandHistory commandHistory;
    UIDocument mainwindow;
    [SerializeField] MyValue valueHolder;
    VisualElement visual;
    Label lable;

    private void Start()
    {
        commandHistory = ServiceLocator.Instance.GetCommandHistory();

        mainwindow = GetComponent<UIDocument>();
        var element = mainwindow.rootVisualElement;
        var changeValueButton = mainwindow.rootVisualElement.Q<Button>("ChangeValueButton");
        var undoButton = mainwindow.rootVisualElement.Q<Button>("UndoButton");
        var redoButton = mainwindow.rootVisualElement.Q<Button>("RedoButton");

        redoButton.clicked += HandleRedoButtonClicked;


        lable = mainwindow.rootVisualElement.Q<Label>("ValueVisual");
        valueHolder.myValueChanged += handleChangedValue;
        changeValueButton.clicked += ChangeValue;
        undoButton.clicked += Undo;
        visual = mainwindow.rootVisualElement.Q<VisualElement>("window");
        visual.AddManipulator(new DragManipulator());
        visual.RegisterCallback<DropEvent>(evt =>
          Debug.Log($"{evt.target} dropped on {evt.droppable}"));
    }

    private void HandleRedoButtonClicked()
    {
        commandHistory.Redo();
    }

    private void handleChangedValue()
    {
        lable.text = valueHolder.Value.ToString();
    }

    private void Undo()
    {
        commandHistory.Undo();
    }

    private void ChangeValue()
    {
        var randValue = UnityEngine.Random.Range(0, 20);
        var changeValueAction = new ChangeValueCommand(randValue, valueHolder);
        commandHistory.RecordCommand(changeValueAction);

    }
    private void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked somewhere");
    }
}


