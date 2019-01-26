﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
   
    public GameObject Animation_001;     //动画预设体
    public GameObject Button_001;    //按钮预设体
    public Image BackGround_001;   //背景图1
    public Text Texts_001;             //文本1
    public GameObject TextBox;       //对话框组件

    private string All_Tex="一二三四五,!六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十十一十二";

    private bool Flag_Text=true;         //是否播放完文本

    private int number=8;          //每一行所显示的字数
    private int ThisChar = 0;      //当前显示到第几个字符

    public string all_Tex 
    {
        get { return All_Tex; }
        set { All_Tex = value; }
    }
    void Start()
    {
        TextBox.transform.DOScaleX(0, 0f);//对话框初始化
    //    Which_Text(1);
    }
    void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("下一句");
            Which_Text(2);
        }
        if (Input.GetMouseButtonDown(1))
        {
            TextBox.transform.DOScaleX(1, 0f);
            Which_Text(2);
        }
    }
    /// <summary>
    /// 控制显示哪段文本
    /// </summary>
    public void Which_Text(int id)
    {
        if (Flag_Text)//若文本未显示完
        {
            Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
            for (int i = 0; i < number; i++)
            {
                
                try
                {
                    Texts_001.GetComponent<Text>().text += All_Tex[ThisChar + i];//添加文字
                }
                catch
                {
                    Flag_Text = false;

                }
            }
            ThisChar = ThisChar + number;      //记录文本下标
        }
        else
        {
            TextBox.transform.DOScaleX(0,0.3f);//文本已显示完，关闭对话框
        }
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

