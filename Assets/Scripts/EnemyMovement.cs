using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{    
    public float speed = 10f;

    public int health = 100;

    public GameObject deathEffect;

    public int value = 50;

    private Transform target;

    private int wavepointIndex = 0;

    void Start(){
        target = Waypoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }
    void Update(){
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <=0.2f){

            GetNextWaypoint();
        }

        void GetNextWaypoint(){

            if(wavepointIndex >= Waypoints.points.Length - 1)
            {
                EndPath();
                return;
            }
            wavepointIndex++;
            target = Waypoints.points[wavepointIndex];
        }
    }

    void EndPath()
    {
        PlayerStats.Lives --;
        Destroy(gameObject);
    }
}
