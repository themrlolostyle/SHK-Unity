using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private GameObject _foreground;
    [SerializeField] private Player _player;
    [SerializeField] private float collisionRadius = 0.2f;
    [SerializeField] private List<Transform> _enemies;
    [SerializeField] private List<Transform> _upSpeedPoints;
    
    public event UnityAction EnemiesDied;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = _player.GetComponent<Transform>();
    }

    private void Update()
    {
        CheckOnCrossing(_enemies, CheckOnAllEnemiesDie);
        CheckOnCrossing(_upSpeedPoints, UpSpeed);
    }

    private void CheckOnCrossing(List<Transform> transforms, UnityAction onCrossing)
    {
        foreach (var transform in transforms)
        {
            if (Vector3.Distance(_playerTransform.position, transform.transform.position) < collisionRadius)
            {
                transforms.Remove(transform);
                Destroy(transform.gameObject);
                onCrossing?.Invoke();
            }
        }
    }

    private void CheckOnAllEnemiesDie()
    {
        if (_enemies.Count <= 0)
        {
            EnemiesDied?.Invoke();
        }
    }

    private void UpSpeed()
    {
        _player.GrowthSpeed();
    }
}
