using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private UIManager uIManager;
    private CharacterController _controller;
    [SerializeField]
    private float speed = 3.5f;
    [SerializeField]
    private GameObject flash;
    [SerializeField]
    private GameObject hitMarker;
   [SerializeField]
    private int currentAmmo;
    private int maxAmmo = 100;

    private bool isReloading = false;

    private float gravity = 9.81f;

    public bool hasCoin = false;
    public bool isCoinActive = false;
    private bool hasWeapon = false;

    [SerializeField]
    private GameObject weapon;
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       // flash.SetActive(false);
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButton(0) && currentAmmo > 0 && hasWeapon == true)
        {
           
           Shoot();
           
        }
        else 
        {
            flash.SetActive(false);   
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        Movements();
        if (Input.GetKeyDown(KeyCode.R) && isReloading == false) 
        {
            StartCoroutine(Reload());    
        }

        if (hasCoin == true && isCoinActive == false) 
        {
            uIManager.ShowCoin();
            
        }

    }
    void Movements() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput ,0, verticalInput);
        Vector3 velocity = direction * speed;
        velocity.y -= gravity;
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }
    void Shoot() 
    {
        currentAmmo --;
        uIManager.UpdateAmmo(currentAmmo);
        flash.SetActive(true);
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, out hitInfo)) 
         {
            Debug.Log("atingiu" + hitInfo.transform.name);
            GameObject hitMarkera = Instantiate(hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal) );
            Destroy(hitMarkera,1);

           Destructable crate = hitInfo.transform.GetComponent<Destructable>();
           if (crate != null) 
           {
               crate.DestroyCrate();
           }
        }
    }

    IEnumerator Reload() 
    {
        isReloading = true;
        yield return new WaitForSeconds(2f);
        currentAmmo = maxAmmo;
        uIManager.UpdateAmmo(currentAmmo);
        isReloading = false;
        
    }
    
    public void ActivateWeapon() 
    {
        weapon.SetActive(true);
        hasWeapon = true;
    }
}
    