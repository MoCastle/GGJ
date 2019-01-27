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

  //  public GameObject Vague;
    public GameObject Animation_001;     //动画预设体
    public Image BackGround_001;   //背景图1
    public Text Texts_001;             //文本1
    public GameObject TextBox;       //对话框组件
    public GameObject Role;
    public GameObject NextInfor;

    public GameObject Button_001;
    public GameObject Exit;
    public GameObject ReStart;
    public GameObject Story;

    public GameObject Next;
    public GameObject Return;

    public GameObject Vague;//模糊遮罩
    public Image CG;

    private bool canMove = true;//是否可进行点击

    public GameObject StoryBook;
    public Text All_Story;
    private int number_Story = 40;
    private int thisChar_Story = 0;
    public GameObject TheEnd;
    private bool spc = false;   //是否需要特殊CG

    private int Scene_id=0;//当前关卡ID
    private int spc_id = 0;//当前特殊CG id   1.第二关第二张 2.第三关第1张 3.第三关第2张

    //第一段对话文本
    private string Text_Scene1="我就算被俘虏了，也不能只有一道小青菜吃吧，怎么长肉啊！居然做了麻辣兔子头，还贱兮兮的凑近我说，怎么不吃肉！？你见过吃肉的兔子吗！！？？！？";
    //第二段对话文本
    private string Text_Scene2 = "今天回来这么晚，给她买一束花吧，她一定会喜欢的。百合花，栀子花，都买给她吧。不不不，这不是吃的！怎么想吃花啊,是买给她看的啊.";

    //第二章对话文本_2
    private string Text_Scene2_2 = "为什么他要把花留下啊……留给我吃多好。不过，真的好香，好喜欢这种感觉。他再也没有给我做过肉菜了，还别说，他真的对我好好";
    //第三段对话文本_1
    private string Text_Scene3 = "别过来！！！";
    private string Text_Scene3_2 = "这个色狼！竟然想和我睡觉！";
    private string Text_Scene3_3 = "啊啊啊啊！好害羞！";
    private string Text_Scene3_4 = "诶？卧室的墙上，居然有很想我们两个游玩的合照；可能是我想多了吧，最近也经常做一些奇怪的梦。";
   // private string Text_Scene3_5="";

  //  private string Text_Scene_3_2 = "7.	这个色狼！竟然想和我睡觉！啊啊啊啊！好害羞！诶？卧室的墙上，居然有很想我们两个游玩的合照；可能是我想多了吧，最近也经常做一些奇怪的梦。";
    //第四段对话文本
    private string Text_Scene4_1 = "他今天……带回来的是红玫瑰，哎，底下是什么？";
    private string Text_Scene4_2 = "嫁给我吧，亲爱的。";
    private string Text_Scene4_3 = "兔子和狼怎么结婚啊！？！";
    private string Text_Scene4_4 = "你……你哭什么……不准人家害羞一下啊";
    private string Text_Scene4_5 = "亲爱的，你别做兔子好吗，你六个月没有吃肉……";
    private string Text_Scene4_6 = "都这么瘦了，胡萝卜青菜有什么好吃的啊！";
    private string Text_Scene4_7 = "你别做兔子了！你做一只狼，一只老虎，或者一只猪都行！";
    private string Text_Scene4_8 = "求你了。";
    private string Text_Scene4_9 = "突然，免免脑子里的记忆开始像潮水一样波涛汹涌。";
    private string Text_Scene4_10 = "她想起来了一切。";
    private string Text_Scene4_11 = "你刚刚说啥？";
    private string Text_Scene4_12 = "你做一只猪也行。";
    private string Text_Scene4_13 = "不是这个！";
    private string Text_Scene4_14 = "亲爱的，你嫁给我吧。";
    private string Text_Scene4_15 = "我答应你。";


    private int num_3_2=0;   //第三关按钮被点击的次数
    private int num_4 = 0;   //第四关按钮被点击的次数

    private string All_Text; //目前已进行的文本
    private bool Flag_Text=true;         //是否播放完文本

    private int number_Conver=18;          //每一行所显示的字数
    private int ThisChar_Conver = 0;      //普通CG当前显示到第几个字符
    private int SPC_ThisChar_Conver = 0;      //特殊CG当前显示到第几个字符
    private int spc_j = 0;

    public string _thisName;       //即将跳转的关卡

    public string all_Tex 
    {
        get { return Text_Scene1; }
        set { Text_Scene1 = value; }
    }
    void Start()
    {
        GameCtrler.Ctrler.mgr = this;

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

        if (TextBox!=null)
       TextBox.SetActive(false);
    }

    private void MyOnClick(GameObject button)
    {
        if (canMove)
        {
            if (Button_001 != null && button == Button_001.GetComponent<Button>().gameObject)
            {
                thisScene = 1;
                ToBlack tb = GameObject.Find("ToBlack").GetComponent<ToBlack>();
                tb._ToBlack();
            }
            if (Exit != null && button == Exit.GetComponent<Button>().gameObject)
            {
                /////
                ShowBox("Scene5");
                /////
                Debug.Log("Exit");
            }
            if (ReStart != null && button == ReStart.GetComponent<Button>().gameObject)
            {
                Debug.Log("ReStart");
                GameCtrler.Ctrler.ResetPlayer();
            }
            if (Story != null && button == Story.GetComponent<Button>().gameObject)
            {
                All_Story.text = All_Text;
                StoryBook.transform.DOScale(1, 0.3f);
                Debug.Log("Story");            // 
            }
            if (button == Next.gameObject)
            {
                Debug.Log("Next");
            }
            if (button == Return.gameObject)
            {
                StoryBook.transform.DOScale(0, 0.4f);
                Debug.Log("Return");
            }
           
        }
        if (button == NextInfor.gameObject&&!spc)
        {
            Which_Text(Scene_id);
        }
        else if (button == NextInfor.gameObject && spc)
        {
            Talk_Spc(spc_id);
        }
    }

  
    /// <summary>
    /// 显示对话框
    /// </summary>
    public void ShowBox(string name)
    {
        Debug.Log(" show name is " + name);
        canMove = false;
        TextBox.SetActive(true);
        switch (name)
        {
            case "Scene2":
                ThisChar_Conver = 0;
                Scene_id = 1;
                Debug.Log("this is " + name);
                Which_Text(Scene_id);
                break;
            case "Scene3":
                ThisChar_Conver = 0;
                Scene_id = 2;
                Which_Text(Scene_id);
                break;
            case "Scene4":
                ThisChar_Conver = 0;
                Scene_id = 3;
                Which_Text(Scene_id);
                break;
            default:
                  ThisChar_Conver = 0;
                Scene_id = 4;
                Which_Text(Scene_id);
                break;
        }
    
       
    }

    /// <summary>
    /// 控制显示哪段文本
    /// </summary>
    public void Which_Text(int id)
    {
        Texts_001.GetComponent<Text>().text = null;
        if (id == 1)
        {
            ShowCG(1);  //显示cg;
            if (Flag_Text && Texts_001 != null)//若文本未显示完
            {
                Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[0];

                Texts_001.GetComponent<Text>().text = null;//清空对话框中文字

                for (int i = 0; i < number_Conver; i++)
                {
                    try
                    {
                        Texts_001.GetComponent<Text>().text += Text_Scene1[ThisChar_Conver + i];//添加文字
                        All_Text += Texts_001.GetComponent<Text>().text;
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
                Tweener t1 = TextBox.transform.DOScaleX(0, 0.3f);
                TextBox.SetActive(false);
                t1.OnComplete(delegate() { canMove = true; SceneManager.LoadScene("scene2"); });
            }
        }
        else if (id == 2)
        {
            ShowCG(2);
            TextBox.SetActive(true);
            TextBox.transform.DOScale(1,0.2f);
            if (Flag_Text && Texts_001 != null)//若文本未显示完
            {
                Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[1];

                Texts_001.GetComponent<Text>().text = null;//清空对话框中文字

                for (int i = 0; i < number_Conver; i++)
                {
                    try
                    {
                        Texts_001.GetComponent<Text>().text += Text_Scene2[ThisChar_Conver + i];//添加文字
                        All_Text += Texts_001.GetComponent<Text>().text;
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
                Tweener t1 = TextBox.transform.DOScaleX(0, 0.3f);
                TextBox.SetActive(false);
                t1.OnComplete(delegate() { canMove = true; spc = true; SPC_ThisChar_Conver = 0;spc_j=0; Talk_Spc(1); spc_id = 1; });
            }
        }
        else if (id == 3)
        {
            TextBox.SetActive(true);
            TextBox.transform.DOScale(1, 0.2f);
            if (Flag_Text && Texts_001 != null)//若文本未显示完
            {
                Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[0];

                Texts_001.GetComponent<Text>().text = null;//清空对话框中文字

                for (int i = 0; i < number_Conver; i++)
                {
                    try
                    {
                        Texts_001.GetComponent<Text>().text += Text_Scene3[ThisChar_Conver + i];//添加文字
                        All_Text += Texts_001.GetComponent<Text>().text;
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
                Tweener t1 = TextBox.transform.DOScaleX(0, 0.3f);
                t1.OnComplete(delegate() { canMove = true; ShowCG(4); spc = true; SPC_ThisChar_Conver = 0; spc_j = 0; Talk_Spc(2); spc_id = 2; });
            }
        }
        else if (id == 4)
        {
            num_4 += 1;


            TextBox.SetActive(true);
            TextBox.transform.DOScale(1, 0.2f);


            if (num_4 == 1)
            {
                Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[0];
                Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
                Texts_001.GetComponent<Text>().text = Text_Scene4_1;//添加文字
            }
            if (num_4 == 2)
            {
                 Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[1];
                Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
                Texts_001.GetComponent<Text>().text = Text_Scene4_2; //添加文字
            }
            if (num_4 == 3)
            {
                 Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[0];
                Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
                Texts_001.GetComponent<Text>().text = Text_Scene4_3;//添加文字
            }
            if (num_4 == 4)
            {
                 Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[0];
                Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
                Texts_001.GetComponent<Text>().text = Text_Scene4_4;//添加文字
            }
            if (num_4 == 5)
            { 
                Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[1];
                Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
                Texts_001.GetComponent<Text>().text = Text_Scene4_5;//添加文字
            }
            if (num_4 == 6)
            {
                   Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[1];
                Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
                Texts_001.GetComponent<Text>().text = Text_Scene4_6;//添加文字
            }
              if (num_4 == 7)
            {
                   Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[1];
                Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
                Texts_001.GetComponent<Text>().text = Text_Scene4_7;//添加文字
             }
          if (num_4 == 8)
            {
                   Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[1];
                Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
                Texts_001.GetComponent<Text>().text = Text_Scene4_8;//添加文字
            }
          if (num_4 ==9)
          {
              Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[0];
              Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
              Texts_001.GetComponent<Text>().text = Text_Scene4_9;//添加文字
          }
          if (num_4 == 10)
          {
              ShowCG(6);
              Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[0];
              Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
              Texts_001.GetComponent<Text>().text = Text_Scene4_10;//添加文字
          }
          if (num_4 == 11)
          {
              ShowCG(6);
              Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[0];
              Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
              Texts_001.GetComponent<Text>().text = Text_Scene4_11;//添加文字
          }
          if (num_4 == 12)
          {
              ShowCG(6);
              Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[1];
              Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
              Texts_001.GetComponent<Text>().text = Text_Scene4_12;//添加文字
          }
          if (num_4 == 13)
          {
              ShowCG(6);
              Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[0];
              Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
              Texts_001.GetComponent<Text>().text = Text_Scene4_13;//添加文字
          }
          if (num_4 == 14)
          {
              ShowCG(6);
              Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[1];
              Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
              Texts_001.GetComponent<Text>().text = Text_Scene4_14;//添加文字
          }
          if (num_4 == 15)
          {
              ShowCG(6);
              Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[0];
              Texts_001.GetComponent<Text>().text = null;//清空对话框中文字
              Texts_001.GetComponent<Text>().text = Text_Scene4_15;//添加文字
          }
          if (num_4 == 15)
          {
              TextBox.SetActive(false);
              TheEnd.SetActive(true);
              SceneManager.LoadScene("End");
          }
          //   Texts_001.GetComponent<Text>().text += Text_Scene3[ThisChar_Conver + i];//添加文字
           //  All_Text += Texts_001.GetComponent<Text>().text;

        }
    }

    public void Talk_Spc(int id)
    {
        if (id == 1)
        {
            if (spc_j==0)
            Flag_Text = true;
            spc_j += 1;
            ShowCG(3);
          //  SPC_ThisChar_Conver = 0;
            TextBox.SetActive(true);
            TextBox.transform.DOScale(1, 0.2f);
         
            if (Flag_Text && Texts_001 != null)//若文本未显示完
            {
                Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[0];
                Texts_001.GetComponent<Text>().text = null;//清空对话框中文字

                for (int i = 0; i < number_Conver; i++)
                {
                    try
                    {
                        Texts_001.GetComponent<Text>().text += Text_Scene2_2[SPC_ThisChar_Conver + i];//添加文字
                        All_Text += Texts_001.GetComponent<Text>().text;
                    }
                    catch
                    {
                       // Texts_001.GetComponent<Text>().text += Text_Scene2_2[];
                      
                      //  Flag_Text = false;
                    }
                    if (SPC_ThisChar_Conver + i > Text_Scene2_2.Length)
                    {
                        Flag_Text = false;
                        Debug.Log("1 is " + SPC_ThisChar_Conver +" 2 is "+Text_Scene2_2.Length);
                    }
                }
                SPC_ThisChar_Conver = SPC_ThisChar_Conver + number_Conver;      //记录文本下标
            }
            else 
            {
                Tweener t1 = TextBox.transform.DOScaleX(0, 0.3f);
                TextBox.SetActive(false);
                t1.OnComplete(delegate() { canMove = true; SceneManager.LoadScene("Scene3"); });
            }
        }
        if (id == 2)
        {
            num_3_2 += 1;
            if (spc_j == 0)
                Flag_Text = true;
            spc_j += 1;
           // ShowCG(4);
            //  SPC_ThisChar_Conver = 0;
            TextBox.SetActive(true);
            TextBox.transform.DOScale(1, 0.2f);

                Role.GetComponent<Image>().sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().Roles[0];
                Texts_001.GetComponent<Text>().text = null;//清空对话框中文字

                if (num_3_2==1)
                Texts_001.GetComponent<Text>().text = Text_Scene3_2;
                else if (num_3_2==2)
                    Texts_001.GetComponent<Text>().text = Text_Scene3_3;
                else if (num_3_2 ==3)
                {
                    ShowCG(5);
                    Texts_001.GetComponent<Text>().color = Color.red;
                    Texts_001.GetComponent<Text>().text = "诶？卧室的墙上，居然有很像我们两个";

                }
                else if (num_3_2 == 4)
                {
                 //   ShowCG(5);
                    Texts_001.GetComponent<Text>().color = Color.red;
                    Texts_001.GetComponent<Text>().text = "游玩的合照；可能是我想多了吧，最近";
                }
                else if (num_3_2 == 5)
                {
                  //  ShowCG(5);
                    Texts_001.GetComponent<Text>().color = Color.red;
                    Texts_001.GetComponent<Text>().text = "也经常做一些奇怪的梦。";
                }
                else if (num_3_2 == 6)
                {
                    Tweener t1 = TextBox.transform.DOScaleX(0, 0.3f);
                    TextBox.SetActive(false);
                    t1.OnComplete(delegate() { canMove = true; SceneManager.LoadScene("Scene4"); });
                }
          
        }
    }
    /// <summary>
    /// 展示CG
    /// </summary>
    public void ShowCG(int id)
    {
        switch (id)
        {
            case 1:
              
               CG.sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().CG[0];
               Color CO=Color.white;
               CO.a = 1;
               CG.DOColor(CO,0F);
               CG.SetNativeSize();
             
                break;
            case 2:
                CG.sprite=GameObject.Find("Sprites").GetComponent<SpiteManager>().CG[1];
                  Color CO2=Color.white;
               CO.a = 1;
               CG.DOColor(CO2,0F);
               CG.SetNativeSize();

                break;
                //第二关第二张
            case 3:
                 CG.sprite=GameObject.Find("Sprites").GetComponent<SpiteManager>().CG[2];
                 Vague.SetActive(true);
                  Color CO3=Color.white;
               CO.a = 1;
               CG.DOColor(CO3,0F);
               CG.SetNativeSize();
                break;
                //第三关第一张
            case 4:
                  CG.sprite=GameObject.Find("Sprites").GetComponent<SpiteManager>().CG[3];
                 Vague.SetActive(true);
                  Color CO4=Color.white;
               CO.a = 1;
               CG.DOColor(CO4,0F);
               CG.SetNativeSize();
                break;
            case 5:
                CG.sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().CG[7];
                Vague.SetActive(true);
                Color CO5 = Color.white;
                CO.a = 1;
                CG.DOColor(CO5, 0F);
                CG.SetNativeSize();
                break;
            case 6:
                CG.sprite = GameObject.Find("Sprites").GetComponent<SpiteManager>().CG[4];
                Vague.SetActive(true);
                Color CO6 = Color.white;
                CO.a = 1;
                CG.DOColor(CO6, 0F);
                CG.SetNativeSize();
                break;
        }
    }
 
    }

