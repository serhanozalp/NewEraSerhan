using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment Item Object",menuName ="Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    private void Awake()
    {
        itemType = ItemType.Equipment;
    }
}
