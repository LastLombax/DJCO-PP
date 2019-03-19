using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarScript : MonoBehaviour
{
    public GameObject enemy;
    private Vector3 localScale;
    private float scaleX;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        scaleX = localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float enemyLife = enemy.GetComponent<Enemy>().getEnemyHealthPercentage();
        localScale.x = enemyLife * scaleX;
        transform.localScale = localScale;
    }
}
