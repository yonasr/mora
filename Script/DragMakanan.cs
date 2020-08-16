using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMakanan : MonoBehaviour
{
    //public GameObject burger;
    //public SpriteRenderer spriteRenderer;

    static bool moveAllowed;
    Collider2D col;
    //Collider2D burgercol;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        //burgercol = burger.GetComponent<Collider2D>();
        //burger = GameObject.Find("Burger");
        //spriteRenderer = burger.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.touchCount);
        if (Input.touchCount > 0)
        {
            //Debug.Log("Burger Touched");
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Makanan.statusdrag = true;
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider)
                {
                    moveAllowed = true;
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {

                moveAllowed = false;
                Makanan.statusdrag = false;
            }

        }
    }


    static public bool  getMoveAllowed()
    {
        return moveAllowed;
    }
}
