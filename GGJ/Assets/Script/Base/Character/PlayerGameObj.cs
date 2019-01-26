using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameObj : MonoBehaviour
{
    int _FloorIdx;
    public int CurFloorIdx
    {
        get
        {
            return _FloorIdx;
        }
        set
        {
            _FloorIdx = value;
        }
    }

    /// <summary>
    /// 角色移动
    /// </summary>
    /// <param name="player_id">哪个玩家</param>
    /// <param name="forward">哪个方向 1_上，2_左，3_下_4_右</param>
    public void Move( int forward)
    {

           GameMap map = GameMgr.Mgr.Map;
           InputListener.isMove = false;

         //    Location location = GameMgr.Mgr.Map.GetLocationByIdx(CurFloorIdx);

              Vector3 oldPS = transform.position;

              Debug.Log("oldPS is " + oldPS);
        /*    switch (forward)
            {
                //上
                case 1:
                    location.y += 1;
                    break;
                //左
                case 2:
                    location.x -= 1;
                    break;
                //下
                case 3:
                    location.y -= 1;
                    break;
                //右
                case 4:
                    location.x += 1;
                    break;
                default:
                    break;
            };
         //   int newIdx = map.GetIdxByLocation(location);
            CurFloorIdx = newIdx;
        
          transform.position = map.GetPosition(newIdx); */
    }
}
