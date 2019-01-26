using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tape : Floor
{
    float _CountTime;
    [Title("传送方向", "black")]
    public MoveDir MoveDirection;

    public override void Touched()
    {
        PlayerGameObj stepPlayer;
        foreach( PlayerGameObj player in _Map.PlayerList )
        {
            if(player.CurFloorIdx == _CurFloorIdx)
            {
                SetDirty();
                stepPlayer = player;
                /*
                if( !stepPlayer.Move(MoveDirection,true))
                {
                }*/
                if(stepPlayer.DelayRun == null)
                {
                    stepPlayer.SetDelayRun(()=> { stepPlayer.Move(MoveDirection,true); });
                }
            }
        }
    }
}
