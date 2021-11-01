using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PinStart : MonoBehaviour
{
    [SerializeField] private float _cooldown;
    [SerializeField] private float _tensionDuration;
    [SerializeField] private Transform _baseTransform;
    
    private float _startTime;
    private float _lastTime;
    private Vector3 _directionVector;

    private bool _isInTensionProcess;
    private void Start()
    {
        _lastTime = 0;
        _startTime = 0;
        _directionVector = (_baseTransform.position - transform.position).normalized;
        _isInTensionProcess = false;
    }

    private void FixedUpdate()
    {
        float currentTime = Time.time;
        if (_isInTensionProcess)
        {
            if (currentTime - _startTime >= _tensionDuration)
            {
                _isInTensionProcess = false;
                _lastTime = currentTime;
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(_directionVector * 22000);
            }
        }
        else if (currentTime - _lastTime >= _cooldown)
        {
            _isInTensionProcess = true;
            _startTime = currentTime;
        }
    }
}
