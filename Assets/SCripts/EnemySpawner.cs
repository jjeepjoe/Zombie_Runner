using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //
    [SerializeField] EnemyAttack badGuyPrefab;
    [SerializeField] float delaySpawn = 5f;

    private void Start()
    {
        SetAlive();
    }
    //
    IEnumerator SpawnBadGuy()
    {
        yield return new WaitForSeconds(delaySpawn);
        Instantiate(badGuyPrefab, transform);
        Debug.Log("SPAWN ");
        
    }
    //FOR ROSEMARIE GAME
    public void SetAlive()
    {
        StartCoroutine(SpawnBadGuy());
        Debug.Log("SETTING ");
    }
}
