using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private ItemForSale _fruit;
    [SerializeField] private ItemForSale _armor;
    private Seller _sellerEmpty;
    private Seller _sellerArmor;
    private Seller _sellerFruits;
    private Seller _activeSeller;

    private void Awake()
    {
        _sellerEmpty = new SellerEmpty(_text);
        _sellerArmor = new SellerArmor(_text, _armor);
        _sellerFruits = new SellerFruits(_text, _fruit);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IPlayerStats>(out var stats))
            Initialize(stats.MonstersDefeated);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IPlayerStats>(out var stats))
            Initialize(stats.MonstersDefeated);
    }

    public void Initialize(int monstersDefeated)
    {
        if (monstersDefeated >= 6)
            ActivateSeller(_sellerFruits);
        else if(monstersDefeated >= 3)
            ActivateSeller(_sellerArmor);
        else
            ActivateSeller(_sellerEmpty);
    }

    private void ActivateSeller(Seller seller)
    {
        seller?.Disable();
        seller.Enable();
    }
}
