using System;
using UnityEngine;

public class MyValue : MonoBehaviour
{
    private int value;

    public int Value => value;

    public Action myValueChanged;

    public void ChangeValue(int newValue)
    {
        value = newValue;
        myValueChanged?.Invoke();
    }

}