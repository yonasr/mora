using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public const int gridRows = 4;
    public const int gridCols = 3;
    public const float offsetX = 1.7f;
    public const float offsetY = 1.7f;

    [SerializeField] private MainCard originalCard;
    [SerializeField] private Sprite[] images;
    public float myTime;

    public GameObject winningPanel;
    public Button[] buttons;
    public Button back;
    public Button restart;

    public Text[] texts;
    public Text p_score;
    public Text p_time;
    //Button b2;
    Text score_text;
    //public Button[] buttonss;
    //Object Button
    //public Button butt1;
    //public Button butt3;
    public float gold;

    private void Start()
    {
        gold = PlayerPrefs.GetFloat("gold");
        winningPanel = GameObject.Find("WinningPanel");
        winningPanel.gameObject.SetActive(false);
        buttons = winningPanel.GetComponentsInChildren<Button>();
        back = buttons[0];
        restart = buttons[1];

        texts = winningPanel.GetComponentsInChildren<Text>();
        p_time = texts[0];
        p_score = texts[1];

        score_text = GameObject.Find("Score").GetComponent<Text>();
        Vector3 startPos = originalCard.transform.position; //The position of the first card. All other cards are offset from here.

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
        numbers = ShuffleArray(numbers); //This is a function we will create in a minute!
        myTime = 0;
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MainCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MainCard;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.ChangeSprite(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }
    private int _score = 0;
    public bool state = false;
    void Update()
    {
        if (_score != 6)
            myTime += Time.deltaTime;
        else if(_score==6)
        {
            // Open Panel 
            //menang
            p_time.text= "Time: " + myTime;
            p_score.text = "Score: " + _score;
            Debug.Log("before");
            Debug.Log(gold);
            state = true;

           
            winningPanel.SetActive(true);
            gold += 10;
            Debug.Log("after");
            Debug.Log(gold);
            PlayerPrefs.SetFloat("gold", gold);
            PlayerPrefs.Save();

             _score = 0;
            
        }
            
    }


    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------

    private MainCard _firstRevealed;
    private MainCard _secondRevealed;

    

    [SerializeField] private Text scoreLabel;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public void CardRevealed(MainCard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
           // hp_text.text = "Sekor: " + (_score).ToString();
            scoreLabel.text = "Score: " + _score;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;

    }

    public void Restart()
    {
       // SceneManager.LoadScene("Scene_001");
    }


    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
