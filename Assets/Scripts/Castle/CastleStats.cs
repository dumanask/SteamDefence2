using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SD
{
    public class CastleStats : MonoBehaviour
    {
        [Tooltip("Starting HP of this character class")]
        public int baseHP;

        [Tooltip("Starting Defense of this character class")]
        public int baseDefence;
    }
}