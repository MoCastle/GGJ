using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ToolMenue : MonoBehaviour {
    [MenuItem("重置地图/重置地图")]
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
            Vector3 newPS = newBox.transform.position;
            float x = MapComp.BoxWidth / 2 + (Idx % MapComp.LineNum) * MapComp.BoxWidth;
            newPS.x = x;
            float y = MapComp.BoxWidth / 2 + ((Idx / MapComp.LineNum) % MapComp.Column) * MapComp.BoxWidth;
            newPS.y = y;
            newBox.transform.position = newPS;
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
        Transform[] PlayerModel = MapComp.PlayerModels;
        for (int Index = 0;Index< PlayerModel.Length;++Index)
        {
            float X = (PlayerModel[Index].transform.position.x - MapComp.BoxWidth/2 - Floors.position.x);
            float Y = (PlayerModel[Index].transform.position.y - MapComp.BoxWidth/2 - Floors.position.y);
            X = X > 0 ? Mathf.Floor(X / MapComp.BoxWidth) : 0;
            Y = Y > 0 ? Mathf.Floor(Y / MapComp.BoxWidth): 0;
            Vector3 newPS = PlayerModel[Index].transform.position;
            newPS.x = MapComp.BoxWidth/2+X * MapComp.BoxWidth + Floors.position.x;
            newPS.y = MapComp.BoxWidth/2 + Y * MapComp.BoxWidth + Floors.position.y;
            PlayerModel[Index].transform.position = newPS;
        }
    }
}
