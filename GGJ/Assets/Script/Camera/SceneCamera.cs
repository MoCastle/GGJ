using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCamera : MonoBehaviour
{
    Camera _Camera;
    Camera Camera
    {
        get
        {
            if(_Camera==null)
            {
                _Camera = GetComponent<Camera>();
            }
            return _Camera;
        }
    }
    public float ViewWidth
    {
        get
        {
            Debug.Log("Undefined");
            return 0;
        }
    }
    public float ViewHeight
    {
        get
        {
            Debug.Log("Undefined");
            return 0;
        }
    }
    //将相机正对到某个区域
    public void SetInSquare(float startX,float startY,float width,float height)
    {

        float CenterX = startX + width / 2;
        float CenterY = startY + height / 2;
        Vector3 newPS = this.transform.position;
        newPS.x = CenterX;
        newPS.y = CenterY;
        //Camera.orthographicSize = height/2;
        float CameraHeight = height;
        this.transform.position = newPS;
    }
    //宽度适配
    public void FitWidth(float width)
    {

    }
    //高度适配
    public void FitHeight( float height)
    {

    }
}
