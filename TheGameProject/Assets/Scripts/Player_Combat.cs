using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float offset;
    private bool reloaded = true;
    private bool reloading = false;
    private float shotTime;
    private float reloadTime = 100.0f; //Reload cooldown not working
    
    public Transform shotPoint;




    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = mousePosition - transform.position;
        difference.z = 0;

        float rotZ = Mathf.Atan2(Mathf.Sign(difference.x)* difference.y, Mathf.Sign(difference.x) * difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        
        //Shooting
        if (reloaded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                reloaded = false;
                Debug.Log(reloaded);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                shotTime = Time.time;
                reloading = true;
            }
            else if (Time.time - shotTime < reloadTime && reloading)
            {
                Debug.Log("Ready to Fire");
                reloaded = true;
                reloading = false;
            }
        }
    }
}
