using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SD
{
    public class DamageCollider : MonoBehaviour
    {
        Collider damageCollider;

        private int playerDamage;
       

        private void Awake()
        {
            damageCollider = GetComponent<Collider>();
            damageCollider.gameObject.SetActive(true);
            damageCollider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider collision)
        {

            if (collision.tag == "Enemy")
            {               
                EnemyManager enemyManager = collision.GetComponent<EnemyManager>();
                EnemyStats enemyStats = collision.GetComponentInChildren<EnemyStats>();
                //CharacterStats characterStats = GetComponentInParent<CharacterStats>();
                PlayerAbilities playerAbilities = GetComponentInParent<PlayerAbilities>(); 

                if (enemyManager != null)
                {
                    if (enemyStats != null)
                    {
                        if (playerAbilities != null)
                        {
                            playerDamage = playerAbilities.abilityDamage - enemyStats.baseDefence;
                            enemyManager.TakeDamage(playerDamage);
                        }
                    }
                }

            }
        }
    }
}   