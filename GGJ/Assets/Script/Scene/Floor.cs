using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FloorType
{
    Normal,
    Jamed,
    player
}
public class Floor : MapObj
{
    public FloorType Type;
}
