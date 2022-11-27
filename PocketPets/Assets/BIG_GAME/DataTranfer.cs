using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataTransfer
{
    public static float playerPositionX = 410.1456f;
    public static float playerPositionY = -202.1205f;
    //The order: Fish, Cat, Dog, Panda
    public static bool[] defeatedEnemies = {false, false, false, false };
    public static int currentEnemyIndex = 0;
    public static List<string> items = new List<string>();
    public static bool isTutorial = true;
    public static List<Sprite> itemSprites = new List<Sprite>();
    public static List<string> itemGameObjectNames = new List<string>();
}
