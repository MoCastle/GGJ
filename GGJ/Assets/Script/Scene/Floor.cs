using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FloorType
{
    Normal,
    Jamed
}
public class Floor : MapObj
{
    public FloorType Type;
    public void Touched()
    { }
}

public enum TapeDir
{
    Left,
    Right
}
public class Tape:Floor
{
    public TapeDir TapeDirection;

}
public class GamePoint:Floor
{
    public void Touched()
    {
        PlayerGameObj[] PlayerList = _Map.PlayerList;
        Location pointLocation = _Map.GetLocationByIdx(_CurFloorIdx);
        Location pOne = _Map.GetLocationByIdx(PlayerList[0].CurFloorIdx);
        Location pTwo = _Map.GetLocationByIdx(PlayerList[1].CurFloorIdx);
        if(CheckLocation(pOne)&&CheckLocation(pTwo))
        {

        }
    }
    //检查一个角色在不在九宫格内
    public bool CheckLocation( Location checkTarget )
    {
        Location location = _Map.GetLocationByIdx(_CurFloorIdx);
        if(location.x-1>checkTarget.x || location.x+1<checkTarget.x)
        {
            return false;
        }
        if(location.y-1>checkTarget.y||location.y+1<checkTarget.y)
        {
            return false;
        }
        return true;
    }
}
