using UnityEngine;

public enum ItemType { Default, Equipment }

public class ItemObject : ScriptableObject
{
    [SerializeField] protected string itemName;
    [SerializeField] protected Sprite itemSprite;
    [SerializeField] protected MeshFilter itemMeshFilter;
    [SerializeField] protected Material itemMaterial;
    [SerializeField] protected string description;
    protected ItemType itemType;

    //GETTERS SETTERS
    public string ItemName { get { return itemName; } }
    public Sprite ItemSprite { get { return itemSprite; } }
    public MeshFilter ItemMeshFilter { get { return itemMeshFilter; } }
    public Material ItemMaterial { get { return itemMaterial; } }
    public ItemType ItemType { get { return itemType; } }
}



