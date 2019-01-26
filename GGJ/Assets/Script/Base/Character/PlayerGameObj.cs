using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameObj : MapObj
{
    [Title("禁止垂直运动", "black")]
    public bool VForbid;
    [Title("禁止水平运动", "black")]
    public bool HForbid;
    int[] _Location;
    public bool Move(MoveDir forward,bool Pushed = false)
    {
        GameMap map = _Map;
        InputListener.isMove = false;

        Location location = Location;

        Vector3 oldPS = transform.position;

        Debug.Log("oldPS is " + oldPS);
        switch (forward)
        {
            //上
            case MoveDir.Up:
                if (VForbid&& !Pushed)
                    return false;
                location.y += 1;
                break;
            //左
            case MoveDir.Left:
                if (HForbid && !Pushed)
                    return false;
                location.x -= 1;
                break;
            //下
            case MoveDir.Down:
                if (VForbid && !Pushed)
                    return false;
                location.y -= 1;
                break;
            //右
            case MoveDir.Right:
                if (HForbid && !Pushed)
                    return false;
                location.x += 1;
                break;
            default:
                break;
        };
        Floor floor = _Map.GetFloorByLocation(location);
        if (floor == null)
        {
            return false;
        }
        else if (floor.Type == FloorType.Jamed)
        {
            return false;
        }
        //检查下一步有没有角色
        foreach (PlayerGameObj playerObj in _Map.PlayerList)
        {
            if (playerObj!=this&&playerObj.CurFloorIdx == _Map.GetIdxByLocation(location))
            {
                if( playerObj.Move(forward,true))
                {
                    _MoveEnd(location);
                    return true;
                }else
                {
                    return false;
                }
            }
        }
        _MoveEnd(location);
        return true;
    }
    void _MoveEnd(Location location)
    {
        CurFloorIdx = _Map.GetIdxByLocation(location);
        transform.position = _Map.GetPosition(CurFloorIdx);
    }
}
