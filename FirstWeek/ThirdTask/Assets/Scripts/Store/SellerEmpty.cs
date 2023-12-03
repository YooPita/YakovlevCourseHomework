using TMPro;

public class SellerEmpty : Seller
{
    private const string DefaultMessage = "Hey there, adventurer! I'd love to help, but those monsters nearby are scaring away all my customers. Can you defeat 3 monsters first?";
    
    public SellerEmpty(TextMeshPro text) : base(text)
    {
    }

    public override void Enable()
    {
        _text.text = DefaultMessage;
    }

    public override void Disable()
    {
        _text.text = "";
    }
}
