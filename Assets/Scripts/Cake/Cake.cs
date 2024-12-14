using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{   
    [SerializeField] public SpriteRenderer baseRenderer;
    [SerializeField] public SpriteRenderer toppingRenderer;
    [SerializeField] public SpriteRenderer creamRenderer;

    void Start()
    {

    }

    public void SetCake(Sprite baseName, Sprite toppingName, Sprite creamName)
    {
        Debug.Log(baseRenderer);
        baseRenderer.sprite = baseName;
        toppingRenderer.sprite = toppingName;
        creamRenderer.sprite = creamName;
    }

    public string cakeString() {
        return baseRenderer.sprite.name + "-" + toppingRenderer.sprite.name + "-" + creamRenderer.sprite.name;
    }
}
