using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeRequest : MonoBehaviour
{
    [SerializeField] private Cake cake;
    public void SetCake(GameObject cakeObject)
    {
        Cake newCake = cakeObject.GetComponent<Cake>();
        Debug.Log("1",newCake.baseRenderer.sprite);
        cake.SetCake(newCake.baseRenderer.sprite, newCake.toppingRenderer.sprite, newCake.creamRenderer.sprite);
        Debug.Log("2",cake.toppingRenderer.sprite);
    }
}
