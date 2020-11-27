using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject ballPrefab;
    public Transform ballParent;
    public Vector2Int ballSpawnRange = Vector2Int.one;

    public void Init()
    {
        var randomBallAmount = Random.Range(ballSpawnRange.x, ballSpawnRange.y+1);
        
        for (int i = 0; i < randomBallAmount; i++)
        {
            var ballGO = Instantiate(ballPrefab, transform.position, Quaternion.identity, ballParent);
            ballGO.GetComponent<Ball>().Init();
        }
    }

}
