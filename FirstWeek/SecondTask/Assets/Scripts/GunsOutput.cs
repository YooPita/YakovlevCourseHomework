using TMPro;
using UnityEngine;

public class GunsOutput : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Sprite _gun1;
    [SerializeField] private Sprite _gun2;
    [SerializeField] private Sprite _gun3;
    [SerializeField] private TextMeshPro _text;

    public void SetFirstGun() => _renderer.sprite = _gun1;

    public void SetSecondGun() => _renderer.sprite = _gun2;

    public void SetThirdGun() => _renderer.sprite = _gun3;

    public void SetAmmo(int amount)
    {
        if (amount < 0)
            _text.text = "∞";
        else
            _text.text = amount.ToString();
    }
}
