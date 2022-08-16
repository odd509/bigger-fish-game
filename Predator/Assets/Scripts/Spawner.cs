using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Objects")]
    public GameObject spawn;
    public GameObject player;
    public List<Sprite> sprites;

    [Header("Spawn Object")]
    public float speedConstant = 1f;
    public float activeDistance = 4f;
    public bool lookRight;

    [Header("Spawner")]
    public float coolDown;
    public float spawnY = 5f;
    public float scalePercentToPlayer = 2f;

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
        GameObject copy = Instantiate(spawn, new Vector3(transform.position.x, Random.Range(-spawnY, spawnY), 0), Quaternion.identity);
        EnemyManager enemyManager = copy.GetComponent<EnemyManager>();
        enemyManager.activeDistance = activeDistance;
        enemyManager.speedConstant = speedConstant;

        //Scale
        float scalePercentage = player.transform.localScale.x / scalePercentToPlayer;
        float scale = Random.Range(player.transform.localScale.x - scalePercentage, player.transform.localScale.x + scalePercentage);
        copy.transform.localScale = new Vector3(scale, scale, scale);
        if (lookRight)
        {
            copy.transform.localScale = new Vector3(-copy.transform.localScale.x, copy.transform.localScale.y, copy.transform.localScale.z);
        }

        copy.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count - 1)];
        
        copy.GetComponent<EnemyManager>().activeDistance += scale;
        copy.SetActive(true);
    }

}
