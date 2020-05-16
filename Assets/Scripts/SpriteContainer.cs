using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteContainer : MonoBehaviour
{
    public Sprite[] pUnarmedWalk, pPunch, pStick,pLongAxe,pStickWalk,pLegs,pLongAxeWalk;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public Sprite[] getPlayerUnarmedWalk()
    {
        return pUnarmedWalk;
    }
    public Sprite[] getWeaponWalk(string weapon)
    {
        switch (weapon)
        {
            case "Stick":
                return pStickWalk;
            case "LongAxe":
                return pLongAxeWalk;
            default:
                return getPlayerUnarmedWalk();
        }
    }
    public Sprite[] getPlayerLegs()
    {
        return pLegs;
    }
    public Sprite[] getPlayerPunch()
    {
        return pPunch;
    }

    public Sprite[] getWeapon(string weapon)
    {
        switch (weapon)
        {
            case "Stick":
                return pStick;
            case "LongAxe":
                return pLongAxe;
            default:
                return getPlayerPunch();
             
        }
    }
}
