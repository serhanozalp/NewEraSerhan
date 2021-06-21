using UnityEngine;
using Mirror;

public class Item : NetworkBehaviour, IInteractable
{
    [SerializeField] private ItemObject itemObjectPrefab;
    [SerializeField] private int amount;


    private ItemObject itemObject;


    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    //GETTERS SETTERS
    public ItemObject ItemObject { get { return itemObject; } }
    public int Amount { get { return amount; } }


    private void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshFilter.sharedMesh = itemObjectPrefab.ItemMeshFilter.sharedMesh;
        meshRenderer.material = itemObjectPrefab.ItemMaterial;
    }
    public void Interact(PlayerInventory _playerInventory)
    {
        _playerInventory.AddItem(itemObject, amount);
        CmdDestroy();
    }
    public void TriggerEnterOn()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
    public void TriggerExitOn()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public GameObject GetGameObject()
    {
        return gameObject;
    }
    #region Server
    public override void OnStartServer()
    {
        itemObject = ScriptableObject.Instantiate(itemObjectPrefab);
        if (itemObject.ItemType == ItemType.Equipment)
        {
            (itemObject as EquipmentObject).Randomize();
        }
    }
    [Command]
    private void CmdDestroy()
    {
        Destroy(gameObject);
    }
    #endregion
}
