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
        if(!DataTransfer.isTutorial)
        {
            transform.position = new Vector3(DataTransfer.playerPositionX, DataTransfer.playerPositionY, 0f);
        }
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

        //Inventory Management
        if (other.gameObject.CompareTag("13Damage"))
        {
            DataTransfer.items.Add("a+13");
            Debug.Log("Picked up item: a+13");
        }
        if (other.gameObject.CompareTag("5Damage"))
        {
            DataTransfer.items.Add("a+5");
            Debug.Log("Picked up item: a+5");
        }
        if (other.gameObject.CompareTag("13Health"))
        {
            DataTransfer.items.Add("h+13");
            Debug.Log("Picked up item: h+13");
        }
        if (other.gameObject.CompareTag("5Health"))
        {
            DataTransfer.items.Add("h+5");
            Debug.Log("Picked up item: h+5");
        }
        Debug.Log(DataTransfer.items.Count);

        if (other.gameObject.CompareTag("Fish"))
        {
            DataTransfer.currentEnemyIndex = 0;
            DataTransfer.playerPositionX = -65.1112f;
            DataTransfer.playerPositionY = 95.15679f;
        }
        if (other.gameObject.CompareTag("Cica"))
        {
            DataTransfer.currentEnemyIndex = 1;
            DataTransfer.playerPositionX = 621.2276f;
            DataTransfer.playerPositionY = -499.2258f;
        }
        if (other.gameObject.CompareTag("Doggo"))
        {
            DataTransfer.currentEnemyIndex = 2;
            DataTransfer.playerPositionX = -749.2672f;
            DataTransfer.playerPositionY = 323.6138f;
        }
        if (other.gameObject.CompareTag("Panda"))
        {
            DataTransfer.currentEnemyIndex = 3;
            DataTransfer.playerPositionX = 739.9427f;
            DataTransfer.playerPositionY = 357.8624f;
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
        SceneManager.LoadScene("Combat");
        Debug.Log("Entering Combat!");
    }

}