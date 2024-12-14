using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float offset;
    [SerializeField] private float time2Shoot;
    private float startTime;
    public Transform shotPoint;




    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = mousePosition - transform.position;
        difference.z = 0;

        float rotZ = Mathf.Atan2(Mathf.Sign(difference.x)* difference.y, Mathf.Sign(difference.x) * difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        
        //Shooting
        if (time2Shoot <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                time2Shoot = startTime;
            }
        }
        else
        {
            time2Shoot -= Time.deltaTime;
        }
    }
}
