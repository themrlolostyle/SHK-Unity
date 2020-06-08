using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isReductionSpeed;
    [SerializeField] private float _timeToReducation;
   
    private void Update(){

        ReducationSpeed();

        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, _speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -_speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    private void ReducationSpeed()
    {
        if (_isReductionSpeed)
        {
            _timeToReducation -= Time.deltaTime;
            if (_timeToReducation < 0)
            {
                _isReductionSpeed = false;
                _speed /= 2;
            }
        }
    }

    public void GrowthSpeed()
    {
        _speed *= 2;
        _isReductionSpeed = true;
        _timeToReducation = 2;
    }
}
