using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Makanan : MonoBehaviour
{
    public Vector2 defaultpos;
    public SpriteRenderer spriteRenderer;
    public Sprite normal;
    //public GameObject burger;
    public static bool statusdrag;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        statusdrag = false;
        //burger = GameObject.Find("Burger");
        //defaultpos = (Vector2)burger.transform.position;
        Debug.Log(defaultpos);
        //GameObject.Find("Burger").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(statusdrag==false)
            transform.position = new Vector2(0, -3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "makanan")
        {
            statusdrag = false;
                //spriteRenderer.sprite = normal;
            //SceneManager.LoadScene("MainMenu");

            
            Debug.Log("Makan bang!");
            HealthPointS.hp += 10;
            StatIcon.gold -= 10;
        }

    }


}
