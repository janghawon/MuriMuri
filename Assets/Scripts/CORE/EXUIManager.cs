using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EXUIManager : MonoBehaviour
{
    public static EXUIManager Instance;
    UIDocument _doc;
    VisualElement _root;
    VisualElement _panel;
    private void Awake()
    {
        Instance = this;
        _doc = GetComponent<UIDocument>();
        DontDestroyOnLoad(this);
    }

    public void FadePanel(bool isUp)
    {
        if (isUp)
            _panel.AddToClassList("on");
        else
            _panel.RemoveFromClassList("on");
    }

    public void SetPanelColor(Color co)
    {
        _panel.style.backgroundColor = co;
    }

    private void OnEnable()
    {
        _root = _doc.rootVisualElement;
        _panel = _root.Q<VisualElement>("FadePanel");
    }
}
