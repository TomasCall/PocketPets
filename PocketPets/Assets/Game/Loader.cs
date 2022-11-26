using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        HideDefeatedEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HideDefeatedEnemies()
    {
        for (int i = 0; i < DataTransfer.defeatedEnemies.Length; i++)
        {
            if (DataTransfer.defeatedEnemies[i])
            {
                enemies[i].SetActive(false);
            }
        }
    }
}
