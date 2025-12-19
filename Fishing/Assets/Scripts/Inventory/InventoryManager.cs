using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }//dan单例模式

    [SerializeField] private InventoryController inventoryController;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(InventoryItem item)
    {
        inventoryController.AddItemToInventory(item.data, item.quantity);
    }

    // 测试方法：直接添加物品
    public void TestAddItem(ItemData itemData)
    {
        InventoryItem newItem = new InventoryItem(itemData);
        newItem.AddToInventory();
    }
}
