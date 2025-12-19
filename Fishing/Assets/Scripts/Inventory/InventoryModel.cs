using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();
    public int capacity = 8;

    public bool AddItem(InventoryItem newItem)
    {
        // 检查是否可堆叠
        if (newItem.data.maxStack > 1)
        {
            foreach (var item in items)
            {
                if (item.data == newItem.data && item.quantity < item.data.maxStack)
                {
                    item.quantity += newItem.quantity;
                    return true;
                }
            }
        }

        // 添加新物品
        if (items.Count < capacity)
        {
            items.Add(newItem);
            return true;
        }

        
        return false;
    }

    public void RemoveItem(int itemID, int amount = 1)
    {
        var item = items.Find(i => i.itemID == itemID);
        if (item != null)
        {
            item.quantity -= amount;
            if (item.quantity <= 0)
            {
                items.Remove(item);
            }
        }
    }

    public bool HasSpace()
    {
        return items.Count < capacity;
    }
}
