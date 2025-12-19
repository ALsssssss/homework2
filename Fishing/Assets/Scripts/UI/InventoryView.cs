using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryView : MonoBehaviour
{
    [SerializeField] private Transform itemsContainer;//挂载了grid layout ground组件
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private Text capacityText;

    private InventoryController controller;

    public void Initialize(InventoryController inventoryController)
    {
        controller = inventoryController;
        UpdateUI();
    }

    public void UpdateUI()
    {
        // 清空现有物品槽
        foreach (Transform child in itemsContainer)
        {
            Destroy(child.gameObject);
        }

        // 更新物品显示
        var items = controller.GetItems();
        foreach (var item in items)
        {
            GameObject slot = Instantiate(itemSlotPrefab, itemsContainer);
            SetupItemSlot(slot, item);
        }

        // 更新容量显示
        if (capacityText != null)
        {
            capacityText.text = $"{items.Count}/8";
        }
    }

    private void SetupItemSlot(GameObject slot, InventoryItem item)
    {
        // 设置图标
        Image icon = slot.transform.Find("Icon").GetComponent<Image>();
        icon.sprite = item.data.icon;

        // 设置数量文本
        Text quantityText = slot.transform.Find("Quantity").GetComponent<Text>();
        quantityText.text = item.quantity > 1 ? item.quantity.ToString() : "";

        // 设置按钮事件
        Button button = slot.GetComponent<Button>();
        button.onClick.AddListener(() => controller.UseItem(item.itemID));

        
        
    }
}
