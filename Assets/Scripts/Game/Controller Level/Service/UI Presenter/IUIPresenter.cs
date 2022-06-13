using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIPresenter
{
    void UpdatePlayerState(PlayerState playerState);
    void UpdateWeaponDisplay(WeaponState special);

    void SetWave(int value);
    void SetScore(int value);

    void SetGameOver(int score, int wave, int highestScore, int highestWave);
}