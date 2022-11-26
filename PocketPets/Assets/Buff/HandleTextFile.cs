using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HandleTextFile : MonoBehaviour
{
    public Inventory inventory;

    public void WriteString()
    {
        string path = "Assets/Data/inventory.txt";
        StreamWriter writer = new StreamWriter(path);

        foreach (var item in inventory.inventory)
        {
            writer.WriteLine(item);
        }
        writer.Close();
    }
}
