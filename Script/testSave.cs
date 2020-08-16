using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class testSave : MonoBehaviour
{
    public GameObject test;
    public List<Summary> history;
    public static List<Message> dictionary;


    public class Jawaban
    {
        public int id;
        public string jawab;

        public void setParam(int id, string jawab){
             id = id;
            jawab = jawab;
        }
    }
    public class Message
    {
        public int id;
        public string pertanyaan;
        public int tipe;
        public List<Jawaban> jawabs;
        public bool completed;

        public void SetMessage(int id, string pertanyaan, int tipe, List<Jawaban> jawab)
        {
            id = id;
            pertanyaan = pertanyaan;
            tipe = tipe;
            jawabs = jawab;
        }
        public void SetMessage(int id, string pertanyaan, int tipe, Jawaban jawab)
        {
            id = id;
            pertanyaan = pertanyaan;
            tipe = tipe;
            jawabs = new List<Jawaban>();
            jawabs.Add(jawab);
        }
        public void SetMessage(int id, string pertanyaan, int tipe)
        {
            id = id;
            pertanyaan = pertanyaan;
            tipe = tipe;
        }

    }
    public class Summary
    {
        public int pertanyaan;
        public string jawaban;

        public Summary(int p, string j)
        {
            pertanyaan = p;
            jawaban = j;

        }
    }
    public class CustomData // Ini data yang mau di save
    {

        public int score;
        public int highScore;
        public List<Summary> summary;

        public CustomData()
        {
            score = 0;
            highScore = 0;
            //Message p1;
            //Jawaban j1;

            // Dummy data
            summary = new List<Summary>() {
                    new Summary ( 1, "A" ),
                   // new Summary(p1.id, j1.id ),

                    new Summary ( 5, "500g" )
                };
        }

    }

    public class PlayerData 
    {
        public int score;
        public string name; 
    }
    
    void pertanyaan() 
    {

    }
    // Start is called before the first frame update
    void Start()
    {

        PlayerData data = new PlayerData (); 
        data.score = 453; 
        data.name = "John";

        SaveGame.Save<PlayerData> ("playerdata", data);

        //Perlu Load Dulu

        Jawaban j1 = new Jawaban();
        j1.id = 1;
        j1.jawab = "Less than 15 minutes";
        Jawaban j2 = new Jawaban();
        j2.id = 2;
        j2.jawab = "Around 15 to 30 minutes";
        Jawaban j3 = new Jawaban();
        j3.id = 3;
        j3.jawab = "About 30 to 50 minutes";
        Jawaban j4 = new Jawaban();
        j4.id = 4;
        j4.jawab = "More than 50 minutes";
        Jawaban j6 = new Jawaban();
        j6.id = 6;
        j6.jawab = "Very Good";
        Jawaban j7 = new Jawaban();
        j7.id = 7;
        j7.jawab = "Good";
        Jawaban j8 = new Jawaban();
        j8.id = 8;
        j8.jawab = "Neutral";
        Jawaban j9 = new Jawaban();
        j9.id = 9;
        j9.jawab = "Sad";
        Jawaban j10 = new Jawaban();
        j10.id = 10;
        j10.jawab = "Yes, I already had the supplement! Thank you for the reminder.";
        Jawaban j11 = new Jawaban();
        j11.id = 11;
        j11.jawab = "No I'll take them later.";


        List<Jawaban> jawaban1 = new List<Jawaban>();
        jawaban1.Add(j1);
        jawaban1.Add(j2);
        jawaban1.Add(j3);
        jawaban1.Add(j4);

        List<Jawaban> jawaban2 = new List<Jawaban>();
        jawaban2.Add(j6);
        jawaban2.Add(j7);
        jawaban2.Add(j8);
        jawaban2.Add(j9);

        List<Jawaban> jawaban3 = new List<Jawaban>();
        jawaban3.Add(j10);
        jawaban3.Add(j10);
        jawaban3.Add(j11);
        jawaban3.Add(j11);

        Message p1 = new Message();
        p1.id = 1;
        p1.tipe = 2;
        p1.jawabs = jawaban1;
        p1.pertanyaan = "How many minutes do you exercise this week? Yeah, juts approximate will do.";

        Message p2 = new Message();
        p2.id = 2;
        p2.tipe = 0;
        p2.pertanyaan = "I love spending time with you, but I don't mind if you take your time to keep yourself in shape.";
 
        Message p3 = new Message();
        p3.id = 3;
        p3.tipe = 1;
        p3.pertanyaan = "Do you mind telling what sort of excercise you do?";

        Message p4 = new Message();
        p4.id = 4;
        p4.tipe = 0;
        p4.pertanyaan = "Being overweight is already not healthy, especially during pregnancy! Make sure you have healthy diet and keep yourself physically active.";

        Message p5 = new Message();
        p5.id = 5;
        p5.tipe = 0;
        p5.pertanyaan = "Ginger, chamomile, vitamin B6 and/or acupuncture are recommended for the relief of nausea in early pregnancy";
        
        Message p6 = new Message();
        p6.id = 6;
        p6.tipe = 2;
        p6.jawabs = jawaban2;
        p6.pertanyaan = "How are you feeling today?";

        Message p7 = new Message();
        p7.id = 7;
        p7.tipe = 2;
        p7.jawabs = jawaban3;
        p7.pertanyaan = "Did you take your daily iron and folic acid supplement? They are important for healthy pregnancy!";
        
        Message p8 = new Message();
        p8.id = 8;
        p8.tipe = 0;
        p8.pertanyaan = "Hi! Just a gentle reminder, have you take your supplement already?";

        Message p9 = new Message();
        p9.id = 9;
        p9.tipe = 0;
        p9.pertanyaan = "Did you know, high caffeine intake (5 cups of instant coffee a day) could lead to some issues during pregnancy! Make sure to drink moderately.";

        Message p10 = new Message();
        p10.id = 10;
        p10.tipe = 0;
        p10.pertanyaan = "I'm slightly worried... Did you get exposed to cigarrate smoke this week?";
        
        dictionary = new List<Message>();
        dictionary.Add(p1);
        dictionary.Add(p2);
        dictionary.Add(p3);
        dictionary.Add(p4);
        dictionary.Add(p5);
        dictionary.Add(p6);
        dictionary.Add(p7);
        dictionary.Add(p8);
        dictionary.Add(p9);
        dictionary.Add(p10);

    }

    // Update is called once per frame
    void Update()
    {
        PlayerData saved = SaveGame.Load<PlayerData> ( "playerdata" );
        Debug.Log(saved.score);
    }
}
