using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorsControl : MonoBehaviour
{
    [SerializeField] private Transform[] _sensors;
    [SerializeField] private Transform _parkArea;
    private float _distance = 0.15f;
    private void FixedUpdate()
    {
        RaycastHit2D hit0 = Physics2D.Raycast(_sensors[0].transform.position, _sensors[0].transform.right, _distance);
        RaycastHit2D hit1 = Physics2D.Raycast(_sensors[1].transform.position, _sensors[1].transform.right, _distance);
        RaycastHit2D hit2 = Physics2D.Raycast(_sensors[2].transform.position, _sensors[2].transform.right, _distance);
        RaycastHit2D hit3 = Physics2D.Raycast(_sensors[3].transform.position, _sensors[3].transform.right, _distance);

        if ((hit0.collider && hit1.collider != null) && (hit2.collider && hit3.collider != null))
        {
            for (int i = 0; i < _sensors.Length; i++) 
            {
                _parkArea.transform.GetComponent<Renderer>().material.color = Color.green;
                Debug.Log("LEVEL WON!");
                Debug.DrawRay(_sensors[i].transform.position, _sensors[i].transform.right * _distance, Color.green);
            }
        }
        else
        {
            for (int i = 0; i < _sensors.Length; i++)
            {
                _parkArea.transform.GetComponent<Renderer>().material.color = Color.gray;
                Debug.DrawRay(_sensors[i].transform.position, _sensors[i].transform.right * _distance, Color.red);
            }
        }
    }
}
