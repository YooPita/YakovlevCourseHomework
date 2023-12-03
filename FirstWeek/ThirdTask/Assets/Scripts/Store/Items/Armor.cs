using UnityEngine;

public class Armor : ItemForSale
{
    public Armor(IItemSoldClient client)
    {
    }

    protected override void OnBuying()
    {
        Debug.Log("The armor was purchased");
    }
}
