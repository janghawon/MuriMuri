using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Chapter2BackPos pos = GameObject.Find("SchoolBackPos").GetComponent<Chapter2BackPos>();
        pos.gameObject.SetActive(false);
    }
}
