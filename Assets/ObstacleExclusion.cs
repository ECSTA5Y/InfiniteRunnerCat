using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleExclusion : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        gameObject.GetComponent<Collider>().isTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            print("ObstacleDestroyed:"+other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}