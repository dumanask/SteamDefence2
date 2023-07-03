using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SD
{
    [CreateAssetMenu(menuName = "Items/Weapon Item")]
    public class WeaponItem : ScriptableObject
    {
        [Header("Item Information")]
        public Sprite itemIcon;
        public string itemName;

        public GameObject modelPrefab;




    }
}
