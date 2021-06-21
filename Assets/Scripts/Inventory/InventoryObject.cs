using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Object", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    private List<InventorySlot> inventory = new List<InventorySlot>();
    public List<InventorySlot> Inventory { get { return inventory; } }
    public void AddItem(ItemObject _item, int _amount)
    {
        bool _hasItem = false;
        foreach (InventorySlot _inventorySlot in inventory)
        {
            if (_inventorySlot.ItemObject == _item)
            {
                _inventorySlot.AddAmount(_amount);
                _hasItem = true;
                break;
            }
        }
        if (!_hasItem)
        {
            inventory.Add(new InventorySlot(_item, _amount));
        }
    }
}
[System.Serializable]
public class InventorySlot
{
    private ItemObject itemObject;
    private int amount;
    public float Amount { get { return amount; } }
    public ItemObject ItemObject { get { return itemObject; } }
    public InventorySlot(ItemObject _item,int _amount)
    {
        itemObject = _item;
        amount = _amount;
    }
    public void AddAmount(int _amount)
    {
        amount += _amount;
    }
}
