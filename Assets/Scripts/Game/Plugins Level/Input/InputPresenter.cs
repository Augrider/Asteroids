using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPresenter : MonoBehaviour, IInputProvider
{
    [SerializeField] private InputReceiver inputReceiver;


    void Awake()
    {
        InputLocator.Provide(this);
    }

    void OnDestroy()
    {
        InputLocator.Provide(null);
    }


    public InputData GetInputData(float maxAcceleration, float maxRotationSpeed, PlayerState playerState)
    {
        var acceleration = maxAcceleration * playerState.direction;

        return new InputData()
        {
            acceleration = inputReceiver.movementInput.y == 0 ? Vector2.zero : acceleration * Mathf.Sign(inputReceiver.movementInput.y),
            rotationSpeed = inputReceiver.movementInput.x == 0 ? 0f : maxRotationSpeed * Mathf.Sign(-inputReceiver.movementInput.x),

            shootPrimary = inputReceiver.shootPrimary,
            shootSpecial = inputReceiver.shootSpecial
        };
    }
}