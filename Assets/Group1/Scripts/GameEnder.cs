using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviour
{
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private GameObject _foreground;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _collisionDetector.EnemiesDied += OnEnemiesDied;
    }

    private void OnDisable()
    {
        _collisionDetector.EnemiesDied -= OnEnemiesDied;
    }

    private void OnEnemiesDied()
    {
        _foreground.SetActive(true);
        _player.enabled = false;
    }
}

