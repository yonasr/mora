using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StatIcon : MonoBehaviour
{
    //public GameObject spriteRenderer;
    public SpriteRenderer spriteRendererhp;
    public SpriteRenderer spriteRendererfun;
    public SpriteRenderer spriteRendererhealth;
    public Sprite low_hp;
    public Sprite med_hp;
    public Sprite high_hp;
    public Sprite low_fun;
    public Sprite med_fun;
    public Sprite high_fun;
    public Sprite low_hyg;
    public Sprite med_hyg;
    public Sprite high_hyg;

    public Text gold_text;
    public static float gold;
    
    public static float hp;
    public static float fun;
    public static float hyg;

    public class HealthEvent : UnityEvent<float> { };
    public class FunEvent : UnityEvent<float> { };
    public class HygEvent : UnityEvent<float> { };



    public HealthEvent healthEvent;
    public FunEvent funEvent;
    public HygEvent hygEvent;
    private const float coef = 0.1f;
    public float decreasePerMinute=1000;

    // Start is called before the first frame update
    void Start()
    {
        //LOAD USERPREFS
        hp = PlayerPrefs.GetFloat("healthpoint");
        fun = PlayerPrefs.GetFloat("fun");
        hyg = PlayerPrefs.GetFloat("hyg");

        gold = PlayerPrefs.GetFloat("gold");
        if (gold == 0){
            gold = 100;
        }

        
        
        gold_text = GameObject.Find("GoldValue").GetComponent<Text>();
        
        spriteRendererhp = GameObject.Find("Hunger_green").GetComponent<SpriteRenderer>();
        spriteRendererfun = GameObject.Find("Fun_green").GetComponent<SpriteRenderer>();
        spriteRendererhealth = GameObject.Find("Hygiene_green").GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gold);
        gold_text.text = gold.ToString();
        PlayerPrefs.SetFloat("gold", gold);
        PlayerPrefs.Save();


        hp -= decreasePerMinute  * Time.deltaTime / 60f;
        if (healthEvent != null)
            healthEvent.Invoke(hp);

        if (hp <= 0)
        {
            hp = 0;
        }
        else if(hp>=100.1f)
        {
            hp = 100.1f;
           // fullPanel.gameObject.SetActive(true);
        }
        else if(hp<=100)
        {
           // fullPanel.gameObject.SetActive(false);
        }

        PlayerPrefs.SetFloat("healthpoint", hp);
        PlayerPrefs.Save();

        if (hp <= 30)
        {
            //myObject.GetComponent<MyScript>().MyFunction();
            spriteRendererhp.sprite = low_hp;
        }
        else if (hp < 100)
        {
            spriteRendererhp.sprite = med_hp;
        }
        else
        {
            spriteRendererhp.sprite = high_hp;
        }

        fun -= decreasePerMinute  * Time.deltaTime / 60f;
        if (funEvent != null)
            funEvent.Invoke(fun);

        if (fun <= 0)
        {
            fun = 0;
        }
        else if(fun>=100.1f)
        {
            fun = 100.1f;
           // fullPanel.gameObject.SetActive(true);
        }
        else if(fun<=100)
        {
           // fullPanel.gameObject.SetActive(false);
        }

        PlayerPrefs.SetFloat("fun", fun);
        PlayerPrefs.Save();

        // if (FunPointS.fun <= 30)
        // {
        //     //myObject.GetComponent<MyScript>().MyFunction();
        //     spriteRendererfun.sprite = low_fun;
        // }
        // else if (FunPointS.fun < 100)
        // {
        //     spriteRendererfun.sprite = med_fun;
        // }
        // else
        // {
        //     spriteRendererfun.sprite = high_fun;
        // }

        hyg -= decreasePerMinute  * Time.deltaTime / 60f;
        if (hygEvent != null)
            hygEvent.Invoke(hyg);

        if (hyg <= 0)
        {
            hyg = 0;
        }
        else if(hyg>=100.1f)
        {
            hyg = 100.1f;
           // fullPanel.gameObject.SetActive(true);
        }
        else if(hyg<=100)
        {
           // fullPanel.gameObject.SetActive(false);
        }

        PlayerPrefs.SetFloat("hyg", hyg);
        PlayerPrefs.Save();


        // if (HygPointS.hyg <= 30)
        // {
        //     //myObject.GetComponent<MyScript>().MyFunction();
        //     spriteRendererhealth.sprite = low_hyg;
        // }
        // else if (HygPointS.hyg < 100)
        // {
        //     spriteRendererhealth.sprite = med_hyg;
        // }
        // else
        // {
        //     spriteRendererhealth.sprite = high_hyg;
        // }
    }
}
