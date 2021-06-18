using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    public void HandleMovement(Transform _playerTransform, Vector3 _moveDirection, MovementState _movementState)
    {
        playerAnimator.SetFloat("MoveHorizontal", Vector3.Dot(_playerTransform.right.normalized, _moveDirection), 0.1f, Time.deltaTime);
        playerAnimator.SetFloat("MoveVertical", (_movementState == MovementState.Running) ? 2f : Vector3.Dot(_playerTransform.forward.normalized, _moveDirection), 0.1f, Time.deltaTime);
    }
}
