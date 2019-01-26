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
            Debug.Log("X is " + X);
            Debug.Log("y is " + Y);
            Vector3 newPS = PlayerModel[Index].transform.position;
            newPS.x = MapComp.BoxWidth / 2 + X * MapComp.BoxWidth + Floors.position.x;
            newPS.y = MapComp.BoxWidth / 2 + Y * MapComp.BoxWidth + Floors.position.y;
            Debug.Log(" newPS.x  is " + newPS.x);
            Debug.Log("  newPS.y  is " + newPS.y);
            PlayerModel[Index].transform.position = newPS;
            PlayerLocation[Index] = (int)Y * Column + (int)X;

            Debug.Log("Index is "+Index);
            /*foreach (object i in PlayerLocation)
            {
                int j = 0;
                Debug.Log(j+" is "+i);
                j++;
            }*/
        }
      
    }


    /// <summary>
    /// 角色移动
    /// </summary>
    /// <param name="player_id">哪个玩家</param>
    /// <param name="forward">哪个方向 1_上，2_左，3_下_4_右</param>
    public void Move(int player_id,int forward)
    {
        InputListener.isMove = false;

        
        Vector3 oldPS = PlayerModels[player_id - 1].transform.position;



        Debug.Log("oldPS is "+oldPS);
        float X;          //应移动的位置的X
        float Y;          //应移动的位置的Y
        Vector3 newPS=Vector3.zero;          //应移动的位置
        switch (forward)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        };
        PlayerModels[player_id-1].transform.position = newPS;

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
