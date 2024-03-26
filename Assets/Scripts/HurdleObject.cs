using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleObject : MonoBehaviour
{
    public Vector3 spawnOffset;
    void Start()
    {
        transform.position += spawnOffset;    
    }
}