using UnityEngine;
public interface IInteractable 
{
    GameObject GetGameObject();
    void Interact();
    void TriggerEnterOn();
    void TriggerExitOn();
}
