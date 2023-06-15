using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEventManager : MonoBehaviour
{
    public void FirstCustom()
    {
        GameManager.Instance.SetPlayerState(true, true, true);
    }
}
