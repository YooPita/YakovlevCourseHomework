using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : ClickObject
{
    private IButtonClient _client;

    public void Subscribe(IButtonClient client)
    {
        _client = client;
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    protected override void OnClick()
    {
        _client.OnClick(this);
    }
}
