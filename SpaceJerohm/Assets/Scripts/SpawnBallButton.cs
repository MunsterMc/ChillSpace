using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBallButton : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPos;

    public void spawnBall(GameObject ballPrefab)
    {
        Instantiate(ballPrefab, transform.position, transform.rotation);
    }
}
