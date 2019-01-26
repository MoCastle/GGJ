using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    static UIManager _uim;
    public static UIManager uim
    {

        get
        {
            if (_uim == null)
                _uim = new UIManager();

            return _uim;
        }
    }
     
    static int thisScene=0;
   
    public GameObject Animation_001;     //动画预设体
    public Image BackGround_001;   //背景图1
    public Text Texts_001;             //文本1
    public GameObject TextBox;       //对话框组件
    public GameObject NextInfor;

    public GameObject Button_001;
    public GameObject Exit;
    public GameObject ReStart;
    public GameObject Story;

    public GameObject Next;
    public GameObject Return;

    public GameObject Vague;//模糊遮罩



    public GameObject StoryBook;
    public Text All_Story;
    private int number_Story = 40;
    private int thisChar_Story = 0;

    private string Text_Scene1="我就算被俘虏了，也不能只有一道小青菜吃吧，怎么长肉啊！居然做了麻辣兔子头，还贱兮兮的凑近我说，怎么不吃肉！？你见过吃肉的兔子吗！！？？！？";

    private bool Flag_Text=true;         //是否播放完文本

    private int number_Conver=15;          //每一行所显示的字数
    private int ThisChar_Conver = 0;      //当前显示到第几个字符

    public string _thisName;       //即将跳转的关卡

    public string all_Tex 
    {
        get { return Text_Scene1; }
        set { Text_Scene1 = value; }
    }
    void Start()
    {
        //按钮事件注册
        if (Button_001!= null)
        EventListener.Get(Button_001.GetComponent<Button>().gameObject).onClick = MyOnClick;
        if (Exit != null)
            EventListener.Get(Exit.GetComponent<Button>().gameObject).onClick = MyOnClick;
        if (ReStart != null)
            EventListener.Get(ReStart.GetComponent<Button>().gameObject).onClick = MyOnClick;
        if (Story != null)
            EventListener.Get(Story.GetComponent<Button>().gameObject).onClick = MyOnClick;
        if (Next != null)
        EventListener.Get(Next.gameObject).onClick = MyOnClick;
        if (Return != null)
        EventListener.Get(Return.gameObject).onClick = MyOnClick;
        if (NextInfor != null)
            EventListener.Get(NextInfor.gameObject).onClick = MyOnClick;

        if (StoryBook!=null)
        StoryBook.transform.DOScale(0, 0);

       TextBox.SetActive(false);
    }

    private void MyOnClick(GameObject button)
    {
        if (Button_001 != null && button ==Button_001.GetComponent<Button>().gameObject)
        {
            thisScene = 1;
            ToBlack tb = GameObject.Find("ToBlack").GetComponent<ToBlack>();
           tb._ToBlack();
        }
        if (Exit != null && button == Exit.GetComponent<Button>().gameObject)
        {
            Debug.Log("Exit");
        }
        if (ReStart != null && button == ReStart.GetComponent<Button>().gameObject)
        {
            Debug.Log("ReStart");
            GameCtrler.Ctrler.ResetPlayer();
        }
        if (Story != null && button == Story.GetComponent<Button>().gameObject)
        {
            StoryBook.transform.DOScale(1, 0.3f);
            Debug.Log("Story");            // 
        }
        if (button == Next.gameObject)
        {
            Debug.Log("Next");
        }
        if (button ==Return.gameObject)
        {
            StoryBook.transform.DOScale(0, 0.4f);
            Debug.Log("Return");
        }
        if (button == NextInfor.gameObject)
        {
            Which_Text(1);
        }
    }

  
    /// <summary>
    /// 显示对话框
    /// </summary>
    public void ShowBox(string name)
    {
        Debug.Log(" show name is " + name);
      //  TextBox.SetActive(true);
    }

    /// <summary>
    /// 控制显示哪段文本
    /// </summary>
    public void Which_Text(int id)
    {
        
        if (Flag_Text&&Texts_001!=null)//若文本未显示完
        {
            Debug.Log("id");
            Texts_001.GetComponent<Text>().text = null;//清空对话框中文字

          //  StartCoroutine(show(number_Conver));
            for (int i = 0; i < number_Conver; i++)
            {
                try
               {
                    Texts_001.GetComponent<Text>().text += Text_Scene1[ThisChar_Conver + i];//添加文字
                }
                catch
                {
                    Flag_Text = false;
                }
            }
            ThisChar_Conver = ThisChar_Conver + number_Conver;      //记录文本下标
        }
        else if (Texts_001 != null)
        {
            TextBox.transform.DOScaleX(0,0.3f);//文本已显示完，关闭对话框
        }
    }
  /*  IEnumerator show(int length)
    {
        int i = 0;
        yield return new WaitForSeconds(0.1f);
        while (i < length)
        {
            Texts_001.GetComponent<Text>().text += Text_Scene1[ThisChar_Conver + i];
            i += 1;
        }

    }*/
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

