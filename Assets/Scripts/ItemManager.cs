using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemManager : MonoBehaviour
{
    GameManager gameManager;
    public static Item usableItem;
    GameUI gameUI;

    public ItemManager()
    {
    }
    public void ApplyItemEffects(GameObject item) //Add Item
    {
        if (item.tag == "Clock")
        {
            Sprite sprite = item.GetComponent<Sprite>();
            Clock item1 = new Clock("Clock",sprite);
            usableItem = item1;


            gameUI.UpdateCurrentItem(sprite);
            gameManager.UpdateScore(10);
            Destroy(item1);
        }

        if (item.tag == "Boots")
        {
            Sprite sprite = item.GetComponent<Sprite>();
            Boots item1 = new Boots("Boots", sprite);
            usableItem = item1;

            gameUI.UpdateCurrentItem(sprite);
            gameManager.UpdateScore(10);
            Destroy(item1);
        }
        if (item.tag == "Crow")
        {
            Sprite sprite = item.GetComponent<Sprite>();
            Crow item1 = new Crow("Crow", sprite);
            usableItem = item1;

            gameUI.UpdateCurrentItem(sprite);
            gameManager.UpdateScore(10);
            Destroy(item1); 
        }
        //if (item.tag == "Scythe")
        //{
        //    Sprite sprite = item.GetComponent<Sprite>();
        //    Scythe item1 = new Scythe("Scythe", sprite);
        //    usableItem = item1;

        //    gameUI.UpdateCurrentItem(sprite);
        //    gameManager.UpdateScore(10);
        //    //Destroy(item1);  //Maze.RemoveItem(item)
        //}
    }

    public void UseCurrentItem() //Metodo do Player
    {
        if (usableItem != null)
        {
            usableItem.Use();
        }
    }
}
