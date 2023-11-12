using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    [SerializeField] private AudioClip _clickClip;
    public void ClickedGame2()
    {
        SoundManager.Instance.PlaySound(_clickClip);
        GameManager.Instance.GoToMainMenuGame2();
    } 

    public void ClickedGame1()
    {
        SoundManager.Instance.PlaySound(_clickClip);
        GameManager.Instance.GoToMainMenuGame1();
    } 
}
