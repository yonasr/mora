using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPointS_old : MonoBehaviour
{
    public static int hp = 0;
    Text hp_text;
    // Start is called before the first frame update
    void Start()
    {
        hp = PlayerPrefs.GetInt("healthpoint");
        hp_text = GetComponent<Text>();
        hp_text.text = "Halo " + hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        hp_text.text = "Halo 2 " + hp.ToString();
    }
}
