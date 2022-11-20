using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;

    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        animator.SetTrigger("pop");
    }

    public string popUp;
    private void OnTriggerEnter(Collider collision)
    {
        PopUpSystem pop = GameObject.FindGameObjectWithTag("PopUpTrigger").GetComponent<PopUpSystem>();
        pop.PopUp(popUp);

        // leveszi a colidert az adott GameObject-rõl
        //this.GetComponent<BoxCollider>().enabled = false;
    }
}
