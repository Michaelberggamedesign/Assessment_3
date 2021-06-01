using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public GameObject PlayerFirePosition;
    private Vector3 directionVector = new Vector3();


    // Start is called before the first frame update
    void Start()
    { 
        Destroy(gameObject, lifeTime);
    }

    private void Awake()
    {
        PlayerFirePosition.GetComponent<Transform>().transform.rotation = Quaternion.LookRotation(directionVector);
    }
}
