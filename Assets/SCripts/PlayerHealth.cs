using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float playerHitPoints = 100f;
    [SerializeField] Image feedbackImage;
    [SerializeField] float displayTime = .3f;

    //TAKE CARE OF BUISNESS.
    public void TakeDamage(float damage)
    {
        playerHitPoints -= damage;
        StartCoroutine(ImageToggle());
        if (playerHitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
    //HURT IMAGE TOGGLE.
    IEnumerator ImageToggle()
    {
        feedbackImage.enabled = true;
        yield return new WaitForSeconds(displayTime);
        feedbackImage.enabled = false;
    }
}
