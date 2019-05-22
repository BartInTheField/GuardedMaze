using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GuardController : MonoBehaviour
{
    [SerializeField] private GameObject destination;

    private Vector3 destinationPosition;
    private Vector3 originalPosition;
    private NavMeshAgent agent;

    private void Start()
    {
        originalPosition = transform.position;
        destinationPosition = destination.transform.position;

        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
        if (IsOnPosition(destinationPosition))
        {
            Move(originalPosition);
        }

        if (IsOnPosition(originalPosition))
        {
            Move(destinationPosition);
        }
    }

    private void Move(Vector3 point)
    {
        agent.SetDestination(point);
    }

    private bool IsOnPosition(Vector3 position)
    {
        return Vector3.Distance(transform.position, position) < 0.1f;
    }
}