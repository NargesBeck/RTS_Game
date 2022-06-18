using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonLinker : MonoBehaviour
{
    private static SingletonLinker instance;
    public static SingletonLinker Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<SingletonLinker>();
            return instance;
        }
    }

    private Camera Camera;
    public Camera GetCamera
    {
        get
        {
            if (Camera == null)
                Camera = Camera.main;
            return Camera;
        }
    }
}
