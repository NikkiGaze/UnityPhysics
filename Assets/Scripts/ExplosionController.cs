using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] private float _timeToExplosion;
    [SerializeField] private float _power;
    [SerializeField] private float _radius;

    private Rigidbody[] _allRigidBodies;
    private bool _exploded;
    
    private void Start()
    {
        _allRigidBodies = FindObjectsOfType<Rigidbody>();
        _exploded = false;
    }

    private void Update()
    {
        if (_exploded)
        {
            return;
        }
        _timeToExplosion -= Time.deltaTime;

        if (_timeToExplosion <= 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        foreach (var rigidBody in _allRigidBodies)
        {
            Vector3 distanceVector = rigidBody.GetComponent<Transform>().position - transform.position;
            float distance = distanceVector.magnitude;
            if (distance <= _radius)
            {
                Vector3 forceVector = distanceVector.normalized * _power * (_radius - distance);
                rigidBody.AddForce(forceVector, ForceMode.Impulse);
            }
        }
        
        _exploded = true;
    }
}
