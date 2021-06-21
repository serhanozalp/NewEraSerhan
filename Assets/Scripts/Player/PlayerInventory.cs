using UnityEngine;
using System;
using Mirror;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InventoryObject inventoryObjectPrefab;
    public InventoryObject inventoryObject;
    public static event Action<InventoryObject> OnInventoryUpdated;

    //GETTERS SETTERS
    public InventoryObject InventoryObject { get { return inventoryObject; } }

    public void AddItem(ItemObject _item, int _amount)
    {
        inventoryObject.AddItem(_item, _amount);
        OnInventoryUpdated?.Invoke(inventoryObject);
    }
    private void Start()
    {
        if (!GetComponent<NetworkIdentity>().isLocalPlayer) return;
        inventoryObject = ScriptableObject.Instantiate(inventoryObjectPrefab);
        /*
        inventoryObject = ScriptableObject.CreateInstance<InventoryObject>();
        AssetDatabase.CreateAsset(inventoryObject, "Assets/Resources/Inventories/Player" + GetComponent<NetworkIdentity>().netId + "Inventory.asset");
        AssetDatabase.SaveAssets();
        */
    }
    private void OnDestroy()
    {
        //AssetDatabase.DeleteAsset("Assets/Resources/Inventories/Player" + GetComponent<NetworkIdentity>().netId + "Inventory.asset");
    }
}
