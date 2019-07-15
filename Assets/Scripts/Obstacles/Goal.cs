using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Goal : MonoBehaviour
{

    [SerializeField] private Animator animator;
    private VictoryScreen victoryScreen;

    private void Start()
    {
        Assert.IsNotNull(animator);
        victoryScreen = FindObjectOfType<VictoryScreen>();
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
