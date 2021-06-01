using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotateSpeed;
    public float moveSpeed;
    public GameObject projectileObject;
    public float refireRate;
    public GameObject PlayerFirePoint;
    public float launchPower = 2;


    [HideInInspector]
    private CharacterController playerController;
    private Vector3 previousRotationDirection = Vector3.forward;
    private Vector3 movementVector = new Vector3();
    private Vector3 directionVector = new Vector3();
    private float timePassed;
    private bool canShoot;

    // Start is called before the first frame update
    void Start()
        //turn off cursor
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerController = gameObject.GetComponent<CharacterController>();
        canShoot = true;
        timePassed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float movex = Input.GetAxis("Horizontal");
        float movez = Input.GetAxis("Vertical");
        movementVector = new Vector3(movex, 0.0f, movez);

        float rotx = Input.GetAxis("VR");
        float rotz = -Input.GetAxis("HR");
        directionVector = new Vector3(rotx, 0.0f, rotz);

        if (directionVector.magnitude > 0.1f)
        {
            if (canShoot == true)
            {
                Shoot();
                canShoot = false;
                timePassed = 0.0f;
            }
        }

        if (directionVector.magnitude < 0.1f)
        {
            directionVector = previousRotationDirection;
        }
        
        directionVector = directionVector.normalized;

        previousRotationDirection = directionVector;

        transform.rotation = Quaternion.LookRotation(directionVector);
        playerController.Move(movementVector * Time.deltaTime * moveSpeed);


        

        timePassed += Time.deltaTime;

        if (timePassed >= refireRate)
        {
            canShoot = true;
        }

    }

    public void Shoot()
    {
        GameObject GO = Instantiate(projectileObject, PlayerFirePoint.transform.position, Quaternion.identity) as GameObject;

        GO.GetComponent<Rigidbody>().AddForce(PlayerFirePoint.transform.forward * launchPower, ForceMode.Impulse);
    }
}
