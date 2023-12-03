using TMPro;

public class SellerFruits : Seller, IItemSoldClient
{
    private ItemForSale _item;
    private const string DefaultMessage = "Impressive work! You've earned yourself some fresh fruit. Interested?";
    private const string SoldMessage = "You've bought all my wares for now. Come back if you ever need more!";

    public SellerFruits(TextMeshPro text, ItemForSale item) : base(text)
    {
        _item = item;
        _item.Subscribe(this);
    }

    public override void Enable()
    {
        if (_item.Purchased)
            _text.text = SoldMessage;
        else
        {
            _text.text = DefaultMessage;
            _item.Enable();
        }
    }

    public override void Disable()
    {
        _text.text = "";
        _item.Disable();
    }

    public void ItemWasSold()
    {
        _text.text = SoldMessage;
        _item.Disable();
    }
}