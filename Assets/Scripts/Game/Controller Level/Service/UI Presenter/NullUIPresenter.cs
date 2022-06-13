using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullUIPresenter : IUIPresenter
{
    public void UpdatePlayerState(PlayerState playerState) { }
    public void UpdateWeaponDisplay(WeaponState special) { }

    public void SetWave(int value) { }
    public void SetScore(int value) { }

    public void SetGameOver(int score, int wave, int highestScore, int highestWave) { }
}