using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacked : MonoBehaviour
{
    public Sprite knockedDown, stabbed, backUp;
    public GameObject bloodPool, bloodSpurt;
    SpriteRenderer sr;
    bool EnemyKnockedDown = false;
    float knockDownTimer = 3.0f;
    GameObject player;
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyKnockedDown == true)
        {
            knockDown();
        }
    }
    public void knockDownEnemy()
    {
        EnemyKnockedDown = true;
    }
    void knockDown()
    {
        knockDownTimer -= Time.deltaTime;
        sr.sprite = knockedDown;
        this.GetComponent<CircleCollider2D>().enabled = false;
        sr.sortingOrder = 2;
        this.GetComponent<EnemyAi>().enabled = false;
        if(knockDownTimer<= 0)
        {
            EnemyKnockedDown = false;
            sr.sprite = backUp;
            this.GetComponent<CircleCollider2D>().enabled = true;
            this.GetComponent<EnemyAi>().enabled = true;
            sr.sortingOrder = 5;
            knockDownTimer = 3.0f;
            
        }
    }
    public void killMelee()
    {
        sr.sprite = stabbed;
        Instantiate(bloodPool, this.transform.position, this.transform.rotation);
        Instantiate(bloodSpurt, this.transform.position, player.transform.rotation);
        sr.sortingOrder = 2;
        this.GetComponent<EnemyAi>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        this.gameObject.tag = "Dead";
    }
}
