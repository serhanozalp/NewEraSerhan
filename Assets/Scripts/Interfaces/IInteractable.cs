using UnityEngine;
public interface IInteractable 
{
    GameObject GetGameObject();
    void Interact(PlayerInventory playerInventory);
    void TriggerEnterOn();
    void TriggerExitOn();
}

