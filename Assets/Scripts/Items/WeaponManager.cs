using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SD
{
    public class WeaponManager : MonoBehaviour
    {
        //public Transform handLocation;
        public Transform gunHolder;
        public GameObject weapon;
        public WeaponItem weaponItem;


        private void Awake()
        {
            LoadWeaponModel(weaponItem);
        }

        void LoadWeaponModel(WeaponItem weaponItem)
        {
            GameObject model = Instantiate(weaponItem.modelPrefab) as GameObject;

            if (model != null)
            {
                if (gunHolder != null)
                {
                    model.transform.parent = gunHolder;
                }
                else
                {
                    model.transform.parent = transform;
                }

                model.transform.localPosition = weapon.transform.localPosition;
                model.transform.localRotation = Quaternion.identity;
                model.transform.localScale = weapon.transform.localScale;
            }
        }


    }
}