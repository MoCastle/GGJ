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
    public GameMap GameMap { get; set; }

    public UIManager mgr { get; set; }

    public void ResetPlayer()
    {
        foreach( PlayerGameObj obj in GameMap.PlayerList )
        {
            obj.Reset();
        }
    }
    public void NextScene(string name)
    {
        mgr.ShowBox(name);
        Debug.Log("NextScene");
    }
}
