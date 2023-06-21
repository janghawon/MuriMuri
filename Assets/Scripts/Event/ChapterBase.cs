using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChapterBase : MonoBehaviour
{
    public bool isStart;
    protected float distance;

    protected abstract void Awake();

    private void Start()
    {
        isStart = true;
    }

    protected abstract void ActionEvent();

    private void Update()
    {
        if(isStart && Vector3.Distance(GameManager.Instance.Player.transform.position, this.transform.position) < distance)
        {
            isStart = false;
            ActionEvent();
        }
    }
}
