using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject target;

    public Material RedOutline;
    public Material GreenOutline;

    public float speedConstant = 1f;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Transform targetTs = target.transform;
        // Outline
        if (Mathf.Abs(targetTs.localScale.y) >= Mathf.Abs(transform.localScale.y)) sr.material = GreenOutline;
        else sr.material = RedOutline;

        // Move Toward
        if ((targetTs.position.x > transform.position.x && transform.localScale.x > 0) ||(targetTs.position.x < transform.position.x && transform.localScale.x < 0)) 
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        transform.position = Vector2.MoveTowards(transform.position, targetTs.position, ((speedConstant * Time.deltaTime)));
    }

    
}
