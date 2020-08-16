using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ChangeScene : MonoBehaviour
{
    public void GoToBath () 
    {
        SceneManager.LoadScene("KamarMandi");
    }
    
    public void GoToEat () 
    {
        SceneManager.LoadScene("TempatMakan");
    }
    
    public void GoToMain () 
    {
        SceneManager.LoadScene("MainScreen");
    }
    
    public void GoToMiniGame () 
    {
        SceneManager.LoadScene("MiniGame");
    }
}