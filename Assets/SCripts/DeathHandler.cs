using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathHandler : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Image damageImage;

    private void Start()
    {
        gameOverCanvas.enabled = false;
        damageImage.enabled = false;
    }
    //
    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        damageImage.enabled = true;
        //FREEZE THE GAME AND UNLOCK THE KEYBOARD INPUT > STOP WEAPON CHANGES ON DEATH.
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
