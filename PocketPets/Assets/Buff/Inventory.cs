using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> inventory;
    public void CreateInventory()
    {
        inventory = new List<string>();
    }

}
