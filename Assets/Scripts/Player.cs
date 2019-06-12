using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    public float speed;

    
    public static Player instance;


    public Vector3 lastDir;

    public Text healthText;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public override void OnTakeDamage(int dmg)
    {
        base.OnTakeDamage(dmg);
        healthText.text = health.ToString();
    }
    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }
    private void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        lastDir = (Vector3.forward * ver + Vector3.right * hor).normalized;
        transform.position += lastDir * speed * Time.deltaTime;
    }
    void Shoot() {

        if (onCd) return;
      
        Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Vector3 hitPos = hit.point;
            Vector3 dir = (hitPos - transform.position).normalized;
            Shoot(dir);
        }
          
    }
    
    void RefreshCd() {
        onCd = false;
    }

    
}
