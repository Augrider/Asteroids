using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Components/Projectiles/Copy Player State")]
public class CopyPlayerState : BaseEntityBehavior
{
    [SerializeField] private bool copyPosition;
    [SerializeField] private bool copyDirection;


    public override void OnUpdate(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies, float deltaTime)
    {
        if (copyPosition)
            self.position.SetPosition(playerData.position);

        if (copyDirection)
            self.direction.SetDirection(playerData.direction);
    }
}
