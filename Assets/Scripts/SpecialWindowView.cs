using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpecialWindowView : MonoBehaviour, ISpecialWindowView
{
    [SerializeField] private Item _itemPrefab;
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private Transform _upperItemContainer;
    [SerializeField] private Transform _bottomItemContainer;
    [SerializeField] private TMP_Text _mainCostText;
    [SerializeField] private TMP_Text _miniCostText;
    [SerializeField] private TMP_Text _discountText;
    [SerializeField] private TMP_Text _newCostText;
    [SerializeField] private Image _bigIcon;
    [SerializeField] private Button _buyButton;

    public void UpdateTitle(string newTitle)
    {
        _titleText.text = newTitle;
    }

    public void UpdateDescription(string newDescription)
    {
        _descriptionText.text = newDescription;
    }

    public void UpdateUpperItems(Sprite[] sprites)
    {
        UpdateItems(sprites, _upperItemContainer);
    }

    public void UpdateBottomItems(Sprite[] sprites)
    {
        UpdateItems(sprites, _bottomItemContainer);
    }

    private void UpdateItems(Sprite[] sprites, Transform container)
    {
        var countOldItems = container.childCount;
        for (int i = countOldItems - 1; i >= 0; i--)
        {
            Destroy(container.GetChild(i).gameObject);
        }

        foreach (var sprite in sprites)
        {
            var item = Instantiate(_itemPrefab, container);
            item.SetItem(sprite, 40);
        }
    }

    public void UpdateCost(float cost)
    {
        var correctCost = Math.Round(cost, 2);
        _mainCostText.text = $"${correctCost}";
        _miniCostText.text = $"${correctCost}";

        _mainCostText.gameObject.SetActive(true);
        _miniCostText.gameObject.SetActive(false);
        _discountText.transform.parent.gameObject.SetActive(false);
        _newCostText.gameObject.SetActive(false);
    }

    public void UpdateDiscount(int discount, float newCost)
    {
        _discountText.text = $"-{discount}%";
        _newCostText.text = $"${Math.Round(newCost, 2)}";

        _mainCostText.gameObject.SetActive(false);
        _miniCostText.gameObject.SetActive(true);
        _discountText.transform.parent.gameObject.SetActive(true);
        _newCostText.gameObject.SetActive(true);
    }

    public void UpdateBigIcon(Sprite icon)
    {
        _bigIcon.sprite = icon;
    }

    public void SubscribeToBuy(UnityAction action)
    {
        _buyButton.onClick.AddListener(action);
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}
