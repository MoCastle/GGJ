using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ToBlack : MonoBehaviour
{

    public static ToBlack Instance = null;
    public Image Black;
    public Text First;
    Color col;
    Color col_2 = Color.white;
    public Image thisCG;
    public Sprite[] CGs = new Sprite[3];

    private string Texts_1 = "这一天，免免一如既往地从医院回家";
    private string Texts_2 = "突然，她的眼前一黑，感觉耳朵被一双毛茸茸的大手提了起来，便失去了意识";
    private string Texts_3 = "当她醒来时";
    private string Texts_4 = "发现天敌良良正蹲在她面前仔细地端详她";
    private string Texts_5 = "她十分地害怕，也有一丝不解：";
    private string Texts_6 = "“为什么他不把我吃了呢，怕不是要把我先喂胖了再吃吧。”";

    public Text Text_CG_1;
    public Text Text_CG_2;
    public Text Text_CG_3;

    public Image CG_002;
    public Text T_CG_002;

    public Text T_CG_003;
    public Text T_CG_004;
    public Text T_CG_005;
    public Image BLACK;

    // Start is called before the first frame update
    private void Start()
    {

        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        //    T_CG_004.text = null;
        col.a = 0;
        Black.DOColor(col, 0);
        BLACK.color = col;
        col.a = 1;
        //  _ToBlack();
    }

    
    public void _ToBlack()
    {
        col.a = 1;
        col_2.a = 1;
        Tweener toBlack = Black.DOColor(col, 2f);
       // toBlack.OnComplete(_ToWhite);

        Tweener Fonts = First.DOColor(col_2, 1.5f);
       Fonts.OnComplete(delegate() { StartCoroutine(time()); });
       
    }
    public void _ToWhite()
    {
    //   SceneManager.LoadScene("Scene1");
      //  Debug.Log("this color is "+col.a);
        col.a = 0;
        Tweener toWhite = Black.DOColor(col, 2f);
        First.DOColor(col, 0.5f);
       toWhite.OnComplete(delegate() { Start_CG(); });
     //
    }

    
    IEnumerator time()
    {
        yield return new WaitForSeconds(2.5f);
        thisCG.sprite = CGs[0];
        thisCG.SetNativeSize();
        _ToWhite();
    }
    private void Start_CG()
    {
        StartCoroutine(time_CG1(0.4f));
    }
    IEnumerator time_CG1(float time)
    {
        yield return new WaitForSeconds(time);
        col.a = 1;
        Text_CG_1.DOColor(col,1f);
        StartCoroutine(time_CG2(0.8f));
    }
    IEnumerator time_CG2(float time)
    {
        yield return new WaitForSeconds(time);
        col.a = 1;
        StartCoroutine(time_CG3(0.8f));
        Text_CG_2.DOColor(col, 1.5f);
    }
    IEnumerator time_CG3(float time)
    {
        yield return new WaitForSeconds(time);
        col.a = 1;
        Tweener toWhite_2 = Text_CG_3.DOColor(col, 2.3f);
        toWhite_2.OnComplete(delegate() { StartCoroutine(CG_2()); });
    }
    IEnumerator CG_2()
    {
        yield return new WaitForSeconds(1f);
        Text_CG_1.text=null;
        Text_CG_2.text=null;
        Text_CG_3.text = null;

        col.a = 1;
        CG_002.DOColor(col,0.1f);
        col = Color.white;
        col.a = 1;
        T_CG_002.DOColor(col, 0.1F);
        StartCoroutine(CG_3());
    }
    IEnumerator CG_3()
    {
        yield return new WaitForSeconds(1f);
        T_CG_002.text = null;
        thisCG.sprite = CGs[1];
        thisCG.SetNativeSize();
        col.a = 0;
        CG_002.DOColor(col, 2f);
    //    Debug.Log("33333");
     //   col = Color.black;
     //   col.a = 1;
        Color b = Color.black;
        b.a = 1;
        Tweener T = T_CG_003.DOColor(b, 5f);
        T.OnComplete(delegate() { StartCoroutine(CG_4()); });
    }
    IEnumerator CG_4()
    {
        yield return new WaitForSeconds(1f);
        col = Color.black;
        col.a = 1;
        BLACK.DOColor(col, 1f);
        col = Color.white;
        Tweener T = T_CG_004.DOColor(col, 2f);
        T.OnComplete(delegate() { StartCoroutine(CG_5()); });
    }
    IEnumerator CG_5()
    {
        yield return new WaitForSeconds(1f);
        col.a = 0;
        T_CG_003.text = null;
        T_CG_004.text = null;
        thisCG.sprite = CGs[2];
        thisCG.SetNativeSize();
        BLACK.DOColor(col, 1f);

        col = Color.black;
        col.a = 1;
        Tweener T = T_CG_005.DOColor(col, 0f);

        T_CG_005.text = Texts_3;
        col.a = 0;
      //  StartCoroutine(CG_6());
        Tweener T1 = T_CG_005.DOColor(col, 1f);
        T1.OnComplete(delegate() { StartCoroutine(CG_6()); });
      

      //  T_CG_005.text = Texts_4;

      
    }
   IEnumerator CG_6()
    {
        yield return new WaitForSeconds(1f);
        T_CG_005.text = Texts_4;
               col.a = 1;
        Tweener T2 = T_CG_005.DOColor(col, 1f);
        T2.OnComplete(delegate() { StartCoroutine(CG_7()); });
    }
   IEnumerator CG_7()
   {
       yield return new WaitForSeconds(1f);
       col.a = 0;
       //  StartCoroutine(CG_6());
       Tweener T1 = T_CG_005.DOColor(col, 1f);
       T1.OnComplete(delegate() { T_CG_005.text = Texts_5; StartCoroutine(CG_8()); });
       
   }
   IEnumerator CG_8()
   {
       yield return new WaitForSeconds(1.5f);
       col.a = 1;
       //  StartCoroutine(CG_6());
       Tweener T1 = T_CG_005.DOColor(col, 2f);
       T1.OnComplete(delegate() { T_CG_005.text = Texts_6; StartCoroutine(CG_9()); });
   }
   IEnumerator CG_9()
   {
       yield return new WaitForSeconds(1f);
       col.a = 1;
       Tweener T3 = BLACK.DOColor(col, 1f);
       T3.OnComplete(delegate() { SceneManager.LoadScene("Scene1"); });
   }
}
