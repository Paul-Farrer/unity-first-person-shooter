using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.enabled = false; // hides the gameOverCanvas when the game is started   
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true; // when the player dies the canvas is enabled and displayed again
        Time.timeScale = 0; // stops the game time
        FindObjectOfType<SwitchWeapon>().enabled = false;
        Cursor.lockState = CursorLockMode.None; // cursor is not locked 
        Cursor.visible = true; // makes the cursor visible 
    }
}
