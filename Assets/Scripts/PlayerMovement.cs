using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rBody;
    //int forwardSpeed = 650;
    //int rightSpeed = 650;
    //int leftSpeed = -650;
    //int backSpeed = -650;
    public string up;
    public string left;
    public string right;
    public string down;
    public string fire;
    public string projectileName;
    public Vector3 startLocation;

    private float fireRate = 1F;
    private float nextFire = 0.0F;

    GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load(projectileName) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // fire
        if (Input.GetKeyDown(fire) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = transform.position;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 40;
        }
        // up
       else if (Input.GetKey(up))
        {
            //rBody.AddForce(0, 0, forwardSpeed * Time.deltaTime);
            rBody.velocity = new Vector3(0, 0, 3);
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
        }
        // down
        else if (Input.GetKey(down))
        {
            //rBody.AddForce(0, 0, backSpeed * Time.deltaTime);
            rBody.velocity = new Vector3(0, 0, -3);
            GetComponent<Transform>().eulerAngles = new Vector3(0, 180, 0);
        }
        // right
        else if (Input.GetKey(right))
        {
            //rBody.AddForce(rightSpeed * Time.deltaTime, 0, 0);
            rBody.velocity = new Vector3(3, 0, 0);
            GetComponent<Transform>().eulerAngles = new Vector3(0, 90, 0);
        }
        // left
       else if (Input.GetKey(left))
        {
            //rBody.AddForce(leftSpeed * Time.deltaTime, 0, 0);
            rBody.velocity = new Vector3(-3, 0, 0);
            GetComponent<Transform>().eulerAngles = new Vector3(0, -90, 0);
        }

    }

    void OnTriggerEnter(Collider trig)
    {
        if (trig.gameObject.name == "projectile(Clone)" && gameObject.name == "Player2")
        {
            gameObject.transform.position = startLocation;
        }

        if (trig.gameObject.name == "player2projectile(Clone)" && gameObject.name == "Player")
        {
            gameObject.transform.position = startLocation;
        }
    }
}