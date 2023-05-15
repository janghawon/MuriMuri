using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector3> _playerInput;
    [SerializeField] private UnityEvent _playerJump;

    public void InputMove()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 value = new Vector3(hor, 0, ver);
    }
}
