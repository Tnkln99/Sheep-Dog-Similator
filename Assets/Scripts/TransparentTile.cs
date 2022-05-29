using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TilemapCollider2D))]
public class TransparentTile : MonoBehaviour
{
    private Tilemap tm;

    private void Start()
    {
        tm = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tm.color = new Color(1, 1, 1, 0.5f);
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        tm.color = new Color(1, 1, 1, 1);
    }
    
}
