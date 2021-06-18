using UnityEngine;
using Mirror;

public class Item : NetworkBehaviour, IInteractable
{
    [SerializeField] private ItemObject itemObject;
    [SerializeField] private int amount;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private PlayerInventory playerInventory;
    public ItemObject ItemObject { get { return itemObject; } }
    public int Amount { get { return amount; } }
    public PlayerInventory PlayerInventory { set { playerInventory = value; } }

    private void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshFilter.sharedMesh = itemObject.ItemMeshFilter.sharedMesh;
        meshRenderer.material = itemObject.ItemMaterial;
        RotateToHorizontal();
    }
    public void Interact()
    {
        playerInventory.AddItem(itemObject, amount);
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
    [Command]
    private void CmdDestroy()
    {
        Destroy(gameObject);
    }
    [ServerCallback]
    private void RotateToHorizontal()
    {
        transform.Rotate(new Vector3(90f, 0f, 0f));
    }
    #endregion
}
