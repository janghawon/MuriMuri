using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCore;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject mainCam;
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("게임매니저가 공명 중 ! ! !");
        }
        else
        {
            Instance = this;
        }
        Cursor.visible = false;
        DontDestroyOnLoad(this);
    }
}
