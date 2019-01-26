using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFrame
{
    static BaseFrame _Frame;
    public static BaseFrame Frame
    {
        get
        {
            if(_Frame ==null)
            {
                _Frame = new BaseFrame();
            }
            return _Frame;
        }
    }
    BaseFrame()
    {
        _GameTime = Time.time;
        GameObject baseGameObj = new GameObject("GameFrame");
        BaseFrameObj frameObj = baseGameObj.AddComponent<BaseFrameObj>();
        frameObj.BaseFrame = this;
        _AllFrameGame = new Dictionary<string, List<BaseGame>>();
    }
    Dictionary<string,List<BaseGame>> _AllFrameGame;
    List<BaseGame> GetGameListByName( string Name)
    {
        List<BaseGame> gameList;
        if (!_AllFrameGame.TryGetValue(Name,out gameList))
        {
            gameList = new List<BaseGame>();
            _AllFrameGame[Name] = gameList;
        }
        return gameList;
    }
    float _GameTime;
    
    public void Update()
    {
        _GameTime += Time.deltaTime;

        foreach (KeyValuePair<string, List<BaseGame>> kvp in _AllFrameGame)
        {
            List<BaseGame> list = kvp.Value;
            foreach( BaseGame game in list )
            {
                game.UpdateByTime(_GameTime,Time.time);
            }
        }
    }
    public void Regist(string Name,BaseGame gameObj)
    {
        List<BaseGame> list = GetGameListByName(Name);
        list.Add(gameObj);
    }
}
