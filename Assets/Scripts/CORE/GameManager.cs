using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using CharacterCore;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
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
        Player = GameObject.Find("Player");
        DontDestroyOnLoad(this);
    }

    public void SetConversationBefore(GameObject angleObj)
    {
        Vector3 dir = angleObj.transform.position - mainCam.transform.position;
        dir += new Vector3(0, 1, 0);
        mainCam.transform.rotation = Quaternion.LookRotation(dir);
    }
}
