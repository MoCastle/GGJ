using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//方向枚举
public enum DirEnum
{
    P1Left,
    P1Right,
    P1Up,
    P1Down,
    P2Left,
    P2Right,
    P2Up,
    P2Down,
}

public class InputListener : MonoBehaviour
{
    public bool IsMove; //是否进行了移动
    public  DirEnum Player_1;
    public DirEnum Player_2;
    private KeyCode key;
    public GameMap input_GM;

    public static bool isMove = false;
    private MoveDir Forward=0;
    private int WhichPlayer = 0;
    // Start is called before the first frame update
    void Start()
    {
        input_GM = GameObject.Find("Map").GetComponent<GameMap>();
        key = KeyCode.Space;
    }

    //获取角色移动方向
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Player_1 = DirEnum.P1Up;

            isMove = true;
            WhichPlayer = 1;
            Forward = MoveDir.Up;

            Debug.Log("key is W");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Player_1 = DirEnum.P1Left;

            isMove = true;
            WhichPlayer = 1;
            Forward = MoveDir.Left;

            isMove = true;
            Debug.Log("key is A" );
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Player_1 = DirEnum.P1Down;

            isMove = true;
            WhichPlayer = 1;
            Forward = MoveDir.Down;

            Debug.Log("key is S");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Player_1 = DirEnum.P1Right;

            isMove = true;
            WhichPlayer = 1;
            Forward = MoveDir.Right;

            Debug.Log("key is D");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Player_2 = DirEnum.P2Up;

            isMove = true;
            WhichPlayer = 2;
            Forward = MoveDir.Up;

            Debug.Log("key is UP");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Player_2 = DirEnum.P2Left;

            isMove = true;
            WhichPlayer =2;
            Forward = MoveDir.Left;

            Debug.Log("key is LEFT" );
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Player_2 = DirEnum.P2Down;

            isMove = true;
            WhichPlayer = 2;
            Forward = MoveDir.Down;

            Debug.Log("key is DOWN" );
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Player_2 = DirEnum.P2Right;

            isMove = true;
            WhichPlayer = 2;
            Forward = MoveDir.Right;

            Debug.Log("key is RIGHT" );
        }
        if (isMove)
        {
            input_GM.Move(WhichPlayer,Forward);
        }

       
    }
}
