using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public ItemData data;
    public int quantity;
    public int itemID; // 唯一标识

    public InventoryItem(ItemData itemData, int count = 1)
    {
        data = itemData;
        quantity = count;
        itemID = UnityEngine.Random.Range(1000, 9999);
    }

    // 直接加入背包的方法
    public void AddToInventory()
    {
        InventoryManager.Instance.AddItem(this);
    }
}