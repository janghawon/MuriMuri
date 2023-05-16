using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector3> _playerInput;
    [SerializeField] private UnityEvent<float, float> MouseInput;

    private float mouseX;
    private float mouseY;
    public void InputMove()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 value = new Vector3(hor, 0, ver);
        _playerInput?.Invoke(value);
    }

    private void ScreenRotateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");

        mouseY = Mathf.Clamp(mouseY, -8, 11f);

        MouseInput?.Invoke(mouseX, mouseY);
    }

    private void Update()
    {
        InputMove();
        ScreenRotateUpdate();
    }
}
