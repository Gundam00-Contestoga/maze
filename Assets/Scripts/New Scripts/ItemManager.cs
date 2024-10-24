using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemManager : MonoBehaviour
{
    List<Sprite> sprites = new List<Sprite>();
    GameManager gameManager;
    public List<Item> persistentItems;
    GameUI gameUI;
    public List<Sprite> itemSprites;
    //PlayerMovement Instance;



    public ItemManager()
    {
        persistentItems = new List<Item>();
    }
    public void ApplyItemEffects(GameObject item) //Add Item
    {
        if (item.tag == "Clock")
        {
            Sprite sprite = item.GetComponent<Sprite>();
            Clock item1 = new Clock("Clock",sprite);

            persistentItems.Add(item1);
            sprites.Add(sprite);

            gameUI.UpdateCurrentItem(sprite);
            gameManager.UpdateScore(10);
            Destroy(item1);

        }

        if (item.tag == "Boots")
        {
            Sprite sprite = item.GetComponent<Sprite>();
            Boots item1 = new Boots("Boots", sprite);

            persistentItems.Add(item1);
            sprites.Add(sprite);

            gameUI.UpdateCurrentItem(sprite);
            gameManager.UpdateScore(10);
            Destroy(item1);
        }
        if (item.tag == "Crow")
        {
            Sprite sprite = item.GetComponent<Sprite>();
            Crow item1 = new Crow("Crow", sprite);

            persistentItems.Add(item1);
            sprites.Add(sprite);

            gameUI.UpdateCurrentItem(sprite);
            gameManager.UpdateScore(10);
            Destroy(item1);
        }
        if (item.tag == "Scythe")
        {
            Sprite sprite = item.GetComponent<Sprite>();
            Scythe item1 = new Scythe("Scythe", sprite);

            persistentItems.Add(item1);
            sprites.Add(sprite);

            gameUI.UpdateCurrentItem(sprite);
            gameManager.UpdateScore(10);
            Destroy(item1);
        }
    }
    public void UseItem(Clock clock) //Use Item
    {
        gameManager.UpdateTimer(clock.timeIncreaseAmount); //GameManager
        sprites.Remove(clock.itemSprite);
        persistentItems.Remove(clock);
    }

    public void UseItem(Boots boots)
    {
        //PlayerMovement.UptadeSpeed(boots.speedIncreaseAmount); //Player Movement
        sprites.Remove(boots.itemSprite);
        persistentItems.Remove(boots);
    }

    public void UseItem(Crow Crow)
    {
        //PlayerMovement.IncreaseView(); //PlayerMovement?
        sprites.Remove(Crow.itemSprite);
        persistentItems.Remove(Crow);
    }
    public void UseItem(Scythe scythe)
    {
        //PlayerMovement.Cut(); //PlayerMovement?
        sprites.Remove(scythe.itemSprite);
        persistentItems.Remove(scythe);
    }

    public void UptadeAllInventory()
    {
        gameUI.UpdateInventoryUI(sprites);
    }
}
