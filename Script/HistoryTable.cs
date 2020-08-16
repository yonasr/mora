using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree; 
public class HistoryTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    public static List<JawabanPertanyaan> saved;

    public class JawabanPertanyaan 
    {
        public string pertanyaan;
        public string jawabpilihan; 
    }

    // Start is called before the first frame update
    void Start()
    {
        saved = new List<JawabanPertanyaan> ();
        saved = SaveGame.Load<List<JawabanPertanyaan>>("saveJawaban");
        Debug.Log(saved.Count);

        entryContainer = transform.Find("HistoryEntryContainer");
        entryTemplate = entryContainer.Find("HistoryEntryTemplate");
        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 300f;
        for(int i = 0; i < saved.Count; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            entryTransform.Find("Pertanyaan").GetComponent<Text>().text = saved[i].pertanyaan;
            entryTransform.Find("Jawaban").GetComponent<Text>().text = saved[i].jawabpilihan;
            
        }
    }
    private void Awake()

    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
