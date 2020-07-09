﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;
    private Vector3 _target;

    private void Start()
    {
        NextTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
        {
            NextTarget();
        }
    }

    private void NextTarget()
    {
        _target = Random.insideUnitCircle * _radius;
    }
}
