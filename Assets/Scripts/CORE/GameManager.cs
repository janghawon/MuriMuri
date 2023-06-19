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

    PlayerMove move;
    PlayerCamera cam;

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
        move = Player.GetComponent<PlayerMove>();
        cam = Player.GetComponent<PlayerCamera>();
        DontDestroyOnLoad(this);
    }

    public void SetPlayerState(bool canMove, bool canHor, bool canVer)
    {
        move.canMove = canMove;
        cam.canhor = canHor;
        cam.canver = canVer;
    }

    public void SetConversationBefore(GameObject angleObj, float val)
    {
        Vector3 dir = angleObj.transform.position - mainCam.transform.position;
        dir.Normalize();
        dir += new Vector3(0, val * 0.25f, 0);
        mainCam.transform.DORotateQuaternion(Quaternion.LookRotation(dir), 0.5f);
        //mainCam.transform.rotation = Quaternion.LookRotation(dir);
    }
}
