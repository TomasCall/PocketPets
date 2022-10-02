using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    public GameObject player;
    public Transform teleportPoint;

    public float speed = 1.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.up * y;

        controller.Move(move * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            player.transform.position = teleportPoint.transform.position;
            player.transform.rotation = teleportPoint.transform.rotation;
            Debug.Log("Teleporting to next area!");
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Combat", LoadSceneMode.Single);
            Debug.Log("Entering Combat!");
        }
    }
}