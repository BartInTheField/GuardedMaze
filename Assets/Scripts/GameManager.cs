using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action OnGameOver;

    [SerializeField] private LayerMask movementMask;
    [SerializeField] private PlayerController playerController;
    private new Camera camera;

    private void Start()
    {
        playerController.OnHitByEnemy += EnemyHit;
        camera = Camera.main;
    }

    private void EnemyHit()
    {
        OnGameOver?.Invoke();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                playerController.Move(hit.point);
            }
        }
    }
}