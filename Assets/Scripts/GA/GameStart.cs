using GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, SceneManager.GetActiveScene().name); // without score
    }
}
