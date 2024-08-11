using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] WheelAnimate _animateWheels;

    [SerializeField] float _carSpeed;
    [SerializeField] float _streeringSpeed;

    float _verticalInput;
    float _horizontalInput;
    float _direction;
    float _animateWheelsValue = 0.1f;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CarMovement();
    }

    void CarMovement()
    {
        _verticalInput = Input.GetAxis("Vertical")* _carSpeed;
        _horizontalInput = -Input.GetAxis("Horizontal") * _streeringSpeed;
        _direction = Mathf.Sign(Vector2.Dot(_rb.velocity, _rb.GetRelativeVector(Vector2.up)));
        //Mathf.Sign: nokta �arp�m�n�n i�aretini belirler. sonuc pozitifse 1, de�ilse -1 d�nd�r�r.
        //GetRelativeVector : araban�n �u anki rotasyonuna g�re "ileri" y�n�n�n d�nya uzay�nda hangi y�ne kar��l�k geldi�ini belirler.
        //Dot product: iki vekt�r aras�ndaki a��y� bulmak i�in.

        _animateWheels.MoveWheels(-_verticalInput * _animateWheelsValue);       

        _rb.rotation += _horizontalInput*_direction * _rb.velocity.magnitude;//dururken d�nmemesi i�in anl�k vekt�r b�y�kl��� ile �arp�yoruz
        _rb.AddRelativeForce(_verticalInput * Vector2.up);
    }

}
