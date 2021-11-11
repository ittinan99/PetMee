using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUIManager : MonoBehaviour
{
    public Image fillEnergyBar;
    public Image fillFoodBar;
    public Image fillWaterBar;
    public Image fillHappyBar;
    public PetStats pet;

    private void Start() {
        
    }

    private void Update() {
        UpdateStatusBar();
    }

    void UpdateStatusBar(){
        fillEnergyBar.fillAmount = pet.healLvl / 100;
        fillFoodBar.fillAmount = pet.hungryLvl / 100;
        fillHappyBar.fillAmount = pet.happinessLvl/100;
        fillWaterBar.fillAmount = pet.cleanlvl / 100;
        
    }
}
