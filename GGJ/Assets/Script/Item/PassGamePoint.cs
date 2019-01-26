using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassGamePoint : Item
{
    [Title("下一关名字", "black")]
    public string NextSceneName;
    [Title("兄弟过关点", "black")]
    public PassGamePoint Brother;
    bool _IsPlayerTouched;
    public bool ISPlayerTouched
    {
        get
        {
            return _IsPlayerTouched;
        }
    }
    public override void Touched(int location,GameMap map = null)
    {
        _IsPlayerTouched = true;
        if( !Brother.ISPlayerTouched )
        {
            return;
        }
        if(NextSceneName!="")
            SceneManager.LoadScene(NextSceneName);
    }
}
