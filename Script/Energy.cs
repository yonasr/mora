using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Energy : MonoBehaviour
{
    // public Sprite normal;
    // public Sprite happy;
    // public Sprite sad;



    //public static int hp = 0;
    Text energy_text;

    public class HealthEvent : UnityEvent<float> { };
    public static float energy;
    // = 100.1f;
    public HealthEvent healthEvent;
    private const float coef = 0.1f;

    //public float playerHealth;
    public float decreasePerMinute=1000;

    public GameObject fullPanel;

    // Start is called before the first frame update
    void Start()
    {
        energy = PlayerPrefs.GetFloat("energy");
       // hp_text = GetComponent<Text>();
       // hp_text.text = "Halo " + hp.ToString();

      //  fullPanel = GameObject.FindWithTag("dismissPanel");
      //  fullPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // We divide decreasePerMinute by 60 to turn it into deacreasePerSecond.
        // We then multiply it by Time.deltaTime, which is the time, in seconds,
        // since Update was last called.
        energy -= decreasePerMinute  * Time.deltaTime / 60f;
        if (healthEvent != null)
            healthEvent.Invoke(energy);
        //int c = health;
        //hp_text.text = "Halo 2 " + (hp).ToString();
        if (energy <= 0)
        {
            energy = 0;
        }
        else if(energy>=100.1f)
        {
            energy = 100.1f;
            //fullPanel.gameObject.SetActive(true);
        }
        else if(energy<=100)
        {
            //fullPanel.gameObject.SetActive(false);
        }

        PlayerPrefs.SetFloat("energy", Energy.energy);
        PlayerPrefs.Save();

    }
}
