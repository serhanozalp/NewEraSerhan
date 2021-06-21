using UnityEngine;

[CreateAssetMenu(fileName = "New Chest Equipment Item Object", menuName = "Inventory System/Items/Equipment/Chest")]
public class ChestEquipmentObject : EquipmentObject
{
    protected override void Awake()
    {
        base.Awake();
        equipmentType = EquipmentType.Chest;
    }
}
