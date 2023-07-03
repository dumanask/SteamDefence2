using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SD
{
    public class CharacterStats : MonoBehaviour
    {
        [Tooltip("Starting HP of this character class")]
        public int baseHP;

        [Tooltip("Starting Mana of this character class")]
        public int baseMana;

        [Tooltip("Starting Strength of this character class")]
        public int baseStrength;

        [Tooltip("Starting Defense of this character class")]
        public int baseDefence;


        public int level = 1;

        public int currentXP;

        public int xpToLevel = 100;

        private LevellingStats levellingStats;


        private void Awake()
        {
            levellingStats = GetComponent<LevellingStats>();
        }

        private void Start()
        {
            // Save Example
            /*
            SaveData theSave = SaveSystem.instance.activeSave;

            strength = theSave.strength;
            defence = theSave.defence;
            level = theSave.level;
            currentXP = theSave.currentExp;
            xpToLevel = theSave.expToLevel;
            maxHP = theSave.maxHP;
            */
        }

        public void GetXP(int xpGet)
        {
            currentXP += xpGet;

            if (currentXP >= xpToLevel)
            {
                LevelUp();
            }

            //UIController.instance.UpdateUI();
        }

        public void LevelUp()
        {
            // XP fazla olursa 2 level ard arda atlamýyor.

            currentXP -= xpToLevel;

            level++;

            NextLevelXP();

            //Level Updan sonra UI ile stat puanlarý daðýtýlýr.

            //Player.instance.currentHealth++;

            //UIController.instance.UpdateUI();

            StrengthUp();
            DefencehUp();
            HealthUp();
            ManaUp();
        }

        public void NextLevelXP()
        {
            xpToLevel = Mathf.RoundToInt(xpToLevel * 1.2f);
        }

        public void StrengthUp()
        {
            baseStrength += levellingStats.levellingStrength;
        }

        public void DefencehUp()
        {
            baseDefence += levellingStats.levellingDefence;
        }

        public void HealthUp()
        {
            baseHP += levellingStats.levellingHP;
        }

        public void ManaUp()
        {
            baseMana += levellingStats.levellingMana;
        }
    }
}   