using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float _mouseSpeed = 10;
    private float _mouseXInput;
    private float _mouseYInput;

    public void SetMouse(float _mouseX, float _mouseY)
    {
        _mouseXInput = _mouseX * _mouseSpeed;
        _mouseYInput = _mouseY * _mouseSpeed;
    }
    public void PlayerMouseCal()
    {
        GameManager.Instance.mainCam.gameObject.transform.rotation = Quaternion.Euler(-_mouseYInput, _mouseXInput, 0);
    }

    private void Update()
    {
        PlayerMouseCal();
    }
}
