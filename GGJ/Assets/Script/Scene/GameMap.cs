using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameMap:BaseGame
{
    static int jamed = 0;
    static int player = 1;




    [Title("格子宽高", "black")]
    public float BoxWidth = 256;
    [Title("行格子数量", "black")]
    public int LineNum;
    [Title("列格子数量", "black")]
    public int Column;


    enum Type
    {
        Normal,
        Jamed,
    }

    public Transform Floors;
    public Transform Floor;

    public Floor[] FloorArray;
    [Title("玩家", "black")]
    public Transform[] PlayerModels;
    public int[] PlayerLocation;

    // Start is called before the first frame update
    public override void StartSet()
    {
        FloorArray = GameObject.Find("Floors").GetComponentsInChildren<Floor>();
        CreateJamed();

        Animation();

        Vector3 testVector = new Vector3();
        testVector.x = 1.28f;

        PlayerLocation = new int[2];
        GameObject Map = GameObject.Find("Map");
        GameMap MapComp = Map.GetComponent<GameMap>();
        Transform Floors = MapComp.Floors;
        Transform[] PlayerModel = MapComp.PlayerModels;
        for (int Index = 0; Index < PlayerModel.Length; ++Index)
        {
         
            float X = (PlayerModel[Index].transform.position.x - MapComp.BoxWidth / 2 - Floors.position.x);
            float Y = (PlayerModel[Index].transform.position.y - MapComp.BoxWidth / 2 - Floors.position.y);
            X = X > 0 ? Mathf.Floor(X / MapComp.BoxWidth) : 0;
            Y = Y > 0 ? Mathf.Floor(Y / MapComp.BoxWidth) : 0;
            Debug.Log("Index is "+Index);
            Debug.Log("X is " + X);
            Debug.Log("y is " + Y);

            Vector3 newPS = PlayerModel[Index].transform.position;
            newPS.x = MapComp.BoxWidth / 2 + X * MapComp.BoxWidth;// +Floors.position.x;
            newPS.y = MapComp.BoxWidth / 2 + Y * MapComp.BoxWidth;// +Floors.position.y;

            Debug.Log(" newPS.x  is " + newPS.x);
            Debug.Log("  newPS.y  is " + newPS.y);
            PlayerModel[Index].transform.position = newPS;
            PlayerLocation[Index] = (int)Y * LineNum + (int)X;

            FloorArray[PlayerLocation[Index]].Type = FloorType.player;

            Debug.Log("Index is "+Index);
            /*foreach (object i in PlayerLocation)
            {
                int j = 0;
                Debug.Log(j+" is "+i);
                j++;
            }*/
        }
      
    }
    /// <summary>
    /// 创建障碍物
    /// </summary>
    private void CreateJamed()
    {

        for (int i = 0; i < FloorArray.Length;i++ )
        {
            if (i < LineNum)
            {
                FloorArray[i].Type = FloorType.Jamed;
            }
        }
   


       
    }
    /// <summary>
    /// 角色移动
    /// </summary>
    /// <param name="player_id">哪个玩家</param>
    /// <param name="forward">哪个方向 1_上，2_左，3_下_4_右</param>
    public void Move(int player_id,int forward)
    {
        GameObject Map = GameObject.Find("Map");
        GameMap MapComp = Map.GetComponent<GameMap>();

        InputListener.isMove = false;
        
        Vector3 oldPS = PlayerModels[player_id-1].transform.position;

        bool canMove = IfJamed(player_id,forward);//检测移动方向上是否有障碍物
        Debug.Log("canMove is "+canMove);
        if (canMove)
        {
            Debug.Log("oldPS is " + oldPS);
            Vector3 newPS = oldPS;          //应移动的位置
            switch (forward)
            {
                case 1:
                    newPS.y = oldPS.y + MapComp.BoxWidth;//+ Y * MapComp.BoxWidth;
                    break;
                case 2:
                    newPS.x = oldPS.x - MapComp.BoxWidth;//- X * MapComp.BoxWidth;
                    break;
                case 3:
                    newPS.y = oldPS.y - MapComp.BoxWidth;//- Y * MapComp.BoxWidth;
                    break;
                case 4:
                    newPS.x = oldPS.x + MapComp.BoxWidth;//+ X * MapComp.BoxWidth;
                    break;
                default:
                    break;
            };
            PlayerModels[player_id - 1].transform.position = newPS;
            Debug.Log(" PlayerModels[" + player_id + "].transform.position   is " + PlayerModels[player_id - 1].transform.position);
        }
    }

    /// <summary>
    /// 移动方向是否可前进
    /// </summary>
    private bool IfJamed(int player_id,int forward)
    {
        bool flag=true;
        switch (forward)
        {
            case 1:
                //检测是否是障碍物
                if (PlayerLocation[player_id - 1] + LineNum<FloorArray.Length&&FloorArray[PlayerLocation[player_id - 1] + LineNum].Type == FloorType.Jamed)
                    flag = false;
                else if (PlayerLocation[player_id - 1] + LineNum < FloorArray.Length)
                {
                    FloorArray[PlayerLocation[player_id - 1]].Type = FloorType.Normal;
                    FloorArray[PlayerLocation[player_id - 1] + LineNum].Type = FloorType.player;
                    PlayerLocation[player_id - 1] = PlayerLocation[player_id - 1] + LineNum;
                }
                //检测是否是玩家
                if (PlayerLocation[player_id - 1] + LineNum < FloorArray.Length && FloorArray[PlayerLocation[player_id - 1] + LineNum].Type == FloorType.player)
                {
                    if (player_id == 1)
                    {
                    }
                    else
                    {
                    }
                    FloorArray[PlayerLocation[player_id - 1]].Type = FloorType.Normal;
                    FloorArray[PlayerLocation[player_id - 1] + LineNum].Type = FloorType.Jamed;
                    PlayerLocation[player_id - 1] = PlayerLocation[player_id - 1] + LineNum;
                }

                break;
            case 2:
                //检测是否是障碍物
                if (FloorArray[PlayerLocation[player_id - 1] - 1].Type == FloorType.Jamed)
                    flag = false;
                else
                {
                    FloorArray[PlayerLocation[player_id - 1]].Type = FloorType.Normal;
                    FloorArray[PlayerLocation[player_id - 1] - 1].Type = FloorType.player;
                    PlayerLocation[player_id - 1] = PlayerLocation[player_id - 1] - 1;
                }
                //检测是否是玩家
                if (FloorArray[PlayerLocation[player_id - 1] + LineNum].Type == FloorType.player)
                {
                    FloorArray[PlayerLocation[player_id - 1]].Type = FloorType.Normal;
                    FloorArray[PlayerLocation[player_id - 1] + LineNum].Type = FloorType.player;
                    PlayerLocation[player_id - 1] = PlayerLocation[player_id - 1] + LineNum;
                }
                break;
            case 3:
                //检测是否是障碍物
                if (PlayerLocation[player_id - 1] - LineNum>0&&FloorArray[PlayerLocation[player_id - 1] - LineNum].Type == FloorType.Jamed)
                    flag = false;
                else if (PlayerLocation[player_id - 1] - LineNum > 0)
                {
                    FloorArray[PlayerLocation[player_id - 1]].Type = FloorType.Normal;
                    FloorArray[PlayerLocation[player_id - 1] - LineNum].Type = FloorType.player;
                    PlayerLocation[player_id - 1] = PlayerLocation[player_id - 1] - LineNum;
                }
                //检测是否是玩家
                if (FloorArray[PlayerLocation[player_id - 1] + LineNum].Type == FloorType.player)
                {
                    FloorArray[PlayerLocation[player_id - 1]].Type = FloorType.Normal;
                    FloorArray[PlayerLocation[player_id - 1] + LineNum].Type = FloorType.Jamed;
                    PlayerLocation[player_id - 1] = PlayerLocation[player_id - 1] + LineNum;
                }
                break;
            case 4:
                //检测是否是障碍物
                if (FloorArray[PlayerLocation[player_id - 1] + 1].Type == FloorType.Jamed)
                    flag = false;
                else
                {
                    FloorArray[PlayerLocation[player_id - 1]].Type = FloorType.Normal;
                    FloorArray[PlayerLocation[player_id - 1] + 1].Type = FloorType.Jamed;
                    PlayerLocation[player_id - 1] = PlayerLocation[player_id - 1] + 1;
                }
                //检测是否是玩家
                if (FloorArray[PlayerLocation[player_id - 1] + LineNum].Type == FloorType.player)
                {
                    FloorArray[PlayerLocation[player_id - 1]].Type = FloorType.Normal;
                    FloorArray[PlayerLocation[player_id - 1] + LineNum].Type = FloorType.Jamed;
                    PlayerLocation[player_id - 1] = PlayerLocation[player_id - 1] + LineNum;
                }
                break;
            default:
                break;
        }
        return flag;
    }

    /// <summary>
    /// 判断前方是何种障碍物
    /// </summary>
    /// <param name="player_id"></param>
    /// <param name="forward"></param>
    private void WhichType(int player_id, int forward)
    {

    }
    private void Awake()
    {
        FloorArray = new Floor[Floors.transform.childCount];
        for (int Idx = 0; Idx < FloorArray.Length; Idx++)
        {
            FloorArray[Idx] = Floors.transform.GetChild(Idx).GetComponent<Floor>();
        }
    }

    //地板动画
    public void Animation()
    {
        StartCoroutine(Animator());
    }
    IEnumerator Animator()
    {
        yield return new WaitForSeconds(0.1f);
        FloorArray[0].GetComponent<SpriteRenderer>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Scene_003[3];
        StartCoroutine(Animator_2());
    }
    IEnumerator Animator_2()
    {
        yield return new WaitForSeconds(0.1f);
        FloorArray[0].GetComponent<SpriteRenderer>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Scene_003[2];
        StartCoroutine(Animator());
    }
    public void StopAnimator()
    {
        StopAllCoroutines();
    }
}
