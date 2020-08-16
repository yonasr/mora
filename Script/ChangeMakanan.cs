using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMakanan : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite pizza;
    public Sprite ice_cream;
    public Sprite apel;
    public Sprite cola;
    public Sprite banana;
    public Sprite water;

    public int status;

    public Sprite[] foods;

    public Button yourButton;

    // Start is called before the first frame update
    void Start()
    {
        //yourButton = GetComponent<Button>();
        yourButton = GameObject.Find("SwitchFood").GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        status = 0;
        foods = new Sprite[] { pizza, ice_cream, apel, cola, banana, water };
        //public Sprite[] familyMembers = new Sprite[] { "Greg", "Kate", "Adam", "Mia" };
        //Sprite[] foods = new Sprite[] {pizza, ice_cream, apel, cola, banana, water };
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = foods[status % 6];
        //if (HealthPointS.hp <= 30)
        //{
        //    //myObject.GetComponent<MyScript>().MyFunction();
        //    spriteRenderer.sprite = sad;
        //}
        //else if (HealthPointS.hp < 100)
        //{
        //    spriteRenderer.sprite = normal;
        //}
        //else
        //{
        //    spriteRenderer.sprite = happy;
        //}
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        status++;
        
    }
}
