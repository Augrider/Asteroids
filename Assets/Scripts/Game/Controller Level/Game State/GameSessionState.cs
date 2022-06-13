using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionState : MonoBehaviour
{
    public int currentScore;
    public int currentWave;

    public ISpaceEntity player { get; set; }
    public bool isPlayerAlive => !player.state.destroyed;

    public WeaponState primary { get; set; }
    public WeaponState special { get; set; }

    private PlayerState last = new PlayerState();


    public void AdvanceWave()
    {
        currentWave++;
        UIPresenterLocator.service.SetWave(currentWave);
    }

    public void AddScore(int value)
    {
        currentScore += value;
        UIPresenterLocator.service.SetScore(currentScore);
    }


    public PlayerState GetPlayerState()
    {
        if (player != null && isPlayerAlive)
        {
            last.position = player.position.value;
            last.speed = player.movement.speed;
            last.direction = player.direction.forward;
        }

        return last;
    }
}
