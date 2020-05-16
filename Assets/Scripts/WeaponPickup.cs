using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public string weaponName;  
    WeaponAttack wa;
    public bool oneHanded;
    void Start()
    {
        wa = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        Debug.Log("collision");
        if(coll.gameObject.tag == "Player" && Input.GetMouseButtonDown(1))
        {
            Debug.Log("Player Picked up: " + weaponName);
            if(wa.getCur()!= null)
            {
                wa.dropWeapon();
            }
            wa.setWeapon(this.gameObject, weaponName);
            this.gameObject.SetActive(false);
        }
    }
}
