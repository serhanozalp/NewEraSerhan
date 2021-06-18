using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private NetworkIdentity networkIdentity;
    [HideInInspector] public string playerID;
    private IInteractable targetInteractable;
    private void Update()
    {
        if (!isLocalPlayer) return;
        if (Input.GetKeyDown(KeyCode.E) && targetInteractable!=null)
        {
            CmdInteract(targetInteractable.GetGameObject());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isLocalPlayer) return;
        if (other.CompareTag("Item"))
        {
            Item _item = other.gameObject.GetComponent<Item>();          
            if (_item != null)
            {
                _item.TriggerEnterOn();
                _item.PlayerInventory = playerInventory;
                targetInteractable = _item;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!isLocalPlayer) return;
        if (other.CompareTag("Item"))
        {
            Item _item = other.gameObject.GetComponent<Item>();
            if (_item != null)
            {
                _item.TriggerExitOn();
                _item.PlayerInventory = null;
                targetInteractable = null;
            }
        }
    }
    [TargetRpc]
    private void RpcOnAuthorityAssigned(GameObject _object)
    {
        targetInteractable.Interact();
        targetInteractable = null;
    }
    [Command]
    private void CmdInteract(GameObject _object)
    {
        _object.GetComponent<NetworkIdentity>().AssignClientAuthority(networkIdentity.connectionToClient);
        RpcOnAuthorityAssigned(_object);
    }
}
