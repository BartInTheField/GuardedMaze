using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = System.Object;

public class GameManager : MonoBehaviour
{
    public event Action OnGameOver;
    public event Action OnGameFinish;

    [SerializeField] private LayerMask movementMask;
    [SerializeField] private PlayerController playerController;
    private new Camera camera;

    private void Start()
    {
        playerController.OnHitByEnemy += GameOver;
        playerController.OnHitFinish += GameFinish;
        camera = Camera.main;
    }

    private void GameFinish()
    {
        OnGameFinish?.Invoke();
    }

    private void GameOver()
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