using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemManager : MonoBehaviour
{
    GameManager gameManager;
    public List<Item> persistentItems;
    GameUI gameUI;
    public List<Sprite> itemSprites;
    //PlayerMovement Instance;



    public ItemManager()
    {
        persistentItems = new List<Item>();
        itemSprites = new List<Sprite>();
    }
    public void ApplyItemEffects(GameObject item) //Add Item
    {
        if (item.tag == "Clock")
        {
            Sprite sprite = item.GetComponent<Sprite>();
            Clock item1 = new Clock("Clock",sprite);

            persistentItems.Add(item1);
            itemSprites.Add(sprite);


            gameUI.UpdateInventoryUI(itemSprites);
            gameManager.UpdateScore(10);
            Destroy(item1);

        }

        if (item.tag == "Boots")
        {
            Sprite sprite = item.GetComponent<Sprite>();
            Boots item1 = new Boots("Boots", sprite);

            persistentItems.Add(item1);
            itemSprites.Add(sprite);

            gameUI.UpdateInventoryUI(itemSprites);
            gameManager.UpdateScore(10);
            Destroy(item1);
        }
        if (item.tag == "Crow")
        {
            Sprite sprite = item.GetComponent<Sprite>();
            Crow item1 = new Crow("Crow", sprite);

            persistentItems.Add(item1);
            itemSprites.Add(sprite);

            gameUI.UpdateInventoryUI(itemSprites);
            gameManager.UpdateScore(10);
            Destroy(item1);
        }
        if (item.tag == "Scythe")
        {
            Sprite sprite = item.GetComponent<Sprite>();
            Scythe item1 = new Scythe("Scythe", sprite);

            persistentItems.Add(item1);
            itemSprites.Add(sprite);

            gameUI.UpdateInventoryUI(itemSprites);
            gameManager.UpdateScore(10);
            Destroy(item1);
        }
    }
    public void UseItem(Clock clock)
    {
        gameManager.UpdateTimer(clock.timeIncreaseAmount); //GameManager
        persistentItems.Remove(clock);
        Sprite sprite = clock.GetComponent<Sprite>();
        itemSprites.Remove(sprite);
        gameUI.UpdateInventoryUI(itemSprites);
    }

    public void UseItem(Boots boots)
    {
        //PlayerMovement.UptadeSpeed(boots.speedIncreaseAmount); //Player Movement
        persistentItems.Remove(boots);
        Sprite sprite = boots.GetComponent<Sprite>();
        itemSprites.Remove(sprite);
        gameUI.UpdateInventoryUI(itemSprites);
    }

    public void UseItem(Crow Crow)
    {
        //PlayerMovement.IncreaseView(); //PlayerMovement?
        persistentItems.Remove(Crow);
        Sprite sprite = Crow.GetComponent<Sprite>();
        itemSprites.Remove(sprite);
        gameUI.UpdateInventoryUI(itemSprites);
    }
    public void UseItem(Scythe scythe)
    {
        //PlayerMovement.Cut(); //PlayerMovement?
        persistentItems.Remove(scythe);
        Sprite sprite = scythe.GetComponent<Sprite>();
        itemSprites.Remove(sprite);
        gameUI.UpdateInventoryUI(itemSprites);
    }
}
