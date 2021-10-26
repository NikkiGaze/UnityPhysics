using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    [SerializeField] private float _force;
    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody)
        {
            Vector3 forceVector = (other.transform.position - transform.position).normalized;
            other.rigidbody.AddForce(forceVector * _force, ForceMode.Impulse);
        }
    }
}
