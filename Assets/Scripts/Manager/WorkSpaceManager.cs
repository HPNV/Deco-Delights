using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkSpaceManager : MonoBehaviour
{
    public static WorkSpaceManager Instance { get; private set; }
    [SerializeField] private Sprite baseSprite1;
    [SerializeField] private Sprite baseSprite2;
    [SerializeField] private Sprite toppingSprite1;
    [SerializeField] private Sprite toppingSprite2;
    [SerializeField] private Sprite creamSprite1;
    [SerializeField] private Sprite creamSprite2;
    [SerializeField] private Cake cakePrefab;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        CheckCake();
    }

    public void CheckCake() {
        if(cakePrefab.baseRenderer.sprite != null && cakePrefab.toppingRenderer.sprite != null && cakePrefab.creamRenderer.sprite != null) {
            QueueManager.Instance.CheckCake(cakePrefab.cakeString());
        }
    }


    public void ResetCake() {
        cakePrefab.baseRenderer.sprite = null;
        cakePrefab.toppingRenderer.sprite = null;
        cakePrefab.creamRenderer.sprite = null;
    }

    public void SetBase1() {
        Debug.Log("SetBase1");
        cakePrefab.baseRenderer.sprite = baseSprite1;
    }

    public void SetBase2() {
        Debug.Log("SetBase2");
        cakePrefab.baseRenderer.sprite = baseSprite2;
    }

    public void SetTopping1() {
        cakePrefab.toppingRenderer.sprite = toppingSprite1;
    }

    public void SetTopping2() {
        cakePrefab.toppingRenderer.sprite = toppingSprite2;
    }

    public void SetCream1() {
        cakePrefab.creamRenderer.sprite = creamSprite1;
    }

    public void SetCream2() {
        cakePrefab.creamRenderer.sprite = creamSprite2;
    }
}
