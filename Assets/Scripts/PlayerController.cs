using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    Rigidbody rb;
    public GameObject deathParticles;
    public float moveSpeed=1f;
    float maxSpeed=5f;
    Vector3 spawn;
    private Vector3 input;
	// Use this for initialization
	void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        spawn = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //rb.AddForce(input * moveSpeed * Time.deltaTime * 5f);
            rb.velocity = input * moveSpeed;
     }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            Die();
        }
        else if (other.transform.tag == "Goal")
        {
            SceneManager.LoadScene(1);
        }
    }
    void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.Euler(270, 0, 0));
        transform.position = spawn;
    }
}
