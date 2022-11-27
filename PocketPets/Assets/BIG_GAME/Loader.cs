using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> animals;

    // Start is called before the first frame update
    void Start()
    {
        HideDefeatedEnemies();
        HideAlreadyPosesedItems();
        DataTransfer.isTutorial = false;
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
            else
            {
                animals[i].SetActive(false);
            }
        }
    }

    void HideAlreadyPosesedItems()
    {
        foreach(var name in DataTransfer.itemGameObjectNames)
        {
            GameObject.Find(name).SetActive(false);
        }
    }
}
