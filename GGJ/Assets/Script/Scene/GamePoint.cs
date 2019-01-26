using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GamePoint : Floor
{
    public string SceneName;
    public override void Touched()
    {
        PlayerGameObj[] PlayerList = _Map.PlayerList;
        Location pointLocation = _Map.GetLocationByIdx(_CurFloorIdx);
        Location pOne = _Map.GetLocationByIdx(PlayerList[0].CurFloorIdx);
        Location pTwo = _Map.GetLocationByIdx(PlayerList[1].CurFloorIdx);
        bool oneIn = CheckLocation(pOne);
        bool twoIn = CheckLocation(pTwo);
        
        if (oneIn && twoIn)
        {
            //////////////////////////此关胜利
            if (SceneName != "")
            {
                UIManager.WhichScene(SceneName);
          //      GP_UI.WhichScene(SceneName);
              // SceneManager.LoadScene(SceneName);
            }
        }else if(PlayerList[0].CurFloorIdx  == _CurFloorIdx || PlayerList[1].CurFloorIdx == _CurFloorIdx)
        {
            _Dirty = true;
        }
    }
    //检查一个角色在不在九宫格内
    public bool CheckLocation(Location checkTarget)
    {
        Location location = _Map.GetLocationByIdx(_CurFloorIdx);
        if (location.x - 1 > checkTarget.x || location.x + 1 < checkTarget.x)
        {
            return false;
        }
        if (location.y - 1 > checkTarget.y || location.y + 1 < checkTarget.y)
        {
            return false;
        }
        return true;
    }
}

