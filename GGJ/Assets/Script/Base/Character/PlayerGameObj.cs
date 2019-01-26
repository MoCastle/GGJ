using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameObj : MonoBehaviour
{
    int[] _Location;
    public int CurLocation
    {
        get
        {
            return _Location[0];
        }
    }
    public int NextLocation
    {
        get
        {
            return _Location[1];
        }
    }

    public void SetCurLocation(int location)
    {
        _Location[0] = location;
    }
    public void SetNextLocation(int location)
    {
        _Location[1] = location;
    }
}
