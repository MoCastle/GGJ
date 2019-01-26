using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ToWhite_Scene1 : MonoBehaviour
{
  //  public static ToBlack Instance = null;
    public Image Black;
    public Text text;
    Color col;
    private void Start()
    {
        _ToWhite();
    }
  /*  public void _ToBlack()
    {
        col.a = 1;
        Tweener toBlack = Black.DOColor(col, 2f);
        toBlack.OnComplete(_ToWhite);
    }*/
    public void _ToWhite()
    {
      //  SceneManager.LoadScene("Scene1");
      //  Debug.Log("this color is " + col.a);
        col.a = 0;
        Tweener toWhite = Black.DOColor(col, 3f);
        Tweener toOver = text.DOColor(col,2f);
        toWhite.OnComplete(delegate() { Debug.Log("this color is " + col.a); });

    }
   
}
