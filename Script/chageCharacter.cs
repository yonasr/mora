using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chageCharacter : MonoBehaviour
{
    public SpriteRenderer spriteRendererBaju; 
    public Sprite normal;
    public Sprite cool; 
    
    public Button dress; 
    public bool flag; 

    // Start is called before the first frame update
    void Start()
    {
        spriteRendererBaju = GameObject.Find("caracter_normal").GetComponent<SpriteRenderer>();
        dress = GameObject.Find("Dressing").GetComponent<Button>();
        dress.onClick.AddListener(switchs);
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            spriteRendererBaju.sprite = normal;
        }

        else 
        {
            spriteRendererBaju.sprite = cool;
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
