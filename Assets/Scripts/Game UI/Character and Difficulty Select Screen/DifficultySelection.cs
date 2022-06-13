using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelection : MonoBehaviour
{
    [SerializeField] private GameContext gameContext;


    public void SetDifficulty(GameDifficulty value) => gameContext.gameDifficulty = value;
}
