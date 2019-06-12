using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public float speed;
    private Vector3 targetPos;
    public float targetCd;


    public override void OnStart()
    {
        base.OnStart();

        InvokeRepeating("CalculateTargetPos", 0.1f, .5f);
        Invoke("IaShoot", Random.Range(1, 3));
    }
    private void Update()
    {
        Move();
    }
    public void Move()
    {
        transform.LookAt(targetPos);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    void CalculateTargetPos() {
        targetPos = Player.instance.transform.position + Vector3.forward * Random.Range(-10, 10) + Vector3.right * Random.Range(-10, 10);

        targetPos = new Vector3(targetPos.x, transform.position.y, targetPos.z);
    }
    void IaShoot() {

        GameObject bullet = GameObject.Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
        Destroy(bullet, 2);

        Vector3 dir = Player.instance.transform.position + Player.instance.lastDir * Player.instance.speed;

        bullet.GetComponent<Rigidbody>().velocity = dir.normalized * bulletSpeed;
        Invoke("IaShoot", Random.Range(0.5f, 1.5f));
    }
}
