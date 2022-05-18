using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public bool podeTiroTriplo = false;
    public bool speedBoost = false;
    public bool shield = false;

    SpawnManager spawnManager;

    public int lives = 3;

    [SerializeField]
    private GameObject _shieldgameObject;

    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private float fireRate = 0.25f;
    private float nextFire = 0.00f;

    [SerializeField]
    private float velocidade = 8.0f;

    private UIManager _uiManager;
    private GameManager _gameManager;
    private SpawnManager _spawnManaager;

    private AudioSource _audioSource;

    public GameObject[] motores;

    [SerializeField]
    private int hitCount = 0;


    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _spawnManaager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _audioSource = GetComponent<AudioSource>();

        if (_uiManager != null)
        {
            _uiManager.Updatelives(lives);
        }

        _spawnManaager.Spawner();
        
        hitCount = 0;

    }
    // Update is called once per frame
    void Update()
    {
       Moviments();

       if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) {
           Shoot();
       }
    }

    private void Moviments() {
         float horizontalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");
        if (speedBoost == true) {
            transform.Translate(Vector3.right * Time.deltaTime * velocidade * horizontalinput * 1.75f);
            transform.Translate(Vector3.up * Time.deltaTime * velocidade * verticalinput * 1.75f);
        }
        else {
            transform.Translate(Vector3.right * Time.deltaTime * velocidade * horizontalinput);
            transform.Translate(Vector3.up * Time.deltaTime * velocidade * verticalinput);
        }


       if (transform.position.y > 4.3f) {
           transform.position = new Vector3(transform.position.x, 4.3f, 0);

       }
       else if (transform.position.y < -4.3f) {
           transform.position = new Vector3(transform.position.x, -4.3f, 0);
       }

       if (transform.position.x > 8.4f) {
           transform.position = new Vector3(8.4f, transform.position.y, 0);
       }
       else if (transform.position.x < -8.4) {
           transform.position = new Vector3(-8.4f, transform.position.y, 0);
       }
    }
    private void Shoot() {
        if (podeTiroTriplo == false) {
         if (Time.time > nextFire ){
               Instantiate(laserPrefab, transform.position + new Vector3 (0, 1, 0), Quaternion.identity);
               nextFire = Time.time + fireRate;
               _audioSource.Play();
           }
        }
        else {
            if (Time.time > nextFire ){
               Instantiate(laserPrefab, transform.position + new Vector3 (0, 1, 0), Quaternion.identity);
               Instantiate(laserPrefab, transform.position + new Vector3 (-0.55f, 0.1f, 0), Quaternion.identity);
               Instantiate(laserPrefab, transform.position + new Vector3 (0.55f, 0.1f, 0), Quaternion.identity);
               nextFire = Time.time + fireRate;
               _audioSource.Play();
        }
    }    
    }
    public void TripleShootPowerON(){
        podeTiroTriplo = true;
        StartCoroutine(PowerUpTiroTriploRotina());
    }
    public IEnumerator PowerUpTiroTriploRotina() {
        yield return new WaitForSeconds(8.0f);

        podeTiroTriplo = false;
    } 

    public void SpeedBoostON() {
        speedBoost = true;
        StartCoroutine(SpeedBoostRotina());
    }
    public IEnumerator SpeedBoostRotina() {
        yield return new WaitForSeconds(8.0f);
        
        speedBoost = false;
    }

    public void ShieldON() {
        shield = true;
        _shieldgameObject.SetActive(true);
       // ShieldONRotina();
    }
    /*public IEnumerator ShieldONRotina() {
        yield return new WaitForSeconds(16.0f);
        shield = false;
    }*/

    public void Damage() {
        

        if(shield == false) {
        lives --;
        _uiManager.Updatelives(lives);
        hitCount++;
        if (hitCount == 1) 
        {
            motores[0].SetActive(true);
        }
        else if (hitCount == 2)
        {
            motores[1].SetActive(true);
        }
        if (lives < 1) {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            _uiManager.ShowMenu();
            _gameManager.gameover = true;
            Destroy(this.gameObject);
        }
        }
        else {
            shield = false;
            _shieldgameObject.SetActive(false);
        }
    }
}