using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class Customer : MonoBehaviour
{
    public CustomerData customerData;
    public CustomerStateManager customerStateManager;
    public bool isServed = false;

    [Header("Bubble Chat Settings")]
    public GameObject chatBubblePrefab;
    public Transform bubblePosition;
    public float fadeDuration = 1f;
    public float displayDuration = 3f;
    private GameObject activeBubble;
    private String request;

    private void Start()
    {
        customerStateManager.SetState(new WaitState(), this);
        request = GetRequest();
    }

    private void Update()
    {
        customerStateManager.UpdateState(this);
    }

    public void ShowDialog(string message)
    {
        if (activeBubble != null) Destroy(activeBubble);

        activeBubble = Instantiate(chatBubblePrefab, bubblePosition.position, Quaternion.identity, transform);
        TextMeshProUGUI textComponent = activeBubble.GetComponentInChildren<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = message;
        }

        StartCoroutine(FadeOutBubble(activeBubble, displayDuration, fadeDuration));
    }

    private IEnumerator FadeOutBubble(GameObject bubble, float delay, float fadeDuration)
    {
        yield return new WaitForSeconds(delay);

        CanvasGroup canvasGroup = bubble.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            float elapsed = 0f;

            while (elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(1, 0, elapsed / fadeDuration);
                yield return null;
            }

            canvasGroup.alpha = 0;
        }

        Destroy(bubble);
    }

    public void ToggleRequest()
    {
        if (activeBubble != null) Destroy(activeBubble);
    }

    public String GetRequest()
    {
        return request;
    }

    public void Leave()
    {
        Destroy(gameObject);
    }
}
