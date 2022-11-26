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
    public Inventory inventory;
    public HandleTextFile handleTextFile;

    public float speed = 1.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        inventory.CreateInventory();
        transform.position = new Vector3(PositionTransporter.playerPositionX, PositionTransporter.playerPositionY, 0f);
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
            inventory.inventory.Add("a+13");
            Debug.Log("Picked up item: a+13");
            handleTextFile.WriteString();
        }
        if (other.gameObject.CompareTag("5Damage"))
        {
            inventory.inventory.Add("a+5");
            Debug.Log("Picked up item: a+5");
            handleTextFile.WriteString();
        }
        if (other.gameObject.CompareTag("13Health"))
        {
            inventory.inventory.Add("h+13");
            Debug.Log("Picked up item: h+13");
            handleTextFile.WriteString();
        }
        if (other.gameObject.CompareTag("5Health"))
        {
            inventory.inventory.Add("h+5");
            Debug.Log("Picked up item: h+5");
            handleTextFile.WriteString();
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