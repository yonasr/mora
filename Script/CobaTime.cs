using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobaTime : MonoBehaviour
{
    public float waktuMain = 0;

    void Update()
    {
        // Debug.Log (waktuMain);
        waktuMain += Time.deltaTime;
        
        if (waktuMain > 10)
        {
            Debug.Log("Udah 30");
        }
        
        // else
        // {
        //     Debug.Log("Time has run out!");
        // }
    }
}