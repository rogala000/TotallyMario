using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Collider2D weaponCollider;

    private void Start()
    {
        weaponCollider.enabled = false;
    }

    public void StartAttack()
    {
        weaponCollider.enabled = true;
    }

    public void EndAttack()
    {
        weaponCollider.enabled = false;
    }



}
