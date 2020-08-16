using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dismissPanel : MonoBehaviour
{
    public GameObject dPanel;
    // Start is called before the first frame update
    void Start()
    {
        dPanel = GameObject.FindWithTag("dismissPanel");
        dPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void OnDeselect(BaseEventData eventData)
    //{
    //    //Mouse was clicked outside
    //    dPanel.gameObject.SetActive(false);
    //}
}
