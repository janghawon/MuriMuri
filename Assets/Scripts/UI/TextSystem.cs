using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TextSystem : MonoBehaviour
{
    private UIDocument _uiDocument;
    VisualElement root;
    Button panel;
    Label nameTxt;
    Label sentenceTxt;

    public bool canClick;
    private void Awake()
    {
        canClick = true;
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        root = _uiDocument.rootVisualElement;
        panel = root.Q<Button>("Panel");
        nameTxt = root.Q<Label>("NameText");
        sentenceTxt = root.Q<Label>("sentenceText");

        panel.clicked += ClickEvent;
    }

    private void ClickEvent()
    {
        if(canClick)
        {
            if (SentenceManager.Instance.isTexting)
            {
                SentenceManager.Instance.LookFastText();
            }
            else
            {
                SentenceManager.Instance.NextSentence();
            }
        }
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
