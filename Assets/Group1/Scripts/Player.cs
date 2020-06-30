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

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += xAxis * _speed * Time.deltaTime;
        pos.y += yAxis * _speed * Time.deltaTime;
        transform.position = pos;
    }

    private void ReductionSpeed()
    {
        if (_isReductionSpeed == true)
        {
            _timeToReducation -= Time.deltaTime;
            if (_timeToReducation < 0)
            {
                _isReductionSpeed = false;
                _speed = _defaultSpeed;
            }
        }
    }

    public void GrowthSpeed()
    {
        _speed = _maxSpeed;
        _isReductionSpeed = true;
        _timeToReducation = 2;
    }
}
