using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        FloorArray = new Floor[Floors.transform.childCount];
        for (int Idx = 0; Idx < FloorArray.Length; Idx++)
        {
            FloorArray[Idx] = Floors.transform.GetChild(Idx).GetComponent<Floor>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
