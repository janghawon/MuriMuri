using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector3> _playerInput;

    public void InputMove()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 value = new Vector3(hor, 0, ver);
        _playerInput?.Invoke(value);
    }

    private void Update()
    {
        InputMove();
    }
}
