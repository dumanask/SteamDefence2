using SD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{

    public void AttackPause()
    {
        PlayerManager.canAttack = true;
    }

    public void AttackResume()
    {
        PlayerManager.canAttack = false;
        
    }
}
