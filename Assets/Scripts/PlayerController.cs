using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    public event Action OnHitByEnemy;
    private NavMeshAgent agent;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        agent = GetComponent<NavMeshAgent>();

        gameManager.OnGameOver += GameOver;
    }

    public void Move(Vector3 point)
    {
        agent.SetDestination(point);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            OnHitByEnemy?.Invoke();
        }
    }

    private void GameOver()
    {
        gameObject.SetActive(false);
    }
}