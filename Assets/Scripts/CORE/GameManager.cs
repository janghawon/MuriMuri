using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Camera mainCam;
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("���ӸŴ����� ���� �� ! ! !");
        }
        else
        {
            Instance = this;
        }
        mainCam = Camera.main;
        Cursor.visible = false;
        DontDestroyOnLoad(this);
    }
}
