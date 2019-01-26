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

       // FloorArray = GameObject.Find("Floors").GetComponentInChildren<Floor>();

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
            newPS.x = MapComp.BoxWidth / 2 + X * MapComp.BoxWidth;// +Floors.position.x;
            newPS.y = MapComp.BoxWidth / 2 + Y * MapComp.BoxWidth;// +Floors.position.y;

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
        GameObject Map = GameObject.Find("Map");
        GameMap MapComp = Map.GetComponent<GameMap>();

        InputListener.isMove = false;
        
        Vector3 oldPS = PlayerModels[player_id-1].transform.position;

        Debug.Log("oldPS is "+oldPS);
        Vector3 newPS=oldPS;          //应移动的位置
        switch (forward)
        {
            case 1:
            newPS.y =oldPS.y+ MapComp.BoxWidth ;//+ Y * MapComp.BoxWidth;
                break;
            case 2:
                newPS.x = oldPS.x - MapComp.BoxWidth  ;//- X * MapComp.BoxWidth;
                break;
            case 3:
                newPS.y = oldPS.y - MapComp.BoxWidth  ;//- Y * MapComp.BoxWidth;
                break;
            case 4:
                newPS.x = oldPS.x + MapComp.BoxWidth  ;//+ X * MapComp.BoxWidth;
                break;
            default:
                break;
        };
        PlayerModels[player_id-1].transform.position = newPS;
        Debug.Log(" PlayerModels["+player_id+"].transform.position   is " + PlayerModels[player_id - 1].transform.position);

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
