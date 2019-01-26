
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr
{
    static GameMgr _Mgr;
    public static GameMgr Mgr
    {
        get
        {
            if(_Mgr == null)
            {
                _Mgr = new GameMgr();
            }
            return _Mgr;
        }
    }
    public GameMap Map
    {
        get;
        set;
    }
    GameMgr()
    {
    }
}
