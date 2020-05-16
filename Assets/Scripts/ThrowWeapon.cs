﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour
{
    EnemyAttacked attacked;
    float timer = 2.0f;
    Vector3 direction;
    Rigidbody2D rid;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rid = this.GetComponent<Rigidbody2D>();
        rid.AddForce(direction * 40);

    }
    
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(this.transform.rotation, new Quaternion(this.transform.rotation.x, this.transform.rotation.y,this.transform.rotation.z - 1, this.transform.rotation.w), Time.deltaTime *timer);
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            rid.isKinematic = true;
            Destroy(this);
        }
    }
    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }
    void OnTrigger2d(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            attacked = col.gameObject.GetComponent<EnemyAttacked>();
            attacked.knockDownEnemy();
            rid.isKinematic = true;
            Destroy(this);
        }
        else if(col.gameObject.tag =="Player")
        {

        }
        else
        {
            rid.isKinematic = true;
            Destroy(this);
        }
    }

}
