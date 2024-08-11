using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsControl : MonoBehaviour
{
    [SerializeField] Transform[] _wheels;
    private Vector3 _angle;
    private float _input;
    [SerializeField] float _steeringWheelsLimit;

    private void Update()
    {
        SteeringInput();
        RotateWheels();
    }

    void SteeringInput()
    {
        _input = -Input.GetAxis("Horizontal") * _steeringWheelsLimit;
    }

    void RotateWheels()
    {
        _angle = _wheels[0].localEulerAngles;//script, parent objede oldugu icin rotasyon deðerlerini parent transformuna göre ayarlýyoruz.
        _angle = _wheels[1].localEulerAngles;
        _angle.z = _input;
        _wheels[0].localEulerAngles = _angle;
        _wheels[1].localEulerAngles = _angle;
    }
}
