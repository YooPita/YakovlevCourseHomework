using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public abstract class ItemForSale : MonoBehaviour
{
    public delegate void ItemSoldDelegate();

    public event ItemSoldDelegate OnItemSold;

    public bool Purchased => _purchased;
    private IItemSoldClient _client;

    private bool _purchased = false;

    protected abstract void OnBuying();

    public void Subscribe(IItemSoldClient client)
    {
        _client = client;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var playerScript))
            SellItem();
    }

    private void SellItem()
    {
        _purchased = true;
        _client?.ItemWasSold();
        OnBuying();
        OnItemSold?.Invoke();
        Disable();
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
