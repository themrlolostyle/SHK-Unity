using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrossingChecker : MonoBehaviour
{
    [SerializeField] private GameObject _foreground;
    [SerializeField] private Player _player;
    [SerializeField] private Transform[] _enemys;
    [SerializeField] private Transform[] _upSpeedPoints;

    public event UnityAction EnemiesDied;

    private Transform _playerTransform;
    private int _enemyDieCount;

    private void Start()
    {
        _playerTransform = _player.GetComponent<Transform>();
    }

    private void Update()
    {
        CheckOnCrossing(_enemys, EnemyDie);
        CheckOnCrossing(_upSpeedPoints, UpSpeed);

        if (_enemyDieCount == _enemys.Length)
        {
            EnemiesDied?.Invoke();
        }
    }

    private void CheckOnCrossing(Transform[] transforms, UnityAction methodWhenCrossing)
    {
        foreach (var transform in transforms)
        {
            if (transform == null)
                continue;

            if (DistanceToPLayer(transform) < 0.2f)
            {
                Destroy(transform.gameObject);
                methodWhenCrossing?.Invoke();
            }
        }
    }

    private void EnemyDie()
    {
        _enemyDieCount++;
    }

    private void UpSpeed()
    {
        _player.GrowthSpeed();
    }

    private float DistanceToPLayer(Transform transform)
    {
        return Vector3.Distance(_playerTransform.position, transform.transform.position);
    }
}
