using Unity.VisualScripting;
using UnityEngine;

public class Ball : ClickObject
{
    public BallType Type => _type;

    private IBallClient _client;

    [SerializeField] private BallType _type;

    public void Subscribe(IBallClient client)
    {
        _client = client;
    }

    public void Remove()
    {
        Destroy(gameObject);
    }

    protected override void OnClick()
    {
        _client.OnClick(Type);
        gameObject.SetActive(false);
    }
}
