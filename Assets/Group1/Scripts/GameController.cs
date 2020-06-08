using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _foreground;
    [SerializeField] private Player _player;
    [SerializeField] private Transform[] _enemys;
    [SerializeField] private Transform[] _upSpeedPoints;

    private delegate void WhatToDoAtCrossing(); 
    private int _enemyDieCount;
   
    private void Update()
    {
        SearchCrossed(_enemys, EnemyDie);
        SearchCrossed(_upSpeedPoints, UpSpeed);

        if (_enemyDieCount == _enemys.Length)
        {
            End();
        }
    }

    private void SearchCrossed(Transform[] transforms, WhatToDoAtCrossing method)
    {
        foreach (var transform in transforms)
        {
            if (transform == null)
                continue;

            if (CrossedWithPlayer(transform) < 0.2f)
            {
                Destroy(transform.gameObject);
                method?.Invoke();
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

    private void End()
    {
        _foreground.SetActive(true);
        _player.enabled = false;
    }

    private float CrossedWithPlayer(Transform transform)
    {
        return Vector3.Distance(_player.gameObject.GetComponent<Transform>().position, transform.transform.position);
    }
}
