using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kabi : MonoBehaviour
{
   
    public float scaleSpeed=0.5f;
    public int Food=1;
    public int Attack=1;
    public int defense=1;
    [Header("UIœ‘ æ")]
    public Slider FoodSlider;
    public Slider AttackSlider;
    public Slider defenseSlider;

    private Vector3 fatMultiple;//±‰≈÷±∂¬ 
 
    private void Update()
    {
        
        UpdataPlayerUI();
        
    }
    public void eat(int food,int atk,int def)
    {
        Food += food;
        Attack += atk;
        defense += def;
        levelup(food);
         fatMultiple = new Vector3(Food * scaleSpeed, Food * scaleSpeed, Food * scaleSpeed);
        transform.localScale += fatMultiple;
        ScenesData.instance.GetKabiValue(Attack, defense, fatMultiple);

    }
    private void levelup(int tempfood)
    {
        Attack += tempfood/2;
        defense += tempfood/2;

    }
    private void UpdataPlayerUI()
    {
        FoodSlider.value = Food;
        AttackSlider.value = Attack;
        defenseSlider.value = defense;
    }

}
