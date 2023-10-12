using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected GameObject ButtonObject;

    protected Button Button;

    private void Awake()
    {
        Button = ButtonObject.GetComponent<Button>();
    }

    private void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClick);
    }

    internal virtual void Open()
    {
        CanvasGroup.alpha = 1;
        ButtonObject.SetActive(true);
    }

    internal virtual void Close()
    {
        CanvasGroup.alpha = 0;
        ButtonObject.SetActive(false);
    }

    protected abstract void OnButtonClick();
}