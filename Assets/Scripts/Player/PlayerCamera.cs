using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject _Player;
    [SerializeField] private float _mouseSpeed = 10;
    private float _mouseXInput;
    private float _mouseYInput;

    public bool canhor = true;
    public bool canver = true;
    public void SetMouse(float _mouseX, float _mouseY)
    {
        if(canhor)
            _mouseXInput = _mouseX * _mouseSpeed;
        if(canver)
            _mouseYInput = _mouseY * _mouseSpeed;
    }

    public void PlayerMouseCal()
    {
        if(canhor || canver)
        {
            GameManager.Instance.mainCam.gameObject.transform.rotation = Quaternion.Euler(-_mouseYInput, _mouseXInput, 0);
        }
    }

    private void Update()
    {
        PlayerMouseCal();
    }
}
