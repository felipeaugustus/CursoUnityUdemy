using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float velocidade = 2.0f;

    [SerializeField]
    private GameObject _enemyExplosionPrefab;

    private UIManager _uiManager;

    private GameManager gameManager;


    void Start() {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
    void Update()
    {
        transform.Translate(Vector3.down * velocidade * Time.deltaTime);

        if (transform.position.y < - 7.1f) {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 7.3f , 0);
        }
        if (gameManager.gameover == true) {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Laser" ) {
            _uiManager.UpdateScore();
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            }
        else if (other.tag == "Player") {
            Player player = other.GetComponent<Player>();
            if (player != null) {
                _uiManager.UpdateScore();
                Destroy(this.gameObject);
                Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
                player.Damage();
            }
        }
        }
    }

