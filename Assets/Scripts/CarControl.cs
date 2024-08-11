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
        //Mathf.Sign: nokta çarpýmýnýn iþaretini belirler. sonuc pozitifse 1, deðilse -1 döndürür.
        //GetRelativeVector : arabanýn þu anki rotasyonuna göre "ileri" yönünün dünya uzayýnda hangi yöne karþýlýk geldiðini belirler.
        //Dot product: iki vektör arasýndaki açýyý bulmak için.

        _animateWheels.MoveWheels(-_verticalInput * _animateWheelsValue);       

        _rb.rotation += _horizontalInput*_direction * _rb.velocity.magnitude;//dururken dönmemesi için anlýk vektör büyüklüðü ile çarpýyoruz
        _rb.AddRelativeForce(_verticalInput * Vector2.up);
    }

}
