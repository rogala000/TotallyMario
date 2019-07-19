using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PlayerControlsCanvas : MonoBehaviour
{

    [SerializeField] private bl_Joystick joystick;
    [SerializeField] private Button jumpButton;
    [SerializeField] private Button attackButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private List<GameObject> hearts;

    public bl_Joystick Joystick { get => joystick;}
    public Button JumpButton { get => jumpButton;}
    public Button AttackButton { get => attackButton;}
    public Button OptionsButton { get => optionsButton;}
    public List<GameObject> Hearts { get => hearts; set => hearts = value; }

    private void Start()
    {
        #region Assertions
        Assert.IsNotNull(joystick);
        Assert.IsNotNull(jumpButton);
        Assert.IsNotNull(attackButton);
        Assert.IsNotNull(optionsButton);
        Assert.IsNotNull(hearts);
        #endregion
    }
}
