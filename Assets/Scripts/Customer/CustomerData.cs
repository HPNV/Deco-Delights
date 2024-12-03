using UnityEngine;

[CreateAssetMenu(fileName = "CustomerData", menuName = "Game/CustomerData", order = 1)]
public class CustomerData : ScriptableObject
{
    public string customerName;
    public Sprite customerSprite;
    public float patienceTime;
    public float eatTime;
}
