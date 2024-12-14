using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWindowModel
{
    private string _title;
    private string _description;
    private Sprite[] _upperItems;
    private Sprite[] _bottomItems;
    private float _cost;
    private int _discount;
    private float _discountedCost;
    private Sprite _bigIcon;

    public event Action<string> OnChangeTitle;
    public event Action<string> OnChangeDescription;
    public event Action<Sprite[]> OnChangeUpperItems;
    public event Action<Sprite[]> OnChangeBottomItems;
    public event Action<float> OnChangeCost;
    public event Action<int, float> OnDiscountCost;
    public event Action<Sprite> OnChangeBigIcon;

    public void SetTitle(string title)
    {
        _title = title;
        OnChangeTitle?.Invoke(_title);
    }

    public void SetDescription(string description)
    {
        _description = description;
        OnChangeDescription?.Invoke(_description);
    }

    public void SetItems(Sprite[] upper, Sprite[] bottom)
    {
        _upperItems = upper;
        _bottomItems = bottom;
        OnChangeUpperItems?.Invoke(_upperItems);
        OnChangeBottomItems?.Invoke(_bottomItems);
    }

    public void SetCoast(float cost)
    {
        _cost = cost;
        OnChangeCost?.Invoke(_cost);
    }

    public void SetDiscount(int discount, float newCost)
    {
        _discount = discount;
        _discountedCost = newCost;
        OnDiscountCost?.Invoke(_discount, _discountedCost);
    }

    public void SetBigIcon(Sprite bigIcon)
    {
        _bigIcon = bigIcon;
        OnChangeBigIcon?.Invoke(_bigIcon);
    }
}
