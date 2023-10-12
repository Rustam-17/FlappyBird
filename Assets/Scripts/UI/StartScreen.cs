using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartScreen : Screen
{
    public event UnityAction StartKeyDown;

    protected override void OnButtonClick()
    {
        StartKeyDown?.Invoke();
    }
}