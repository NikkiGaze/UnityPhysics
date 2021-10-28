using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PinStart : MonoBehaviour
{
    [SerializeField] private float _cooldown;

    private float _lastTime;
    private void Start()
    {
        _lastTime = 0;
    }

    private void Update()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 30000);
        // if (Time.time - _lastTime >= _cooldown)
        // {
        //     // transform.position = transform.position - new Vector3(0, 0, 0.5f);
        //     GetComponent<Rigidbody>().AddForce(Vector3.forward * 10000);
        //     _lastTime = Time.time;
        //     Debug.Log("St");
        // }
    }
}
