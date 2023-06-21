using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    UIDocument _doc;
    VisualElement _root;
    Button _start;
    Button _exit;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

    }
    private void Start()
    {
        GameManager.Instance.SetPlayerState(false, false, false);
        UnityEngine.Cursor.visible = true;
    }

    private void OnEnable()
    {
        _root = _doc.rootVisualElement;
        _start = _root.Q<Button>("StartBtn");
        _exit = _root.Q<Button>("ExitBtn");

        _start.clicked += Startt;
        _exit.clicked += () => Application.Quit();
    }

    private void Startt()
    {
        CharacterController cc = GameManager.Instance.Player.GetComponent<CharacterController>();
        cc.enabled = false;
        GameManager.Instance.Player.transform.position = new Vector3(-4.47f, -0.45f, 15.4f);
        cc.enabled = true;
        UnityEngine.Cursor.visible = false;
        GameManager.Instance.SetPlayerState(true, true, true);
        this.gameObject.SetActive(false);
    }
}
