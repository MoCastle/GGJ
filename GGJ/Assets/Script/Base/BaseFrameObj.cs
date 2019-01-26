using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFrameObj : MonoBehaviour
{
     public BaseFrame BaseFrame
    {
        get;
        set;
    }
    private void Update()
    {
        if(BaseFrame!=null)
        {
            BaseFrame.Update();
        }
    }
}
