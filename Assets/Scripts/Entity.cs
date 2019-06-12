using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int health = 0;
    public int maxHealth = 100;

    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float shootCd;
    public bool onCd;

    

    public void Start() {
        OnStart();
    }
    public virtual void OnStart() {
        health = maxHealth;
    }

    public  void TakeDamage(int dmg) {
        health -= dmg;
        if (health <= 0)
        {
            OnTakeDamage(dmg);
            Die();
        }
    }
    public virtual void OnTakeDamage(int dmg) {
    }
    public virtual void Die() {
        health = 0;
        Destroy(gameObject);
    }

    public void Shoot(Vector3 dir)
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
        Destroy(bullet, 2);

        bullet.GetComponent<Rigidbody>().velocity = dir * bulletSpeed;
        Invoke("RefreshCd", shootCd);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            TakeDamage(15);
            Destroy(collision.gameObject);
        }
    }
}
