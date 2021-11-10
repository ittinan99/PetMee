using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetStats : MonoBehaviour
{
    [SerializeField]
    protected float hungryrate;
    protected float happinessrate;
    protected float cleanlinessrate;
    protected float healrate;

    protected float hungrylavel;
    protected float happinessLavel;
    protected float cleanLavel;
    protected float heallavel;
    

    protected void hungry(float hp)
    {
        if (hp <= 50 && hp >= 26)
        {
            Debug.Log("hungry"); 
        }
        if (hp <= 25 && hp >= 1)
        {
            Debug.Log("Vary hungry");
        }
        if (hp <= 0)
        {
            Debug.Log("Deadbyhungry");
        }
    }

    protected void happiness(float hp)
    {
        if (hp <= 50 && hp >= 26)
        {
            Debug.Log("sad");
        }
        if (hp <= 25 && hp >= 1)
        {
            Debug.Log("Vary sad");
        }
        if (hp <= 0)
        {
            Debug.Log("Deadbysad");
        }
    }

    protected void cleam(float hp)
    {
        if (hp <= 50 && hp >= 26)
        {
            Debug.Log("dirty");
        }
        if (hp <= 25 && hp >= 1)
        {
            Debug.Log("Vary dirty");
        }
        if (hp <= 0)
        {
            Debug.Log("Deadbydirty");
        }
    }

    protected void heal(float hp)
    {
        if (hp <= 50 && hp >= 26)
        {
            Debug.Log("pain");
        }
        if (hp <= 25 && hp >= 1)
        {
            Debug.Log("Vary pain");
        }
        if (hp <= 0)
        {
            Debug.Log("Deadbypain");
        }
    }

}
