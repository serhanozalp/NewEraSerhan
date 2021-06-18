using UnityEngine;
using UnityEditor;
using Mirror;
using System;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Player player;
    private InventoryObject inventoryObject;
    public InventoryObject InventoryObject { get { return inventoryObject; } }
    public static event Action<InventoryObject> OnInventoryUpdated;

    private void Start()
    {
        if (!GetComponent<NetworkIdentity>().isLocalPlayer) return;
        inventoryObject = ScriptableObject.CreateInstance<InventoryObject>();
        AssetDatabase.CreateAsset(inventoryObject, "Assets/Scriptable Objects/Inventory/Player" + GetComponent<NetworkIdentity>().netId + "Inventory.asset");
        AssetDatabase.SaveAssets();
    }
    private void OnDestroy()
    {
        AssetDatabase.DeleteAsset("Assets/Scriptable Objects/Inventory/Player" + GetComponent<NetworkIdentity>().netId + "Inventory.asset");
    }
    public void AddItem(ItemObject _item, int _amount)
    {
        inventoryObject.AddItem(_item, _amount);
        OnInventoryUpdated?.Invoke(inventoryObject);
    }
}
