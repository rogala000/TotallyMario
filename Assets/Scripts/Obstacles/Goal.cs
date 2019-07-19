using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class Goal : MonoBehaviour
{

    [SerializeField] private Animator animator;

    private VictoryScreen victoryScreen;

    private void Start()
    {
        victoryScreen = FindObjectOfType<VictoryScreen>();

        #region Assertions
        Assert.IsNotNull(animator);
        Assert.IsNotNull(victoryScreen);
        #endregion

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger(Config.Goal);
            StartCoroutine(WinGame());
        }
    }

    IEnumerator WinGame()
    {
        yield return new WaitForSeconds(2);
        victoryScreen.WinGame();
    }

}
