using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SD
{
    public class PlayerAbilities : MonoBehaviour
    {
        private Animator animator;
        private CharacterStats characterStats;

        [Header("Abilities")]
        public Ability[] ability;

        private bool doAbility = false;
        private float currentAbilityTimer;
        [SerializeField]
        public int abilityDamage = 0;
        


        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            characterStats = GetComponent<CharacterStats>();
        }

        public void Attack(int spellNumber)
        {
            if (!doAbility)
            {
                doAbility= true;
                currentAbilityTimer = 0;
                AttackAbility(spellNumber);
                
            }

            if (doAbility)
            {
                currentAbilityTimer += Time.deltaTime;
                if (currentAbilityTimer > ability[spellNumber].cooldown) doAbility = false;
            }
        }

        public void AttackAbility(int spellNumber)
        {
            if (ability[spellNumber].isCastAbility == false)
            {
                animator.Play(ability[spellNumber].animationsName);
                abilityDamage = characterStats.baseStrength + ability[spellNumber].damageAmount;
            }
            else
            {
                CastAbility(spellNumber);
            }

        }

        void CastAbility(int spellNumber)
        {
            if (ability[spellNumber].abilitySpeed > 0) 
                transform.Translate(transform.forward * ability[spellNumber].abilitySpeed * Time.deltaTime);

            //spell i�in collider ve rigidbody eklenecek
            //ontrigger yap�s� eklenecek d��mana gelince hasar + kendisi yok olacak

            Instantiate(ability[spellNumber].castAbility, ability[spellNumber].castPoint.position, ability[spellNumber].castPoint.rotation);
            abilityDamage = characterStats.baseStrength + ability[spellNumber].damageAmount;
        }





    }
}