using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField]
   private AudioClip pickupaudio;

   


    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Player player = other.GetComponent<Player>();
            player.hasCoin = true;
            AudioSource.PlayClipAtPoint(pickupaudio, transform.position, 1f);
            Destroy(this.gameObject);
        }
    }
}
