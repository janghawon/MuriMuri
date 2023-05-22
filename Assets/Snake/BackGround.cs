using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] Vector3 upPos;
    [SerializeField] Vector3 downPos;
    public float speed;
    private void Update()
    {
        this.transform.Translate(new Vector3(0, -0.1f * speed, 0), Space.World);
        if(this.transform.position.y <= downPos.y)
        {
            this.transform.position += new Vector3(0, 60, 0);
        }
    }
}
