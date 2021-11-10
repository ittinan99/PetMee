using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fish : PetStats
{
    public new string name = "Tawan";

    public  float hungryrate_C = 5;
    public  float happinessrate_C = 2;
    public  float cleanlinessrate_C = 2;
    public  float healrate_C = 4;

    public  float hungrylavel_C = 100;
    public  float happinessLavel_C = 100;
    public  float cleanLavel_C = 100;
    public  float heallavel_C = 100;


    public Text HU, HA, CL, HE,Name = null;
    

    private void Start()
    {      

        if(PlayerPrefs.HasKey(name + "hungryrate"))
        {
            Load();
        }
        else
        {
            RandStats();
            hungrylavel = hungrylavel_C;
            happinessLavel = happinessLavel_C;
            cleanLavel = cleanLavel_C;
            heallavel = heallavel_C;
            SetStats();
        }     
    }

    void SetStats()
    {
        hungryrate = hungryrate_C;
        happinessrate = happinessrate_C;
        cleanlinessrate = cleanlinessrate_C;
        healrate = healrate_C;
    }

    void RandStats()
    {
        hungryrate_C = Random.Range(4,10);
        happinessrate_C = Random.Range(1,5);
        cleanlinessrate_C = Random.Range(2, 10);
        healrate_C = Random.Range(3, 6);    
    }

    private void FixedUpdate()
    {
        //lefttime += Time.deltaTime;

        hungrylavel -= (hungryrate) / 10000;
        happinessLavel -= (happinessrate) / 10000;
        cleanLavel -= (cleanlinessrate) / 10000;
        heallavel -= (healrate) / 10000;

        UpdateStats();
        SetStats();
        Seve();
    }

    void UpdateStats()
    {
        hungry(hungrylavel);
        happiness(happinessLavel);
        cleam(cleanLavel);
        heal(heallavel);
        if(HU.text != null)
        {
            HU.text = "Hungry = " + hungrylavel;
            HA.text = "Happiness = " + happinessLavel;
            CL.text = "Clean = " + cleanLavel;
            HE.text = "Heal = " + heallavel;
            Name.text = "Name = " + name;
        }
    }


    private void Update()
    {
        happiness(happinessLavel);
    }

    void Seve()
    {
        PlayerPrefs.SetFloat(name + "hungryrate", hungryrate_C);
        PlayerPrefs.SetFloat(name + "happinessrate", happinessrate_C);
        PlayerPrefs.SetFloat(name + "cleanlinessrate", cleanlinessrate_C);
        PlayerPrefs.SetFloat(name + "healrate", healrate_C);

        PlayerPrefs.SetFloat(name + "hungrylavel", hungrylavel);
        PlayerPrefs.SetFloat(name + "happinessLavel", happinessLavel);
        PlayerPrefs.SetFloat(name + "cleanLavel", cleanLavel);
        PlayerPrefs.SetFloat(name + "heallavel", heallavel);

        PlayerPrefs.Save();
    }
    void Load()
    {
        hungryrate_C = PlayerPrefs.GetFloat(name + "hungryrate");
        happinessrate_C = PlayerPrefs.GetFloat(name + "happinessrate");
        cleanlinessrate_C = PlayerPrefs.GetFloat(name + "cleanlinessrate");
        healrate_C = PlayerPrefs.GetFloat(name + "healrate");

        hungrylavel = PlayerPrefs.GetFloat(name + "hungrylavel");
        happinessLavel = PlayerPrefs.GetFloat(name + "happinessLavel");
        cleanLavel = PlayerPrefs.GetFloat(name + "cleanLavel");
        heallavel = PlayerPrefs.GetFloat(name + "heallavel");
    }
}
