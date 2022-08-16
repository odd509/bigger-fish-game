using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject GameManager;

    private GameManager gm;

    private void Start()
    {
        gm = GameManager.GetComponent<GameManager>();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        float scaleUp = Mathf.Abs(obj.transform.localScale.x);
        if (obj.tag == "Enemy")
        {
            if (Mathf.Abs(obj.transform.localScale.y) <= Mathf.Abs(transform.localScale.y))
            {
                transform.localScale = new Vector3(transform.localScale.x + (transform.localScale.x > 0 ? 1 : -1) * scaleUp, transform.localScale.y + (transform.localScale.y > 0 ? 1 : -1) * scaleUp, transform.localScale.z + scaleUp);
                Destroy(obj);
            }
            else
            {
                gm.Dead();
            }
        }
    }
}
