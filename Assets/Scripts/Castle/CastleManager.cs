using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SD
{
    public class CastleManager : MonoBehaviour
    {
        private CastleStats castleStats;

        [SerializeField]
        private int castleHP;

        private void Awake()
        {
            castleStats= GetComponent<CastleStats>();
            castleHP = castleStats.baseHP;            
        }

        public void TakeDamage(int damage)
        {
            Debug.Log(damage);
            castleHP = castleHP - damage;

            if (castleHP <= 0)
            {
                castleHP = 0;
            }
        }
    }
}