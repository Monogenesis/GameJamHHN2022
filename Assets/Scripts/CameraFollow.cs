using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject followTarget;

    private Vector3 _position;

    private void Awake()
    {
        _position = transform.position;
    }

    void Update()
    {
        if (followTarget)
        {
            _position.x = followTarget.transform.position.x;
            _position.y = followTarget.transform.position.y;

            transform.position = _position;
        }
    }
}