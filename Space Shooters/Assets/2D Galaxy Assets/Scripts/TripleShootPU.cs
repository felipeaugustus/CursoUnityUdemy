using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShootPU : MonoBehaviour
{

    [SerializeField]
    private float velocidade = 3.0f;
    [SerializeField]
    private int powerupID; //0=tiro triplo 1=speed 2=shield

    [SerializeField]
    private AudioClip _clip;

    void Start() 
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * velocidade);
        if (transform.position.y < -8) 
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag ==  "Player") {
            Player player = other.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 0.7f);

            if (player !=null){
               
               if(powerupID == 0) {
                   player.TripleShootPowerON();
               }
               else if (powerupID == 1){
                   player.SpeedBoostON();               
               }
               else if (powerupID == 2) {
                   player.ShieldON();                
               }
               

                Destroy(this.gameObject);
            }
        
        }
    }
}
