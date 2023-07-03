using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SD
{
    public class EnemyManager : MonoBehaviour
    {
        private EnemyStats enemyStats;

        private NavMeshAgent agent;
        public GameObject target;
        public float speed;

        [SerializeField]
        private int currentHP;

        [SerializeField]
        private int xpToPlayer;

        private void Awake()
        {
            enemyStats = GetComponent<EnemyStats>();
            currentHP = enemyStats.baseHP;
            
        }

        void OnEnable()
        {
            agent = GetComponent<NavMeshAgent>();
            target = GameObject.Find("Castle");
            agent.SetDestination(target.transform.position);
            agent.speed = enemyStats.speed;
            agent.stoppingDistance = 20;
            
        }

        public void TakeDamage(int damage)
        {   
            Debug.Log(damage);
            currentHP = currentHP - damage;

            if (currentHP <= 0)
            {
                currentHP = 0;
                Death();                
            }
        }

        void Death()
        {
            GiveXP();
            gameObject.SetActive(false);
                // ölüm animasyonu
                // zamanla destroy enemy
        }

        void GiveXP()
        {
            CharacterStats characterStats = GameObject.FindWithTag("Player").GetComponent<CharacterStats>();
            
            xpToPlayer = enemyStats.deathXP;
            characterStats.GetXP(xpToPlayer);
        }
    }
}