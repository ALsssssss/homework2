using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item Data")]
public class ItemData : ScriptableObject
{
    [Header("基本信息")]
    public string itemName;
    public string description;
    public Sprite icon;
    public int maxStack = 1;

    [Header("属性")]
    public int food;//食物
    public int attackBonus;//攻击力
    public int defenseBonus;//防御力
    
    [Header("效果")]
    public bool isConsumable = true;
}