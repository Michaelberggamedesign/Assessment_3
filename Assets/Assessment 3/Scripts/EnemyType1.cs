using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1 : MonoBehaviour
{
    public float speed;
    public GameObject Enemy;
    private GameObject Player;

    //Finds the player in the scene
    private void Awake()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Enemy.transform.LookAt(new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Player Dead!!");
            
        }
        if (other.tag == "PlayerProjectile")
        {
            Destroy(gameObject);
        }
    }

    public void Kill()
    {
        // do a murder
        Destroy(gameObject);
    }
    
}