using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap:BaseGame
{
    [Title("格子宽高", "black")]
    public float BoxWidth = 256;
    [Title("行格子数量", "black")]
    public int LineNum;
    [Title("行格子数量", "black")]
    public int Column;

    public Transform Floors;
    public Transform Floor;

    public Floor[] FloorArray;
    [Title("玩家", "black")]
    public Transform[] PlayerModels;
    public int[] PlayerLocation;

    // Start is called before the first frame update
    public override void StartSet()
    {
        Vector3 testVector = new Vector3();
        testVector.x = 1.28f;

        PlayerLocation = new int[2];
        GameObject Map = GameObject.Find("Map");
        GameMap MapComp = Map.GetComponent<GameMap>();
        Transform Floors = MapComp.Floors;
        Transform[] PlayerModel = MapComp.PlayerModels;
        for (int Index = 0; Index < PlayerModel.Length; ++Index)
        {
            float X = (PlayerModel[Index].transform.position.x - MapComp.BoxWidth / 2 - Floors.position.x);
            float Y = (PlayerModel[Index].transform.position.y - MapComp.BoxWidth / 2 - Floors.position.y);
            X = X > 0 ? Mathf.Floor(X / MapComp.BoxWidth) : 0;
            Y = Y > 0 ? Mathf.Floor(Y / MapComp.BoxWidth) : 0;
            Vector3 newPS = PlayerModel[Index].transform.position;
            newPS.x = MapComp.BoxWidth / 2 + X * MapComp.BoxWidth + Floors.position.x;
            newPS.y = MapComp.BoxWidth / 2 + Y * MapComp.BoxWidth + Floors.position.y;
            PlayerModel[Index].transform.position = newPS;
            PlayerLocation[Index] = (int)Y * Column + (int)X;
        }
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
