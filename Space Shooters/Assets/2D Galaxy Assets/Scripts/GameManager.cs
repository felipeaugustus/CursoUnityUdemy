using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameover = true;
    
     public GameObject playerPreFab;

    private UIManager _uIManager;
     SpawnManager spawnManager;

     

     void Start() 
     {
         _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
         spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
     }
   void Update()
    {
        if (gameover == true) {
        if (Input.GetKeyUp(KeyCode.Space)) {
            
            Instantiate(playerPreFab, new Vector3(0, 0, 0), Quaternion.identity);
         //    StartCoroutine(SpawnerEnemyRoutine());
         //    StartCoroutine(SpawnerPowerUP());
             _uIManager.CloseMenu();
             gameover = false;
        }
        
        }
    }
}
