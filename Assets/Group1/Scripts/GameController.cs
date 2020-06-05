using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    [SerializeField] private GameObject _foreground;
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform[] _enemys;

    private void Start()
    {
        controller = this;
    }

    public void End()
    {
        _foreground.SetActive(true);
    }

    private void Update(){
        foreach (var enemy in _enemys)
        {
            if (enemy == null)
                continue;

                if (Vector3.Distance(_player.gameObject.gameObject.GetComponent<Transform>().position, enemy.transform.position) < 0.2f)
                {
                    _player.SendMessage("SendMEssage", enemy);
                }

        }
    }
}
