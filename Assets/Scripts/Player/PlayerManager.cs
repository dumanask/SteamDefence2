using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SD
{
    public class PlayerManager : MonoBehaviour
    {
        private CharacterStats characterStats;
        private Animator animator;
        private PlayerAbilities playerAbilities;

        [SerializeField]
        private int currentHealth;
        [SerializeField]
        private int damage;
        public static bool canAttack;      

        public bool weaponIsMelee = true;

        public GameObject meleeHolder;
        public GameObject rangeHolder;


        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            playerAbilities = GetComponent<PlayerAbilities>();
            characterStats = GetComponent<CharacterStats>();
            currentHealth = characterStats.baseHP;
        }


        #region ATTACKS

        //Normal Attacks
        public void NormalAttack()
        {
            animator.SetBool("Attacking", canAttack);
            if (weaponIsMelee == true)
            {
                //Melee
                playerAbilities.AttackAbility(0);
            }
            else
            {
                //Range
                playerAbilities.AttackAbility(4);
            }
        }

        //Attack1
        public void Attack1()
        {
            animator.SetBool("Attacking", canAttack);
            if (weaponIsMelee == true)
            {
                //Melee
                playerAbilities.AttackAbility(1);
            }
            else
            {
                //Range
                playerAbilities.AttackAbility(5);
            }
        }

        //Attack2
        public void Attack2()
        {
            animator.SetBool("Attacking", canAttack);
            if (weaponIsMelee == true)
            {
                //Melee
                playerAbilities.AttackAbility(2);
            }
            else
            {
                //Range
                playerAbilities.AttackAbility(6);
            }
        }

        //Attack3
        public void Attack3()
        {
            animator.SetBool("Attacking", canAttack);
            if (weaponIsMelee == true)
            {
                //Melee
                playerAbilities.AttackAbility(3);
            }
            else
            {
                //Range
                playerAbilities.AttackAbility(7);
            }
        }
        
        #endregion 

        public void ChangeWeapon()
        {
            // Silah Pozisyonu deðiþtirilecek


            if(weaponIsMelee == true)
            {
                weaponIsMelee = false;
                meleeHolder.SetActive(false);
                rangeHolder.SetActive(true);
            }
            else
            {
                weaponIsMelee = true;

                meleeHolder.SetActive(true);
                rangeHolder.SetActive(false);
            }

            
        }

        public void TakeDamage(int damage)
        {
            Debug.Log(damage);
            currentHealth = currentHealth - damage;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }
        }

    }
}