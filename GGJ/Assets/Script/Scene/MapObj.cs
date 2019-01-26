using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObj : MonoBehaviour
{
    protected int _StartIdx = -1;
    protected int _CurFloorIdx;
    public int CurFloorIdx
    {
        get
        {
            return _CurFloorIdx;
        }
        set
        {
            _CurFloorIdx = value;
            if(_StartIdx<0)
            {
                _StartIdx = _CurFloorIdx;
            }
        }
    }
    public Location Location
    {
        get
        {
            return _Map.GetLocationByIdx(_CurFloorIdx);
        }
    }
    protected GameMap _Map;
    // Start is called before the first frame update
    public void SetMap(GameMap map)
    {
        _Map = map;
    }
}
