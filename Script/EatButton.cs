using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EatButton : MonoBehaviour
{
    public Button yourButton;
    public GameObject fullPanel;
    // Start is called before the first frame update

    void Start()
    {
        yourButton = GetComponent<Button>();
        //Button btn = yourButton.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
        fullPanel = GameObject.FindWithTag("dismissPanel");
        fullPanel.gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick()
    {
        //PlayerPrefs.SetFloat("volume", 0.6f);
        //PlayerPrefs.SetString("username", "John Doe");

        if (HealthPointS.hp >= 100)
        {
            HealthPointS.hp = 0;
            fullPanel.gameObject.SetActive(true);
            //Open Panel For Full
        }
        else
        {
            HealthPointS.hp += 10;
        }
        //PlayerPrefs.SetInt("healthpoint", HealthPointS.hp);
        //PlayerPrefs.Save();

        Debug.Log("You have clicked the button!");
    }
}
