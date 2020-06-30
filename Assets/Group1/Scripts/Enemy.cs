using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _radius;
    private Vector3 _target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, 2 * Time.deltaTime);
        if (transform.position == _target || _target == Vector3.zero)
            _target = Random.insideUnitCircle * _radius;
    }
}
