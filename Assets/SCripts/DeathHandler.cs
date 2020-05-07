using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.enabled = false;
    }
    //
    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        //FREEZE THE GAME AND UNLOCK THE KEYBOARD INPUT.
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
