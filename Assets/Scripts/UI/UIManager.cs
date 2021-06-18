using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventorySlotPrefab;
    private void Start()
    {
        PlayerInventory.OnInventoryUpdated += HandleInventoryUpdated;
    }
    private void OnDestroy()
    {
        PlayerInventory.OnInventoryUpdated -= HandleInventoryUpdated;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }
    private void HandleInventoryUpdated(InventoryObject _inventory)
    {
        ResetInventoryPanel();
        DisplayInventoryPanel(_inventory);
    }
    private void ResetInventoryPanel()
    {
        foreach (Transform _child in inventoryPanel.transform)
        {
            Destroy(_child.gameObject);
        }
    }
    private void DisplayInventoryPanel(InventoryObject _inventoryObject)
    {
        List<InventorySlot> _inventory = _inventoryObject.Inventory;
        for (int i = 0; i < _inventory.Count; i++)
        {
            GameObject _inventorySlot = Instantiate(inventorySlotPrefab,inventoryPanel.transform);
            _inventorySlot.transform.Find("InventoryItemSprite").GetComponent<Image>().sprite = _inventory[i].ItemObject.ItemSprite;
            _inventorySlot.transform.Find("InventoryItemAmount").GetComponent<TextMeshProUGUI>().text = _inventory[i].Amount.ToString();
        }
    }
}
