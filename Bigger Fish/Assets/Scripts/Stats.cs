using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float scale = 1f;
    public float speed = 1f;

    private void Start()
    {
        gameObject.transform.localScale.Set(scale,scale,1);
    }
}
