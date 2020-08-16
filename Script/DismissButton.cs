using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DismissButton : MonoBehaviour
{
    public Button dismissButton;
    // Start is called before the first frame update
    public GameObject fullPanel;
    void Start()
    {
        dismissButton = GetComponent<Button>();
        //Button btn = yourButton.GetComponent<Button>();
        dismissButton.onClick.AddListener(dismiss);
        fullPanel = GameObject.FindWithTag("dismissPanel");
    }
    // Update is called once per frame
    void Update()
    {

    }
    void dismiss()
    {
        fullPanel.gameObject.SetActive(false);
        //PlayerPrefs.SetFloat("volume", 0.6f);
        //PlayerPrefs.SetString("username", "John Doe");

        //if (HealthPointS.hp >= 100)
        //{
        //    HealthPointS.hp = 0;
        //    //Open Panel For Full
        //}
        //else
        //{
        //    HealthPointS.hp += 10;
            

        //}
        //PlayerPrefs.SetInt("healthpoint", HealthPointS.hp);
        //PlayerPrefs.Save();

        Debug.Log("You have clicked the dismiss button!");
    }

}
