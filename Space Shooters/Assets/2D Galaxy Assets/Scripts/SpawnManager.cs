using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   //public bool isGamerunning = false;
   
   public GameObject playerPreFab;
   [SerializeField]
   private GameObject enemyshipPrefab;

    [SerializeField]
   private GameObject[] powerups;

   GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }
    public bool umavez = true;

    public void Spawner() 
    {
        StartCoroutine(SpawnerEnemyRoutine());
        StartCoroutine(SpawnerPowerUP());
    }
    public IEnumerator SpawnerEnemyRoutine() {
       // if (gameManager.gameover = false) {
        while (gameManager.gameover == false)
        {
            Instantiate(enemyshipPrefab, new Vector3(0, -15,0), Quaternion.identity);
            yield return new WaitForSeconds(3.5f);
        }
      //  }
    }
    public IEnumerator SpawnerPowerUP() {
        
        while (gameManager.gameover == false)
        {
            int randomPOWERUP = Random.Range(0,3);
            Instantiate(powerups[randomPOWERUP], new Vector3 (Random.Range(-7,7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
    }

}
