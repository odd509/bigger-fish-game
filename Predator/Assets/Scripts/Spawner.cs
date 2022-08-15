using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawn;
    public float coolDown;

    private bool spawnAvailable = true;
    private bool startRaid = false;

    // startAfterSec : Kaç saniye bekleyip baþlatacaðýný giriyor.
    private void Start()
    {
        StartEnemy();
    }
    void StartEnemy()
    {
        if (spawnAvailable)
        {
            InvokeRepeating("Spawn", 0f, coolDown);
            spawnAvailable = false;
        }
        else
        {
            CancelInvoke();
            spawnAvailable = true;
        }
    }

    void Spawn()
    {
        GameObject copy = Instantiate(spawn, transform.position, Quaternion.identity);
        copy.SetActive(true);
    }

}
