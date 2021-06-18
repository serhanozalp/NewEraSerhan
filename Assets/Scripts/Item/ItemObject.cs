using UnityEngine;

public enum ItemType { Default, Equipment }
public abstract class ItemObject : ScriptableObject
{
    [SerializeField] protected string itemName;
    [SerializeField] protected Sprite itemSprite;
    [SerializeField] protected MeshFilter itemMeshFilter;
    [SerializeField] protected Material itemMaterial;
    [SerializeField] protected ItemType itemType;
    [SerializeField] protected string description;

    public string ItemName { get { return itemName; } }
    public Sprite ItemSprite { get { return itemSprite; } }
    public MeshFilter ItemMeshFilter { get { return itemMeshFilter; } }
    public Material ItemMaterial { get { return itemMaterial; } }
}
