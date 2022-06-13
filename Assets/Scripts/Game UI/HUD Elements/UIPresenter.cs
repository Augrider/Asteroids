using System.Collections;
using System.Collections.Generic;
using Developed.ScriptableObjects.Variables;
using UnityEngine;

public class UIPresenter : MonoBehaviour, IUIPresenter
{
    [SerializeField] private IntVariable currentWave;
    [SerializeField] private IntVariable currentScore;

    [SerializeField] private PlayerStateUI playerStateUI;
    [SerializeField] private WeaponDisplay weaponDisplay;

    [SerializeField] private Canvas hudCanvas;
    [SerializeField] private GameOverScreen gameOverScreen;


    void Awake()
    {
        UIPresenterLocator.Provide(this);
    }

    void OnDestroy()
    {
        UIPresenterLocator.Provide(null);
    }


    public void SetScore(int value)
    {
        currentScore.SetValue(value);
    }

    public void SetWave(int value)
    {
        currentWave.SetValue(value);
    }


    public void UpdatePlayerState(PlayerState playerState)
    {
        var angle = Vector2.Angle(Vector2.up, playerState.direction);
        var speed = playerState.speed.magnitude;

        playerStateUI.UpdateDisplay(playerState.position, angle, speed);
    }

    public void UpdateWeaponDisplay(WeaponState weapon)
    {
        weaponDisplay.UpdateDisplay(weapon.chargeState, weapon.maxCharges, weapon.chargeCooldown);
    }


    public void SetGameOver(int score, int wave, int highestScore, int highestWave)
    {
        hudCanvas.enabled = false;

        gameOverScreen.UpdateDisplay(score, wave, highestScore, highestWave);
    }
}