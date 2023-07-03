using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace SD
{
    public enum enemyTypes { Ground, Flying }
    public class EnemyStats : MonoBehaviour
    {
        [Header("Enemy Information")]

        [Tooltip("Enemy Icon")]
        public Sprite enemyIcon;
        [Tooltip("Enemy Name")]
        public string enemyName;
        [Tooltip("Enemy Description")]
        public string enemyDescription;
        [Tooltip("Enemy Type")]
        public enemyTypes enemyType;


        [Header("Enemy Stat Information")]

        [Tooltip("Starting HP of this character class")]
        public int baseHP;

        [Tooltip("Starting Strength of this character class")]
        public int baseStrength;

        [Tooltip("Starting Defense of this character class")]
        public int baseDefence;

        [Tooltip("Base movement speed of this character class (in meters/sec)")]
        public float speed;

        [Tooltip("Base XP for death")]
        public int deathXP;


              

    }
}