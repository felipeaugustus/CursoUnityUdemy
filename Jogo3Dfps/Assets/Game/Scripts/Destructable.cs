using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField]
    private GameObject crateDestroyed;

    public void DestroyCrate()
    {
        Instantiate(crateDestroyed, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
