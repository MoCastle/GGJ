﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Auido
{
    BGM1,
    BGM2,
    BGM3,
}

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
        if (mgr!=null)
        mgr.ShowBox(name);
        Debug.Log("NextScene");
    }
    public void PlayBGM(BGMEnum audioEnum)
    {
        BaseFrame.Frame.PlayBGMClip(audioEnum);
    }
    public void PlayAudio(ClipEnum audioEnum)
    {
        BaseFrame.Frame.PlayAudioClip(audioEnum);
    }
}
