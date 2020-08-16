using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthPointS : MonoBehaviour
{
    //public static int hp = 0;
    //Text hp_text;
    public class HealthEvent : UnityEvent<float> { };
    public static float hp ;
    //= 100.1f;
    public HealthEvent healthEvent;
    private const float coef = 0.1f;
    public float playerHealth;
    public float decreasePerMinute=1000;

    public GameObject fullPanel;

    // Start is called before the first frame update
    void Start()
    {
        hp = PlayerPrefs.GetFloat("healthpoint");
        //hp_text = GetComponent<Text>();
        //hp_text.text = "Halo " + hp.ToString();

        fullPanel = GameObject.FindWithTag("dismissPanel");
        fullPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // We divide decreasePerMinute by 60 to turn it into deacreasePerSecond.
        // We then multiply it by Time.deltaTime, which is the time, in seconds,
        // since Update was last called.
        hp -= decreasePerMinute  * Time.deltaTime / 60f;
        if (healthEvent != null)
            healthEvent.Invoke(hp);
        //int c = health;
        //hp_text.text = "Halo 2 " + (hp).ToString();
        if (hp <= 0)
        {
            hp = 0;
        }
        else if(hp>=100.1f)
        {
            hp = 100.1f;
            fullPanel.gameObject.SetActive(true);
        }
        else if(hp<=100)
        {
            fullPanel.gameObject.SetActive(false);
        }

        PlayerPrefs.SetFloat("healthpoint", HealthPointS.hp);
        PlayerPrefs.Save();

    }
   

    //void Update()
    //{
        
    //    playerHealth -= Time.deltaTime * decreasePerMinute / 60f;
    //}
}
