using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Location
{
    public int x;
    public int y;
}

public class GameMap:BaseGame
{
    [Title("格子宽高", "black")]
    public float BoxWidth = 256;
    [Title("行数量", "black")]
    public int LineNum;
    [Title("行格子数量", "black")]
    public int Column;

    public Transform Floors;
    public Transform Floor;

    public Floor[] FloorArray;
    public Floor GetFoorByIdx(int Idx)
    {
        
        return Idx>FloorArray.Length-1? null: FloorArray[Idx];
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

    // Start is called before the first frame update
    public override void StartSet()
    {

       // FloorArray = GameObject.Find("Floors").GetComponentInChildren<Floor>();

        Vector3 testVector = new Vector3();
        testVector.x = 1.28f;

        PlayerLocation = new int[2];
        GameObject Map = GameObject.Find("Map");
        GameMap MapComp = Map.GetComponent<GameMap>();
        Transform Floors = MapComp.Floors;
        PlayerGameObj[] PlayerModel = MapComp.PlayerList;
        for (int Index = 0; Index < PlayerModel.Length; ++Index)
        {
            Location location = GetLocationByPS(PlayerModel[Index].transform.position);
            Vector3 newPS = GetPosition(location);
            newPS.z = PlayerModel[Index].transform.position.z;
            PlayerModel[Index].transform.position = newPS;
            PlayerLocation[Index] = GetIdxByLocation(location);
        }
      
    }
    public enum MoveDir
    {
        Up,
        Left,
        Down,
        Right
    }

    /// <summary>
    /// 角色移动
    /// </summary>
    /// <param name="player_id">哪个玩家</param>
    /// <param name="forward">哪个方向 1_上，2_左，3_下_4_右</param>
    public void Move(int player_id,int forward)
    {

        InputListener.isMove = false;

        Location location = GetLocationByIdx(PlayerLocation[player_id-1]);

        Vector3 oldPS = PlayerList[player_id-1].transform.position;

        Debug.Log("oldPS is "+oldPS);
        switch (forward)
        {
            //上
            case 1:
                location.y += 1;
                break;
            //左
            case 2:
                location.x -= 1;
                break;
            //下
            case 3:
                location.y -= 1;
                break;
            //右
            case 4:
                location.x += 1;
                break;
            default:
                break;
        };
        int newIdx = GetIdxByLocation(location);
        PlayerLocation[player_id - 1] = GetIdxByLocation(location);
        Floor TargetFloor = GetFoorByIdx(newIdx) ;
        if(!TargetFloor)
        {
            return;
        }
        PlayerList[player_id-1].transform.position = FloorArray[newIdx].transform.position;
        Debug.Log(" PlayerModels["+player_id+"].transform.position   is " + PlayerList[player_id - 1].transform.position);
    }

    private void Awake()
    {
        FloorArray = new Floor[Floors.transform.childCount];
        for (int Idx = 0; Idx < FloorArray.Length; Idx++)
        {
            FloorArray[Idx] = Floors.transform.GetChild(Idx).GetComponent<Floor>();
        }
    }
    
}
