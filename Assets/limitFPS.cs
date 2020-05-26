using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class limitFPS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //#if !UNITY_WEBGL
        //    Application.targetFrameRate = 144;
        //#endif
    }
    void Update() {
        //Debug.Log(1.0f / Time.smoothDeltaTime);
    }
}