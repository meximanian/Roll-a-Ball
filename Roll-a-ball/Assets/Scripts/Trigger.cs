using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    public GameObject Bullet;
    public float speed;

    private Vector3 point;
    private float shoot;
    private float cooldown;

    // Use this for initialization
    void Start()
    {
        speed = 300f;
        cooldown = 0.5f; 
    }
	
	// Update is called once per frame
	void Update()
    {
        if(shoot <= Time.time)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                point = transform.position + new Vector3(0, 0, 0.5f);
                GameObject instBullet = Instantiate(Bullet, point, Quaternion.identity) as GameObject;
                Rigidbody instBulletrb = instBullet.GetComponent<Rigidbody>();
                instBulletrb.AddForce(Vector3.forward * speed);
                Destroy(instBullet, 2);
                shoot = Time.time + cooldown;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                point = transform.position + new Vector3(0, 0, -0.5f);
                GameObject instBullet = Instantiate(Bullet, point, Quaternion.identity) as GameObject;
                Rigidbody instBulletrb = instBullet.GetComponent<Rigidbody>();
                instBulletrb.AddForce(Vector3.back * speed);
                Destroy(instBullet, 2);
                shoot = Time.time + cooldown;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                point = transform.position + new Vector3(-0.5f, 0, 0);
                GameObject instBullet = Instantiate(Bullet, point, Quaternion.identity) as GameObject;
                Rigidbody instBulletrb = instBullet.GetComponent<Rigidbody>();
                instBulletrb.AddForce(Vector3.left * speed);
                Destroy(instBullet, 2);
                shoot = Time.time + cooldown;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                point = transform.position + new Vector3(0.5f, 0, 0);
                GameObject instBullet = Instantiate(Bullet, point, Quaternion.identity) as GameObject;
                Rigidbody instBulletrb = instBullet.GetComponent<Rigidbody>();
                instBulletrb.AddForce(Vector3.right * speed);
                Destroy(instBullet, 2);
                shoot = Time.time + cooldown;
            }
        }
    }
}
