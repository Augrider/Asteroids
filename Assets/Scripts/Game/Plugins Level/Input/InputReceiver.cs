using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReceiver : MonoBehaviour
{
    public Vector2 movementInput { get; private set; }
    public bool shootPrimary { get; private set; } = false;
    public bool shootSpecial { get; private set; } = false;

    private PlayerActions playerActions;


    void Awake()
    {
        InputSubscribe();
    }

    void onDestroy()
    {
        InputUnsubscribe();
    }


    public void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnShootBullet(InputAction.CallbackContext context)
    {
        shootPrimary = !shootPrimary;
    }

    public void OnShootLaser(InputAction.CallbackContext context)
    {
        shootSpecial = !shootSpecial;
    }



    private void InputSubscribe()
    {
        if (playerActions == null)
            playerActions = new PlayerActions();

        playerActions.Spaceship.Movement.started += OnMovement;
        playerActions.Spaceship.Movement.performed += OnMovement;
        playerActions.Spaceship.Movement.canceled += OnMovement;

        playerActions.Spaceship.ShootBullet.started += OnShootBullet;
        playerActions.Spaceship.ShootBullet.canceled += OnShootBullet;

        playerActions.Spaceship.ShootLaser.started += OnShootLaser;
        playerActions.Spaceship.ShootLaser.canceled += OnShootLaser;

        playerActions.Spaceship.Enable();
    }

    private void InputUnsubscribe()
    {
        playerActions.Spaceship.Movement.started -= OnMovement;
        playerActions.Spaceship.Movement.performed -= OnMovement;
        playerActions.Spaceship.Movement.canceled -= OnMovement;

        playerActions.Spaceship.ShootBullet.started -= OnShootBullet;
        playerActions.Spaceship.ShootBullet.canceled -= OnShootBullet;

        playerActions.Spaceship.ShootLaser.started -= OnShootLaser;
        playerActions.Spaceship.ShootLaser.canceled -= OnShootLaser;

        playerActions.Spaceship.Disable();
    }
}