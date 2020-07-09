using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _howLongGrowthSpeed;

    private bool _isReductionSpeed;
    private float _timeToReducation;
    private float _maxSpeed;
    private float _defaultSpeed;

    private void Start()
    {
        _maxSpeed = _speed * 2;
        _defaultSpeed = _speed;
    }

    private void Update()
    {
        ReductionSpeed();

        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * _speed * Time.deltaTime;
    }

    private void ReductionSpeed()
    {
        _timeToReducation -= Time.deltaTime;
        if (_timeToReducation < 0)
        {
            _isReductionSpeed = false;
            _speed = _defaultSpeed;
        }
    }

    public void GrowthSpeed()
    {
        if (_isReductionSpeed == false)
        {
            _speed = _maxSpeed;
            _isReductionSpeed = true;
            _timeToReducation = 2;
        }
    }
}
