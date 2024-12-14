using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _countText;
        
    public void SetItem(Sprite iconSprite, int count)
    {
        _icon.sprite = iconSprite;
        _countText.text = count.ToString();
    }
}
