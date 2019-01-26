using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGame : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartSet();
    }
    public virtual void StartSet()
    {

    }
    public virtual void UpdateByTime(float GameTime,float RealTime)
    {

    }
}
