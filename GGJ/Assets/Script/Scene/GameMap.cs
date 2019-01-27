using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDir
{
    Up,
    Down,
    Left,
    Right
}

public struct Location
{
    public int x;
    public int y;
}

public class GameMap:BaseGame
{
    static int jamed = 0;
    static int player = 1;

    [Title("格子宽高", "black")]
    public float BoxWidth = 256;
    [Title("行格子数量", "black")]
    public int LineNum;
    [Title("列格子数量", "black")]
    public int Column;

    enum Type
    {
        Normal,
        Jamed,
    }

    public Transform Floors;
    public Transform Floor;

    public Floor[] FloorArray;
    public Floor GetFloorByLocation(Location location)
    {
        if(location.x<0||location.x>Column-1)
        {
            return null;
        }
        if(location.y<0||location.y>LineNum-1)
        {
            return null;
        }
        return FloorArray[GetIdxByLocation(location)];
    }
    public Floor GetFloorByIndex(int index)
    {
        return index > FloorArray.Length -1 ? null : FloorArray[index];
    }
    [Title("玩家", "black")]

    public PlayerGameObj[] PlayerList;
    public int[] PlayerLocation;

    public Location GetLocationByPS(Vector3 position)
    {
        Location location = new Location();
        float X = (position.x - BoxWidth / 2 - Floors.position.x);
        float Y = (position.y - BoxWidth / 2 - Floors.position.y);
        X = X > 0 ? Mathf.Round(X / BoxWidth) : 0;
        Y = Y > 0 ? Mathf.Round(Y / BoxWidth) : 0;
        X = X >= Column ? Column - 1 : X;
        Y = Y >= LineNum ? LineNum - 1 : Y;
        location.y = (int)Y;
        location.x = (int)X;

        return location;
    }
    public Location GetLocationByIdx(int Idx)
    {
        Location location = new Location();
        location.x = Idx % Column;
        location.y = Idx / Column;
        return location;
    }
    public int GetIdxByLocation(Location location)
    {
        location.x = location.x < 0 ? 0:location.x ;
        location.x = location.x > Column - 1 ? Column - 1:location.x;
        location.y = location.y < 0 ? 0 : location.y;
        location.y = location.y > LineNum - 1 ? LineNum - 1:location.y;
        int Idx = location.x + location.y * Column;
        return Idx;
    }
    public int GetIdxByPosition(Vector3 position)
    {
        return GetIdxByLocation( GetLocationByPS(position));
    }
    public Vector3 GetPosition(Vector3 position)
    {
        return GetPosition(GetLocationByPS(position));
    }
    public Vector3 GetPosition( Location location )
    {
        Vector3 newVector = new Vector3();
        newVector.x = location.x * BoxWidth + BoxWidth / 2;
        newVector.y = location.y * BoxWidth + BoxWidth / 2;
        return newVector;
    }
    public Vector3 GetPosition(int Idx)
    {
        return GetPosition(GetLocationByIdx(Idx));
    }
    /// <summary>
    /// 角色移动
    /// </summary>
    /// <param name="player_id">哪个玩家</param>
    /// <param name="forward">哪个方向 1_上，2_左，3_下_4_右</param>
    public void Move(int player_id,MoveDir forward)
    {
        PlayerGameObj player = PlayerList[player_id - 1];
        player.Move(forward);
    }

    
    private void Awake()
    {
        FloorArray = new Floor[Floors.transform.childCount];
        for (int Idx = 0; Idx < FloorArray.Length; Idx++)
        {
            FloorArray[Idx] = Floors.transform.GetChild(Idx).GetComponent<Floor>();
        }
        //GameCtrler.Ctrler.PlayAudio(ClipEnum.Paiper);
    }

    public override void StartSet()
    {
        GameCtrler.Ctrler.GameMap = this;
        FloorArray = GameObject.Find("Floors").GetComponentsInChildren<Floor>();
        for(int Idx = 0;Idx < FloorArray.Length;++Idx)
        {
            FloorArray[Idx].CurFloorIdx = Idx;
            FloorArray[Idx].SetMap(this);
       //     Debug.Log(FloorArray[Idx].transform.localPosition);
        }

        GameObject Map = GameObject.Find("Map");
        GameMap MapComp = Map.GetComponent<GameMap>();
        Transform Floors = MapComp.Floors;
        PlayerList = new PlayerGameObj[2];
        PlayerList[0] = GameObject.Find("PlayerOne").GetComponent<PlayerGameObj>();
        PlayerList[1] = GameObject.Find("PlayerTwo").GetComponent<PlayerGameObj>();
        PlayerGameObj[] PlayerModel = PlayerList;
        for (int Index = 0; Index < PlayerModel.Length; ++Index)
        {
            Location location = GetLocationByPS(PlayerModel[Index].transform.position);
            PlayerModel[Index].transform.position = GetPosition(location);
            PlayerModel[Index].CurFloorIdx = GetIdxByLocation(location);
            PlayerModel[Index].SetMap(this);
        }
    }
    
}
