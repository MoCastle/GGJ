using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NewUIManager : MonoBehaviour
{
    public Image theEnd;
    public Text endT;
    Color col = Color.black;
    public Text endText;
    private string end_001 = "在婚礼上他们共同讲述了一个童话";
    private string end_002 = "有一个女孩出了车祸，没有受伤，却丢失了记忆";
    private string end_003 = "她以为自己是一只兔子，男朋友是一只狼。";
    private string end_004 = "而她的男朋友，陪她在世界中整整生活了六个月。";
    private string end_005 = "对我们来说";
    private string end_006 = "Home means accompany. ";

    Color co = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        col.a = 0;
        theEnd.DOColor(col, 1.5f);
        col = Color.white;
        col.a = 0;
        Tweener A = endT.DOColor(col, 1.5f);
        A.OnComplete(delegate() { StartCoroutine(End_01()); }); 
    }
    IEnumerator End_01()  //出现
    {
        yield return new WaitForSeconds(0.1f);

        endText.text = end_001;
        col = Color.black;
        col.a = 1;
        Tweener E1 = endText.DOColor(col, 1.5f);
        E1.OnComplete(delegate(){StartCoroutine(End_02());});
      //  endText.DOColor(col, 1.5f);
    }
    IEnumerator End_02()  //消失
    {
        yield return new WaitForSeconds(0.1f);

       // endText.text = end_001;
        col = Color.black;
        col.a = 0;
        Tweener E1 = endText.DOColor(col, 1.5f);
        E1.OnComplete(delegate() { StartCoroutine(End_03()); });
      //  endText.DOColor(col, 1.5f);
    }
    IEnumerator End_03()//出现
    {
        yield return new WaitForSeconds(0.1f);

        endText.text = end_002;
        col = Color.black;
        col.a = 1;
        Tweener E1 = endText.DOColor(col, 1.5f);
        E1.OnComplete(delegate() { StartCoroutine(End_04()); });
     //   endText.DOColor(col, 1.5f);
    }
    IEnumerator End_04() //消失
    {
        yield return new WaitForSeconds(0.1f);

     //   endText.text = end_002;
        col = Color.black;
        col.a = 0;
        Tweener E1 = endText.DOColor(col, 1.5f);
        E1.OnComplete(delegate() { StartCoroutine(End_05()); });
    //    endText.DOColor(col, 1.5f);
    }
    IEnumerator End_05()//出现
    {
        yield return new WaitForSeconds(0.1f);

        endText.text = end_003;
        col = Color.black;
        col.a = 1;
        Tweener E1 = endText.DOColor(col, 1.5f);
        E1.OnComplete(delegate() { StartCoroutine(End_06()); });
     //   endText.DOColor(col, 1.5f);
    }
    IEnumerator End_06() //消失
    {
        yield return new WaitForSeconds(0.1f);

        //   endText.text = end_002;
        col = Color.black;
        col.a = 0;
        Tweener E1 = endText.DOColor(col, 1.5f);
        E1.OnComplete(delegate() { StartCoroutine(End_07()); });
     //   endText.DOColor(col, 1.5f);
    }
    IEnumerator End_07()//出现
    {
        yield return new WaitForSeconds(0.1f);

        endText.text = end_004;
        col = Color.black;
        col.a = 1;
        Tweener E1 = endText.DOColor(col, 1.5f);
        E1.OnComplete(delegate() { StartCoroutine(End_08()); });
      //  endText.DOColor(col, 1.5f);
    }
    IEnumerator End_08() //消失
    {
        yield return new WaitForSeconds(0.1f);

        //   endText.text = end_002;
        col = Color.black;
        col.a = 0;
        Tweener E1 = endText.DOColor(col, 1.5f);
        E1.OnComplete(delegate() { StartCoroutine(End_09()); });
       // endText.DOColor(col, 1.5f);
    }
    IEnumerator End_09()//出现
    {
        yield return new WaitForSeconds(0.1f);

        endText.text = end_005;
        endText.fontSize = 140;
        col = Color.black;
        col.a = 1;
        Tweener E1 = endText.DOColor(col, 1.5f);
        E1.OnComplete(delegate() { StartCoroutine(End_10()); });
        //  endText.DOColor(col, 1.5f);
    }
    IEnumerator End_10() //消失
    {
        yield return new WaitForSeconds(0.1f);

        //   endText.text = end_002;
        col = Color.black;
        col.a = 0;
        Tweener E1 = endText.DOColor(col, 1.5f);
        E1.OnComplete(delegate() { StartCoroutine(End_11()); });
        // endText.DOColor(col, 1.5f);
    }
    IEnumerator End_11()//出现
    {
        yield return new WaitForSeconds(0.1f);

        endText.text = end_006;
        endText.fontSize = 100;
        col = Color.black;
        col.a = 1;
        Tweener E1 = endText.DOColor(col, 1.5f);
        E1.OnComplete(delegate() { StartCoroutine(End_12()); });
        //  endText.DOColor(col, 1.5f);
    }
    IEnumerator End_12() //消失
    {
        yield return new WaitForSeconds(0.1f);

        //   endText.text = end_002;
        col = Color.black;
        col.a = 0;
        Tweener E1 = endText.DOColor(col, 1.5f);
        // endText.DOColor(col, 1.5f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
