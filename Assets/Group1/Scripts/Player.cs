using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _howLongGrowthSpeed;

    private float _timeToReducation;
    private float _defaultSpeed;
    private int _growthBonusCount;

    private void Start()
    {
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
            if (_growthBonusCount > 0)
            {
                _growthBonusCount--;
                NewSpeed();
            }
            else
            {
                _speed = _defaultSpeed;
            }
        }
    }

    public void GrowthSpeed()
    {
        _growthBonusCount++;
        NewSpeed();
    }

    private void NewSpeed()
    {
        _speed = _defaultSpeed * (1 + _growthBonusCount);
        _timeToReducation = 2;
    }
}
