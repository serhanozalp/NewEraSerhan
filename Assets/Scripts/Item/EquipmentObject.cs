using UnityEngine;
using System.Collections.Generic;
using Mirror;

public enum EquipmentType { Chest, Head, Legs, Feet, Arms, Hands }
public enum BuffType { Armor, MoveSpeed }
public enum RarityType { None, Common, Rare, Mythic }

[CreateAssetMenu(fileName ="New Equipment Item Object",menuName ="Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    protected List<ItemBuff> itemBuffs = new List<ItemBuff>();
    protected EquipmentType equipmentType;
    protected RarityType rarityType;

    //GETTERS SETTERS
    public List<ItemBuff> ItemBuffs { get { return itemBuffs; } set { itemBuffs = value; } }
    public RarityType RarityType { get { return rarityType; } set { rarityType = value; } }
    protected virtual void Awake()
    {
        rarityType = RarityType.None;
        itemType = ItemType.Equipment;
    }
    public void Randomize()
    {
        SetDefault();
        SetRarity();
    }
    protected void SetDefault()
    {
        rarityType = RarityType.None;
        itemBuffs.Clear();
    }
    protected void SetRarity()
    {
        float _rarityValue = Random.Range(0f, 100f);
        if(_rarityValue>=0f && _rarityValue < 30f)
        {
            rarityType = RarityType.Common;
        }
        else if (_rarityValue >= 30f && _rarityValue < 60f)
        {
            rarityType = RarityType.Rare;
        }
        else
        {
            rarityType = RarityType.Mythic;
        }
    }
}

[System.Serializable]
public class ItemBuff
{
    private BuffType buffType;
    private float value;
    private float minValue;
    private float maxValue;
    public ItemBuff(BuffType _buffType, float _minValue, float _maxValue)
    {
        buffType = _buffType;
        minValue = _minValue;
        maxValue = _maxValue;
        GenerateValue();
    }
    private void GenerateValue()
    {
        value = Random.Range(minValue, maxValue);
    }
}

public static class EquipmentObjectSerializer
{
    public static void WriteEquipmentObject(this NetworkWriter writer, EquipmentObject value)
    {
        // no need to serialize the data, just the name of the armor
        writer.WriteInt((int)value.RarityType);
    }

    public static EquipmentObject ReadEquipmentObject(this NetworkReader reader)
    {
        EquipmentObject eq = new EquipmentObject();
        Debug.Log("selam");
        return eq;
    }
}
