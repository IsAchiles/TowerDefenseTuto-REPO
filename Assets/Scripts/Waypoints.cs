using System;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    public static Waypoints instance;

    void Awake(){
        instance = this;
        points = new Transform[transform.childCount];
        
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }

    }
}
