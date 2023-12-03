using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Seller
{
    protected TextMeshPro _text;

    public Seller(TextMeshPro text)
    {
        _text = text;
    }

    public abstract void Enable();
    public abstract void Disable();
}
