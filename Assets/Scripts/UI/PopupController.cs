using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{

    [SerializeField] private Button closeButton;
    [SerializeField] private GameObject popupGameObject;

    void Start()
    {
        #region Assertions
        Assert.IsNotNull(closeButton);
        Assert.IsNotNull(popupGameObject);
        #endregion

        closeButton.onClick.AddListener(ClosePopup);
    }

    private void ClosePopup()
    {
        popupGameObject.SetActive(false);
    }

    public void ShowPopup()
    {
        popupGameObject.SetActive(true);
    }

}
