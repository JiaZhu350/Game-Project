using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusketProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    private void Start()
    {
        Invoke("DestroyProjectile",lifeTime);
    }
    private void Update()
    {
        transform.Translate(transform.up * speed *Time.deltaTime);
    }
    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
