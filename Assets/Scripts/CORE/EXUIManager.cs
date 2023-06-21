using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EXUIManager : MonoBehaviour
{
    [SerializeField] private GameObject GlitchFace;
    public static EXUIManager Instance;
    UIDocument _doc;
    VisualElement _root;
    VisualElement _panel;
    private void Awake()
    {
        Instance = this;
        _doc = GetComponent<UIDocument>();
        GlitchFace = GameObject.Find("GlitchFace");
        GlitchFace.SetActive(false);
        DontDestroyOnLoad(this);
    }

    public void UseGlitch(bool isUse, Vector3 pos, Vector3 rot)
    {
        GlitchFace.SetActive(isUse);
        GlitchFace.transform.position = pos;
        GlitchFace.transform.rotation = Quaternion.Euler(rot);
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
