using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryModel inventoryModel;
    [SerializeField] private InventoryView inventoryView;
    public kabi kabi;
    private void Start()
    {
        inventoryView.Initialize(this);
    }

    public void AddItemToInventory(ItemData itemData, int quantity = 1)
    {
        InventoryItem newItem = new InventoryItem(itemData, quantity);
        if (inventoryModel.AddItem(newItem))
        {
            inventoryView.UpdateUI();
            Debug.Log($"添加物品: {itemData.itemName} x{quantity}");
        }
    }

    public void UseItem(int itemID)
    {
        var item = inventoryModel.items.Find(i => i.itemID == itemID);//通过id返回物品
        if (item != null && item.data.isConsumable)
        {
            // 这里可以调用玩家状态的效果应用
            ApplyItemEffects(item.data);
            inventoryModel.RemoveItem(itemID);
            inventoryView.UpdateUI();
        }
    }

    private void ApplyItemEffects(ItemData itemData)
    {
        
        Debug.Log($"使用物品: {itemData.itemName}");
        kabi.eat(itemData.food, itemData.attackBonus, itemData.defenseBonus);
            

    }

    // 获取背包物品列表（给View使用）
    public List<InventoryItem> GetItems()
    {
        return inventoryModel.items;
    }
}
