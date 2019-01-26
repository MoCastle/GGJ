using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGame : MonoBehaviour
{
    BaseFrame _Frame;
    // Start is called before the first frame update
    void Start()
    {
        _Frame = BaseFrame.Frame;
        _Frame.Regist(this.GetType().FullName,this);
        StartSet();
    }
    public virtual void StartSet()
    {

    }
    public virtual void UpdateByTime(float GameTime,float RealTime)
    {
    }
    private void OnDestroy()
    {
        _Frame.UnRegist(this);
    }
}
