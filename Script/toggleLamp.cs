using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleLamp : MonoBehaviour
{
   // public SpriteRenderer spriteRendererLamp;
    public Sprite lamp_off;
    public Sprite lamp_on;
    public Button lamp;
    public GameObject panelTidur;
    public bool flag;

    
    public SpriteRenderer spriteRendererChar;
    public Sprite sleep;
    public Sprite normal;


    // Start is called before the first frame update
    void Start()
    {
        panelTidur = GameObject.Find("PanelTidur");
        panelTidur.SetActive(false);
        flag = false;
        lamp = GameObject.Find("Lightswitch_off").GetComponent<Button>();
        //spriteRendererLamp = GameObject.Find("Lightswitch_off").GetComponent<SpriteRenderer>();
        spriteRendererChar = GameObject.Find("caracter_normal").GetComponent<SpriteRenderer>();
        lamp.onClick.AddListener(switchs);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (flag)
        {
            //myObject.GetComponent<MyScript>().MyFunction();
            //spriteRendererLamp.sprite = lamp_off;
            lamp.GetComponent<Image>().sprite = lamp_off;
            panelTidur.SetActive(true);
            spriteRendererChar.sprite = sleep;

        }
        else{
           // spriteRendererLamp.sprite = lamp_on;
            lamp.GetComponent<Image>().sprite = lamp_on;
            panelTidur.SetActive(false);
            spriteRendererChar.sprite = normal;

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
