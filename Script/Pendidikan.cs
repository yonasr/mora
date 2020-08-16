using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree;

public class Pendidikan : MonoBehaviour
{
    //Define Panel
    public GameObject pendidikan;
    public GameObject pilihan;
    public GameObject isian;
    
    public float playedTime = 0;
    
    //Text Informasi
    public Text pesan_pendidikan;
    public Text pesan_pilihan;
    public Text pesan_isian;


    public Button[] buttonss;
    //Object Button
    public Button butt1;
    public Button butt3;
    public Button butt2;
    public Button butt4;

    public Button buttisian;

    public InputField input; 

    public int x;

    public static List<JawabanPertanyaan> saved;
    public List<JawabanPertanyaan> haha;
    

    private bool state_pesan = true;


    void Start()
    {
        Debug.Log("Start");
        
        //Disini Load Dulu File e
        saved = new List<JawabanPertanyaan> ();
        saved = SaveGame.Load<List<JawabanPertanyaan>>("saveJawaban");        
        
        //Debug.Log(saved.Count);
        if (saved == null)
            Debug.Log("Still empty");
        else
         {
             Debug.Log(saved[0].pertanyaan);
             Debug.Log(saved[0].jawabpilihan);
             }
        
        //Panel
        pendidikan = GameObject.FindWithTag("bg_pendidikan");
        pendidikan.gameObject.SetActive(false);
        
        pilihan = GameObject.FindWithTag("bg_pilihan");
        pilihan.gameObject.SetActive(false);

        isian = GameObject.FindWithTag("bg_isian");
        isian.gameObject.SetActive(false);
        
        
        buttonss = pilihan.GetComponentsInChildren<Button>();
       // Debug.Log(buttonss);

        //Define Button 
        butt1 = buttonss[0];
        butt2 = buttonss[1];
        butt3 = buttonss[2];
        butt4 = buttonss[3];

        buttisian = isian.GetComponentInChildren<Button>();
        
        x = 0;

        input = isian.GetComponentInChildren<InputField>();        
    }

    void Update()
    {
       playedTime += Time.deltaTime;
       
        if (playedTime > 5 & state_pesan == true)
        {
           
            x = outputPendidikan();

            if(testSave.dictionary[x].tipe==0)
            {
                //panel yang informasi ctive
                pendidikan.gameObject.SetActive(true);
                pesan_pendidikan.text = testSave.dictionary[x].pertanyaan ;
                state_pesan = false;
                //Save nanti 
            }

            else if(testSave.dictionary[x].tipe==2)
            {
                //panel yang pilihan active
                pilihan.gameObject.SetActive(true);

                //pertanyaan
                pesan_pilihan.text = testSave.dictionary[x].pertanyaan ;
               
                //tulisan di button
                butt1.GetComponentInChildren<Text>().text = testSave.dictionary[x].jawabs[0].jawab ;
                butt2.GetComponentInChildren<Text>().text = testSave.dictionary[x].jawabs[1].jawab ;
                butt3.GetComponentInChildren<Text>().text = testSave.dictionary[x].jawabs[2].jawab ;
                butt4.GetComponentInChildren<Text>().text = testSave.dictionary[x].jawabs[3].jawab ;

                butt1.onClick.AddListener(() => submitJawaban(testSave.dictionary[x].jawabs[0].jawab));
                butt2.onClick.AddListener(() => submitJawaban(testSave.dictionary[x].jawabs[0].jawab));
                butt3.onClick.AddListener(() => submitJawaban(testSave.dictionary[x].jawabs[0].jawab));
                butt4.onClick.AddListener(() => submitJawaban(testSave.dictionary[x].jawabs[0].jawab));

                state_pesan = false;
                //Save nanti
            }
            else if(testSave.dictionary[x].tipe==1)
            {
                //panel yang isian active
                isian.gameObject.SetActive(true);

                //show pertanyaan
                pesan_isian.text = testSave.dictionary[x].pertanyaan ;
                //buttisian.onClick.AddListener(a);
                
                //buttisian.onClick.AddListener(delegate{submitJawaban(input.text);});
                buttisian.onClick.AddListener(() => submitJawaban(input.text));

                //button.... (submitJawaban(input.Text))
                //.AddListener(submitJawaban);

                state_pesan = false;
                //Save nanti
            }
        }
        if (testSave.dictionary[x].tipe==0 && playedTime >= 10) 
        {
            pendidikan.gameObject.SetActive(false);
        }
    }

    public void submitJawaban(string isinya_input) 
    {
       
        JawabanPertanyaan data = new JawabanPertanyaan (); 
        haha = new List<JawabanPertanyaan>();
        haha = SaveGame.Load<List<JawabanPertanyaan>>("saveJawaban"); 
        
        data.pertanyaan = testSave.dictionary[x].pertanyaan; 
        data.jawabpilihan = isinya_input;
        // Debug.Log(data.pertanyaan);
        // Debug.Log(data.jawabpilihan);

        // saved.Add(data);
        if(haha==null)
        {
            haha = new List<JawabanPertanyaan>();
            haha.Add(data);
        }

        else{
            haha.Add(data);
        }
            

        SaveGame.Save<List<JawabanPertanyaan>> ("saveJawaban", haha);

        isian.gameObject.SetActive(false);
        pilihan.gameObject.SetActive(false);

    }
    public int outputPendidikan()
    {
       // Debug.Log( testSave.dictionary.Count);
        return Random.Range(0, testSave.dictionary.Count);
    }

    public class JawabanPertanyaan 
    {
        public string pertanyaan;
        public string jawabpilihan; 
    }

}