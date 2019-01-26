using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ToolMenue : MonoBehaviour {
    [MenuItem("重置地图/放置地图")]
    public static void AddetScene()
    {
        Vector3 testVector = new Vector3();
        testVector.x = 1.28f;
        GameObject Map = GameObject.Find("Map");
        GameMap MapComp = Map.GetComponent<GameMap>();
        Transform Floors = MapComp.Floors;
        if (Floors != null)
        {
            foreach(Transform obj in Floors)
            {
                GameObject.DestroyImmediate(obj.gameObject);
            }
        }
        for (int Idx = 0; Idx < MapComp.LineNum * MapComp.Column; ++Idx)
        {
            Transform newBox = GameObject.Instantiate<Transform>(MapComp.Floor);
            newBox.SetParent(Floors);
        }
    }
    [MenuItem("重置地图/刷新地图")]
    public static void ResetScene()
    {
        Vector3 testVector = new Vector3();
        testVector.x = 1.28f;
        GameObject Map = GameObject.Find("Map");
        GameMap MapComp = Map.GetComponent<GameMap>();
        Transform Floors = MapComp.Floors;
        if (Floors != null)
        {
            foreach (Transform obj in Floors)
            {
                int Idx = MapComp.GetIdxByPosition(obj.transform.position);
                obj.name = "Floor" + Idx.ToString();
            }
        }
        
    }
    [MenuItem("重置地图/格式化玩家位置")]
    public static void SetPlayers()
    {
        Vector3 testVector = new Vector3();
        testVector.x = 1.28f;
        GameObject Map = GameObject.Find("Map");
        GameMap MapComp = Map.GetComponent<GameMap>();
        Transform Floors = MapComp.Floors;
      //  PlayerGameObj[] PlayerModel = MapComp.PlayerList;
     //   for (int Index = 0;Index< PlayerModel.Length;++Index)
      //  {
         //   Vector3 newPS = MapComp.GetPosition(PlayerModel[Index].transform.position);
        //    newPS.z = PlayerModel[Index].transform.position.z;
        //    PlayerModel[Index].transform.position = newPS;
      //  }
    }
}
