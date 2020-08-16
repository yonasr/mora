using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    //public GameObject spriteRenderer;
    public SpriteRenderer spriteRenderer;
    public Sprite normal;
    public Sprite happy;
    public Sprite sad;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //myImageComponent = GetComponent<Image>();
        //GetComponent<Image>().sprite = normal;
    }
    // Update is called once per frame
    void Update()
    {
        if (HealthPointS.hp <= 30)
        {
            //myObject.GetComponent<MyScript>().MyFunction();
            spriteRenderer.sprite = sad;
        }
        else if (HealthPointS.hp < 100)
        {
            spriteRenderer.sprite = normal;
        }
        else
        {
            spriteRenderer.sprite = happy;
        }
    }

    //public void changeImages(int status) // make sure to attach this to event trigger
    //{
    //    switch (status)
    //    {

    //        case 0:
    //            myImageComponent.sprite = normal;
    //            //imgNumberCount++; //increase count so it gets higher and switches to different sprite
    //            break;
    //        case 1:
    //            myImageComponent.sprite = happy;
    //            //imgNumberCount++;
    //            break;
    //        case 2:
    //            myImageComponent.sprite = sad;
    //            //imgNumberCount++;
    //            //imgNumberCount = 0; //Reset it to 0
    //            break;
    //        default:
    //            Debug.Log("Error");
    //            break;
    //    }
    //}
}
