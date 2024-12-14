using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpecialWindowColtroller : MonoBehaviour
{
    [SerializeField] private IconsConfig itemIcons;
    [SerializeField] private IconsConfig bigIcons;
    [SerializeField] private SpecialWindowView _viewPrefab;
    [SerializeField] private Transform _windowContainer;
    private SpecialWindowModel _model;
    private ISpecialWindowView _view;

    public struct SpecialWindowData
    {
        public string Title;
        public string Description;
        public List<string> ItemsName;
        public float Cost;
        public int Discount;
        public string BigIconName;
    }

    public void Initialize(SpecialWindowData data)
    {
        if(data.ItemsName.Count < 3 || data.ItemsName.Count > 6)
        {
            Debug.LogError("Некорректное число объектов!");
            return;
        }

        _model = new SpecialWindowModel();
        _view = Instantiate(_viewPrefab, _windowContainer);

        Subscription();
        SetModelValue(data);
    }

    private void Subscription()
    {
        _model.OnChangeTitle += _view.UpdateTitle;
        _model.OnChangeDescription += _view.UpdateDescription;
        _model.OnChangeUpperItems += _view.UpdateUpperItems;
        _model.OnChangeBottomItems += _view.UpdateBottomItems;
        _model.OnChangeCost += _view.UpdateCost;
        _model.OnDiscountCost += _view.UpdateDiscount;
        _model.OnChangeBigIcon += _view.UpdateBigIcon;

        _view.SubscribeToBuy(BuyOffer);
    }

    private void SetModelValue(SpecialWindowData data)
    {
        _model.SetTitle(data.Title);
        _model.SetDescription(data.Description);

        var upperItems = data.ItemsName.GetRange(0, 3).ToArray();
        var bottomItems = data.ItemsName.Count > 3 ? 
            data.ItemsName.GetRange(3, data.ItemsName.Count - 3).ToArray() : null;
        _model.SetItems(ConvertItemNamesToSprites(upperItems), ConvertItemNamesToSprites(bottomItems));

        _model.SetCoast(data.Cost);
        if(data.Discount > 0)
        {
            _model.SetDiscount(data.Discount, CalculateDiscountedCost(data.Cost, data.Discount));
        }
        _model.SetBigIcon(ConvertBigIconNameToSprite(data.BigIconName));
    }

    private Sprite[] ConvertItemNamesToSprites(string[] names)
    {
        if(names == null)
        {
            return new Sprite[0];
        }
        Sprite[] items = new Sprite[names.Length];
        for (int i = 0; i < names.Length; i++)
        {
            foreach (var data in itemIcons.Icons)
            {
                if (data.Name == names[i])
                {
                    items[i] = data.Icon;
                }
            }
        }
        return items;
    }

    private float CalculateDiscountedCost(float cost, int discount)
    {
        return cost - cost * (discount / 100f);
    }

    private Sprite ConvertBigIconNameToSprite(string name)
    {
        foreach (var data in bigIcons.Icons)
        {
            if (data.Name == name)
            {
                return data.Icon;
            }
        }
        return null;
    }

    public void BuyOffer()
    {
        Debug.Log("Buy");
        _view.Close();
    }
}
