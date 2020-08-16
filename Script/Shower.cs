using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shower : MonoBehaviour
{
    public float poin = 0; 
    
    public Button shower; 
    public bool flag;
    // Start is called before the first frame update
    void Start()
    {
        shower = GameObject.Find("Shower").GetComponent<Button>();
        shower.onClick.AddListener(switchs);
        flag = false;
    }

    // Update is called once per frame
void Update()
    {
        if (flag)
        {
            //animasi 
            
            //tambahin poin health 
            poin += Time.deltaTime*2; 
            Debug.Log ("Mandi Om");
        }

        else 
        {
            //stop animasi
            

        }
    }

    void switchs(){
        if(flag){
            flag = false;
        }
        else{
            flag = true;
        }

    }
}
