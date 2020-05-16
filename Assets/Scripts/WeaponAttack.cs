using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public GameObject oneHandSpawn, twoHandSpawn;
    GameObject bullet, curWeapon;
    float timer = 0.1f, timerReset = 0.1f;
    PlayerAnimation pa;
    SpriteContainer sc;

    float weaponChange = 0.5f;
    bool changingWeapon = false;
    bool oneHanded = false;
    void Start()
    {
        pa = this.GetComponent<PlayerAnimation>();

        sc = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpriteContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (Input.GetMouseButton(0) && timer<=0)
        {
            attack();
        }
        if (Input.GetMouseButtonDown(0))
        {
            pa.resetCounter();
        }
        if (Input.GetMouseButtonUp(0))
        {

            pa.resetCounter();
        }

        if (Input.GetMouseButtonDown(1) && changingWeapon == false)
        {
            dropWeapon();
        }

        if (changingWeapon == true)
        {
            weaponChange -= Time.deltaTime;
            if(weaponChange <= 0)
            {
                changingWeapon = false;
            }
        }
    }
    public void setWeapon(GameObject cur, string name)
    {
        changingWeapon = true;
        curWeapon = cur;
        pa.setNewTorso(sc.getWeaponWalk(name), sc.getWeapon(name));
    }
    public void attack()
    {
        int layerMask = 1 << 9;
        layerMask = ~layerMask;
        pa.attack();
        RaycastHit2D ray = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(transform.up.x, transform.up.y), 1.5f, layerMask);
        Debug.DrawRay(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(transform.up.x, transform.up.y));
        if (curWeapon == null && ray.collider.gameObject.tag=="Enemy")
        {
            EnemyAttacked ea = ray.collider.gameObject.GetComponent<EnemyAttacked>();
            ea.knockDownEnemy();
        }
        else if (ray.collider != null)
        {
            Debug.Log(ray.collider.gameObject.tag);
            if(ray.collider.gameObject.tag == "Enemy")
            {
                EnemyAttacked ea = ray.collider.gameObject.GetComponent<EnemyAttacked>();
                ea.killMelee();
            }
        }

    }
    public GameObject getCur()
    {
        return curWeapon;
    }
    public void dropWeapon()
    {
        if (curWeapon == null)
        {
        }
        else
        {
            curWeapon.transform.position = this.transform.position;
            curWeapon.SetActive(true);
            setWeapon(null, "");
          
        }
    }


}
