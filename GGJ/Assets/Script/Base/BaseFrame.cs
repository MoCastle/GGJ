using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BGMEnum
{
    Head_Tail,
    Level1_2,
    Level3,
    Level4
}
public enum ClipEnum
{
    Icon1,
    Icon2,
    Paiper
}
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
    AudioSource _BGM;
    AudioSource _AudioClip;
    Dictionary<BGMEnum, AudioClip> _BGMDict;
    Dictionary<ClipEnum, AudioClip> _AudioClipDict;
    BaseFrame()
    {
        _GameTime = Time.time;
        GameObject baseGameObj = new GameObject("GameFrame");
        BaseFrameObj frameObj = baseGameObj.AddComponent<BaseFrameObj>();
        _BGM = baseGameObj.AddComponent<AudioSource>();
        _BGM.loop = true;
        _AudioClip = baseGameObj.AddComponent<AudioSource>();

        frameObj.BaseFrame = this;
        GameObject.DontDestroyOnLoad(frameObj);
        _AllFrameGame = new Dictionary<string, List<BaseGame>>();
        _BGMDict = new Dictionary<BGMEnum, AudioClip>();
        _AudioClipDict = new Dictionary<ClipEnum, AudioClip>();
        _LoadAudio();
    }
    void _LoadAudio()
    {
        foreach (BGMEnum BGM in Enum.GetValues(typeof(BGMEnum)))
        {
            AudioClip clip = Resources.Load<AudioClip>("Audio/" + BGM.ToString());
            _BGMDict[BGM] = clip;
        }
        foreach(ClipEnum clipEnum in Enum.GetValues(typeof(ClipEnum)))
        {
            AudioClip clip = Resources.Load<AudioClip>("Audio/" + clipEnum.ToString());
            _AudioClipDict[clipEnum] = clip;
        }
    }
    public void PlayAudioClip(ClipEnum audioEnum)
    {
        AudioClip clip;
        if(_AudioClipDict.TryGetValue(audioEnum,out clip))
        {
            _AudioClip.clip = clip;
            _AudioClip.Play();
        }
    }
    public void PlayBGMClip(BGMEnum audioEnum)
    {
        AudioClip clip;
        if (_BGMDict.TryGetValue(audioEnum, out clip))
        {
            _BGM.clip = clip;
            _BGM.Play();
        }
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
    public void UnRegist(BaseGame gameObj)
    {
        List<BaseGame> list = GetGameListByName(gameObj.GetType().FullName);
        list.Remove(gameObj);
    }
}
