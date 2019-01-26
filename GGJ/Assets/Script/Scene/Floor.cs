using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FloorType
{
    Normal,
    Jamed
}
public class Floor : MapObj
{
    public FloorType Type;
    protected bool _Dirty;
    float Time;

    public virtual void SetDirty()
    {
        //普通地砖没有触碰事件
        _Dirty = true;
        return;
    }
    private void Update()
    {
        if(_Dirty)
        {
            _Dirty = false;
            Touched();
        }
    }
    
    public virtual void Touched()
    { }
}
