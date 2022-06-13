using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameContext gameContext;


    public void SetPlayerShip(PlayerData value) => gameContext.playerData = value;
}
