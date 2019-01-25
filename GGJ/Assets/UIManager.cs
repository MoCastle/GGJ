using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   
    public GameObject Animation_001;     //动画预设体
    public GameObject Button_001;    //按钮预设体
    public Image BackGround_001;   //背景图1
    public Text Texts_001;             //文本1

    private bool flag;         //是否播放完

    private int number;          //每一行所显示的字数


    /// <summary>
    /// 控制显示哪段文本
    /// </summary>
    public void Which_Text(int id) 
    {

    }

    /// <summary>
    /// 控制显示哪个动画
    /// </summary>
    /// <param name="id"></param>
    public void Which_Animation(int id)
    {
    }

    /// <summary>
    /// 控制显示哪张背景
    /// </summary>
    /// <param name="id"></param>
    public void Which_BG(int id)
    {
    }

    /// <summary>
    /// 点击事件
    /// </summary>
    /// <param name="button"></param>
    public void OnClick(GameObject button)
    {
    }
    }

}
