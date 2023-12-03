using TMPro;

public class SellerArmor : Seller, IItemSoldClient
{
    private ItemForSale _item;
    private const string DefaultMessage = "Great job taking care of those monsters! I've got some sturdy armor that can help you with the next 6. Interested?";
    private const string SoldMessage = "Thanks for the purchase! I'm all out of stock now, but feel free to come back later.";

    public SellerArmor(TextMeshPro text, ItemForSale item) : base(text)
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