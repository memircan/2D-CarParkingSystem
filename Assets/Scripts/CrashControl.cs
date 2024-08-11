using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashControl : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Debug.Log("Crashed");
        }
    }
}
