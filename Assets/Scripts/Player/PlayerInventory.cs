using UnityEngine;
using UnityEditor;
using Mirror;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Player player;
    private InventoryObject inventoryObject;
    public InventoryObject InventoryObject { get { return inventoryObject; } }

    private void Start()
    {
        if (!GetComponent<NetworkIdentity>().isServer) return;
        inventoryObject = ScriptableObject.CreateInstance<InventoryObject>();
        Debug.Log("Assets/Scriptable Objects/Inventory/Player"+GetComponent<NetworkIdentity>().netId+"Inventory.asset");
        AssetDatabase.CreateAsset(inventoryObject, "Assets/Scriptable Objects/Inventory/Player" + GetComponent<NetworkIdentity>().netId + "Inventory.asset");
        AssetDatabase.SaveAssets();
        if (inventoryObject != null)
        {
            inventoryObject.ClearInventory();
        }
    }
    private void OnDestroy()
    {
        AssetDatabase.DeleteAsset("Assets/Scriptable Objects/Inventory/" + player.playerID + " Inventory.asset");
    }

}
