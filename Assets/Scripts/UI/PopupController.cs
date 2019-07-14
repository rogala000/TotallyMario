using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{

    [SerializeField] Button closeButton;
    [SerializeField] GameObject popupGameObject;

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(closeButton);
        Assert.IsNotNull(popupGameObject);


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
