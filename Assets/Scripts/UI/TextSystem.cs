using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TextSystem : MonoBehaviour
{
    private UIDocument _uiDocument;
    VisualElement root;
    VisualElement panel;
    bool isOnPanel;
    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        root = _uiDocument.rootVisualElement;
        panel = root.Q<VisualElement>("Panel");
    }

    public void SetPanel()
    {
        if(isOnPanel)
        {
            panel.RemoveFromClassList("on");
        }
        else
        {
            panel.AddToClassList("on");
        }
        isOnPanel = !isOnPanel;
    }
}
