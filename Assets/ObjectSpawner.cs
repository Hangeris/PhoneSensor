using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject ballPrefab;
    public Transform ballParent;
    public Vector2Int ballSpawnRange = Vector2Int.one;
    
    void Start()
    {
        var randomBallAmount = Random.Range(ballSpawnRange.x, ballSpawnRange.y+1);
        
        for (int i = 0; i < randomBallAmount; i++)
        {
            Instantiate(ballPrefab, transform.position, Quaternion.identity, ballParent);
        }
    }

}
