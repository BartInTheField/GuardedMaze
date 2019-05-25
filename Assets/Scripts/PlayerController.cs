using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    public event Action OnHitByEnemy;
    public event Action OnHitFinish;

    private NavMeshAgent agent;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        agent = GetComponent<NavMeshAgent>();

        gameManager.OnGameOver += GameOver;
        gameManager.OnGameFinish += GameFinish;
    }

    public void Move(Vector3 point)
    {
        agent.SetDestination(point);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherGameObject = other.gameObject;
        if (otherGameObject.CompareTag("Enemy"))
        {
            OnHitByEnemy?.Invoke();
        }

        if (otherGameObject.CompareTag("Finish"))
        {
            OnHitFinish?.Invoke();
        }
    }

    private void GameOver()
    {
        gameObject.SetActive(false);
    }

    private void GameFinish()
    {
        gameObject.SetActive(false);
    }
}