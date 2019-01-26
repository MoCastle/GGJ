using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrler
{
    static GameCtrler _Ctrler;
    public static GameCtrler Ctrler
    {
        get
        {
            if(_Ctrler == null)
            {
                _Ctrler = new GameCtrler();
            }
            return _Ctrler;
        }
    }
    
    public void ResetPlayer()
    {

    }
}
