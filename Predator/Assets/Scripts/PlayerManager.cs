using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject GameManager;

    float scaleUpPercent = 0.1f;

    private GameManager gm;

    private void Start()
    {
        gm = GameManager.GetComponent<GameManager>();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision);
        GameObject obj = collision.gameObject;
        if (obj.tag == "Enemy")
        {
            if (Mathf.Abs(obj.transform.localScale.y) <= Mathf.Abs(transform.localScale.y))
            {
                Destroy(obj);
                transform.localScale *= scaleUpPercent;
            }
            else
            {
                gm.Dead();
            }
        }
    }
}
