using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _walk = "Walk";
    [SerializeField] private string _upPressed = "UpPressed";
    [SerializeField] private string _downPressed = "DownPressed";
    [SerializeField] private string _firePressed = "FirePressed";

    public void SetWalk(bool value) => _animator.SetBool(_walk, value);
    public void SetUp(bool value) => _animator.SetBool(_upPressed, value);
    public void SetDown(bool value) => _animator.SetBool(_downPressed, value);
    public void SetFire(bool value) => _animator.SetBool(_firePressed, value);
}