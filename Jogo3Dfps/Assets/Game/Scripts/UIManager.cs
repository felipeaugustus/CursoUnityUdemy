using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text AmmoText;
    [SerializeField]
    public GameObject coin; 
    
    public void UpdateAmmo(int count)
    {
        AmmoText.text = count + "/100";
    }

    public void ShowCoin()
    {
        coin.SetActive(true);
    }
    
    public void RemoveCoin()
    {
        coin.SetActive(false);
    }
   
}
