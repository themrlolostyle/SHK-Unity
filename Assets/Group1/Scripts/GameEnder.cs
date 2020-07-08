using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviour
{
    [SerializeField] private CrossingChecker _crossingChecker;
    [SerializeField] private GameObject _foreground;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _crossingChecker.EnemiesDied += OnEnemiesDied;
    }

    private void OnDisable()
    {
        _crossingChecker.EnemiesDied -= OnEnemiesDied;
    }

    private void OnEnemiesDied()
    {
        _foreground.SetActive(true);
        _player.enabled = false;
    }
}

