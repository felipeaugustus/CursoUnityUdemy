using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesimgDisplay;

    public Text scoreText;

    public SpawnManager spawnManager;

    public int score;

    public GameObject menu;

   

    void Start() 
    {
       
    }



   public void Updatelives(int vidasatual)
   {
       livesimgDisplay.sprite = lives[vidasatual];
   }

   public void UpdateScore()
   {
       score += 10;
       scoreText.text = "" + score;
   }

   public void ShowMenu() 
   {
       menu.SetActive(true);
   }

   public void CloseMenu() 
   {
       menu.SetActive(false);
       score = 0;
       scoreText.text = "0";
   }
}
