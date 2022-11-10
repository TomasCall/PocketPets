using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    public GameObject player;
    public Transform teleportPoint;
    public Animator animator;

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

        animator.SetFloat("Horizontal", move.x);
        animator.SetFloat("Vertical", move.y);
        animator.SetFloat("Speed", move.sqrMagnitude);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            StartCoroutine(Teleporting());
        }
        if (other.gameObject.CompareTag("Enemy"))
        {

            StartCoroutine(WaitingBeforeSceneLoad());
        }
    }
    IEnumerator Teleporting() {
        yield return new WaitForSeconds(0.5f);
        player.transform.position = teleportPoint.transform.position;
        player.transform.rotation = teleportPoint.transform.rotation;
        Debug.Log("Teleporting to next area!");
    }

    IEnumerator WaitingBeforeSceneLoad()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(3);
        Debug.Log("Entering Combat!");
    }

}