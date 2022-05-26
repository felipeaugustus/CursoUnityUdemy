using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    
    UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
       
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player")
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player.hasCoin == true) {
                    player.hasCoin = false;
                    uIManager.RemoveCoin(); 
                    player.ActivateWeapon();
                    AudioSource audio = GetComponent<AudioSource>();
                    audio.Play();
                }
                else 
                {
                    //falar que não é possivel dar a arma de graça
                }
            }
        }
    }
}
