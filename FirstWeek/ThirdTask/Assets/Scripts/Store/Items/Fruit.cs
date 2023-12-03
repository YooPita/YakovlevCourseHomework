using UnityEngine;

public class Fruit : ItemForSale
{
    public Fruit(IItemSoldClient client)
    {
    }

    protected override void OnBuying()
    {
        Debug.Log("The fruit was purchased");
    }
}
