using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ToolMenue : MonoBehaviour {
    [MenuItem("重置地图/重置")]
    public static void AddetScene()
    {
        GameObject Map = GameObject.Find("Map");
        GameMap MapComp = Map.GetComponent<GameMap>();
        Transform Floors = Map.transform.Find("Floors");
        if (Floors != null)
        {
            foreach(Transform obj in Floors)
            {
                GameObject.DestroyImmediate(obj.gameObject);
            }
        }
        float startX = MapComp.BoxWidth / 2;
        float startY = MapComp.BoxWidth / 2;
        for (int Idx = 0; Idx < MapComp.LineNum * MapComp.Column; ++Idx)
        {
            Transform newBox = GameObject.Instantiate<Transform>(MapComp.Floor);
            newBox.SetParent(Floors);
            Vector3 newPS = newBox.transform.position;
            newPS.x = MapComp.BoxWidth / 2 + (Idx % MapComp.LineNum) * MapComp.BoxWidth;
            newPS.y = MapComp.BoxWidth / 2 + ((Idx / MapComp.LineNum) % MapComp.Column) * MapComp.BoxWidth;
            newBox.transform.position = newPS;
        }
    }
}
