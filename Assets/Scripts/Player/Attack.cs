using UnityEngine;
using UnityEngine.Assertions;

public class Attack : MonoBehaviour
{
    [SerializeField] private Collider2D weaponCollider;

    private void Start()
    {
        #region Assertions
        Assert.IsNotNull(weaponCollider);
        #endregion

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
