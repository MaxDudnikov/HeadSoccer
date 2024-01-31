using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour
{
    private PolygonCollider2D polygonCollider;

    private void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.transform.tag == "Ball")
        {
            print(collision);
        }
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
        
    //}
}
