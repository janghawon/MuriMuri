using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TextSystem : MonoBehaviour
{
    private UIDocument _uiDocument;
    VisualElement root;
    VisualElement panel;
    Label nameTxt;
    Label sentenceTxt;
    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        root = _uiDocument.rootVisualElement;
        panel = root.Q<VisualElement>("Panel");
        nameTxt = root.Q<Label>("NameText");
        sentenceTxt = root.Q<Label>("sentenceText");
    }

    public void TextRendering(string name, string sentence)
    {
        nameTxt.text = name;
        sentenceTxt.text = sentence;
    }

    public void SetPanel(bool isOnPanel)
    {
        if(isOnPanel)
        {
            panel.RemoveFromClassList("on");
        }
        else
        {
            panel.AddToClassList("on");
        }
    }
}
