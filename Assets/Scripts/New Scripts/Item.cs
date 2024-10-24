using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    public Sprite itemSprite;

    public Item(string name, Sprite sprite)
    {
        itemName = name;
        itemSprite = sprite;
    }
}
public class Clock : Item
{
    public float timeIncreaseAmount = 50;

    public Clock(string name, Sprite sprite): base(name, sprite)
    {
    }
}
public class Boots : Item
{
    public float speedIncreaseAmount = 20;

    public Boots(string name, Sprite sprite) : base(name, sprite)
    {
    }
}
public class Crow : Item
{
    public Crow(string name, Sprite sprite) : base(name, sprite)
    {
    }
}
public class Scythe : Item
{
    public Scythe(string name, Sprite sprite) : base(name, sprite)
    {
    }
}
