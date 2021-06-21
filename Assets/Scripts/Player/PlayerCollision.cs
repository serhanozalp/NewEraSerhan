using UnityEngine;
using Mirror;

public class PlayerCollision : NetworkBehaviour
{
    private IInteractable targetInteractable;
    private void Update()
    {
        if (!isLocalPlayer) return;
        if (Input.GetKeyDown(KeyCode.E) && targetInteractable != null)
        {
            CmdInteract(targetInteractable.GetGameObject());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isLocalPlayer) return;
        IInteractable _interactable = other.gameObject.GetComponent<IInteractable>();
        if (_interactable != null)
        {
            targetInteractable = _interactable;
            _interactable.TriggerEnterOn();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!isLocalPlayer) return;
        IInteractable _interactable = other.gameObject.GetComponent<IInteractable>();
        if (_interactable != null)
        {
            _interactable.TriggerExitOn();
            targetInteractable = null;
        }
    }
    #region Server
    [Command]
    private void CmdInteract(GameObject _object)
    {
        _object.GetComponent<NetworkIdentity>().AssignClientAuthority(GetComponent<NetworkIdentity>().connectionToClient);
        RpcOnAuthorityAssigned(_object);
    }
    #endregion
    #region Client
    [TargetRpc]
    private void RpcOnAuthorityAssigned(GameObject _object)
    {
        targetInteractable.Interact(GetComponent<PlayerInventory>());
        targetInteractable = null;
    }
    #endregion
}
