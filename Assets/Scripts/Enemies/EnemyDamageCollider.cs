using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SD
{

    public class EnemyDamageCollider : MonoBehaviour
    {
        Collider damageCollider;


        private int enemyDamage;


        private void Awake()
        {
            damageCollider = GetComponent<Collider>();
            damageCollider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "Player")
            {
                PlayerManager playerManager = collision.GetComponent<PlayerManager>();
                CharacterStats characterStats = collision.GetComponentInChildren<CharacterStats>();
                EnemyStats enemyStats = GetComponentInParent<EnemyStats>();

                if (playerManager != null)
                {
                    if (characterStats != null)
                    {
                        enemyDamage = enemyStats.baseStrength - characterStats.baseDefence;
                        playerManager.TakeDamage(enemyDamage);
                    }

                }
            }else if(collision.tag == "Castle")
            {
                CastleManager castleManager = collision.GetComponent<CastleManager>();
                CastleStats castleStats = collision.GetComponentInChildren<CastleStats>();

                EnemyStats enemyStats = GetComponentInParent<EnemyStats>();

                if (castleManager != null)
                {
                    if (castleStats != null)
                    {
                        enemyDamage = enemyStats.baseStrength - castleStats.baseDefence;
                        castleManager.TakeDamage(enemyDamage);
                    }

                }
            }
        }
    }
}