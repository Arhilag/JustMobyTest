using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "IconsConfig", menuName = "Configs/IconsConfig", order = 0)]
public class IconsConfig : ScriptableObject
{
    [SerializeField] private IconData[] icons;
    public IconData[] Icons => icons;

    [Serializable]
    public struct IconData
    {
        public string Name;
        public Sprite Icon;
    }
}
