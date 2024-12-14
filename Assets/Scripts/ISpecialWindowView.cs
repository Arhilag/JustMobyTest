using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ISpecialWindowView
{
    public void UpdateTitle(string newTitle);
    public void UpdateDescription(string newDescription);
    public void UpdateUpperItems(Sprite[] sprites);
    public void UpdateBottomItems(Sprite[] sprites);
    public void UpdateCost(float cost);
    public void UpdateDiscount(int discount, float newCost);
    public void UpdateBigIcon(Sprite icon);

    public void SubscribeToBuy(UnityAction action);
    public void Close();
}
