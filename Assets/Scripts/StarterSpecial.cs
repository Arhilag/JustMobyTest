using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpecialWindowColtroller;

public class StarterSpecial : MonoBehaviour
{
    [SerializeField] private IconsConfig itemIcons;
    [SerializeField] private IconsConfig bigIcons;
    [SerializeField] private SpecialWindowColtroller _specialWindowColtroller;
    [Space(5)]
    [Header("������� ���������")]
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private float cost;
    [Tooltip("�������� 0 ���� ������ �� ���������")]
    [SerializeField] private int discount;
    [Header("��������� ����� � ������")]
    [SerializeField] private bool randomSprites = true;
    [Header("�������� ����� � ������")]
    [SerializeField] private List<string> itemsName;
    [SerializeField] private string bigIconName;
    private int countItems;
    public void ChangeCountItems(string value)
    {
        countItems = int.Parse(value);
    }

    public void Show()
    {
        SpecialWindowData data = new SpecialWindowData()
        {
            Title = title,
            Description = description,
            ItemsName = randomSprites ? GetRandomItems(countItems) : itemsName,
            Cost = cost,
            Discount = discount,
            BigIconName = randomSprites ? GetRandomItem(bigIcons) : bigIconName
        };


        _specialWindowColtroller.Initialize(data);
    }

    private List<string> GetRandomItems(int count)
    {
        List<string> items = new List<string>();
        for (int i = 0; i < count; i++)
        {
            items.Add(GetRandomItem(itemIcons));
        }
        return items;
    }

    private string GetRandomItem(IconsConfig config)
    {
        return config.Icons[Random.Range(0, config.Icons.Length)].Name;
    }
}
