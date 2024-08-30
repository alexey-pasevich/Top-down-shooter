using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    [CreateAssetMenu(fileName = "ItemDB", menuName = "TopDownShoot/ItemDB")]
    public class ItemDB : ScriptableObject
    {
        [SerializeField] private List<ItemBase> m_items;

        public ItemBase GetItem(string id)
        { 
            return m_items.Find(x => x.id == id);
        }
    }
}
