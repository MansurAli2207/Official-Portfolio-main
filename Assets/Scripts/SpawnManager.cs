using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
 
    [SerializeField] GameObject _enemyPrefab;
    private float radius = 25 / 2;
    private void Start()
    {
        StartCoroutine(EnemySpawner());
    }
    IEnumerator EnemySpawner()
    {
        while (true)
        {
            float theta = Random.Range(0, 360);
            float x = radius * Mathf.Sin(theta);
            float y = radius * Mathf.Cos(theta);
            Vector3 spwanAT = new Vector3(x, y, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab);
            newEnemy.transform.position = spwanAT;
            yield return new WaitForSeconds(2);
        }
    }
  
}
