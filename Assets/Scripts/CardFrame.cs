using System.Collections;
using UnityEngine;
using System;

public class CardFrame : MonoBehaviour
{
    public static CardFrame inst;

    public event Action<Card> cardSelected;

    public static Card currentSelectedCard;

    Material frameMaterial;

    [SerializeField] float colorSetSpeed;

    Coroutine colorLerping;

    void Awake()
    {
        inst = this;

        frameMaterial = GetComponent<Renderer>().sharedMaterial;

        gameObject.SetActive(false);
    }

    public void HighlightCard(Card card)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            frameMaterial.SetColor("_EmissionColor", Color.white * 5f);
        }

        transform.position = card.transform.position;
        transform.rotation = card.transform.rotation;
    }

    public void SelectCard(Card card)
    {
        if (!gameObject.activeSelf)
            return;

        frameMaterial.SetColor("_EmissionColor", Color.red * 12f);

        if (colorLerping != null)
            StopCoroutine(colorLerping);

        colorLerping = StartCoroutine(LerpColor());

        if (cardSelected != null)
            cardSelected(card);

        currentSelectedCard = card; 
    }

    IEnumerator LerpColor()
    {
        while (frameMaterial.GetColor("_EmissionColor") != Color.white)
        {
            var color = frameMaterial.GetColor("_EmissionColor");
            color = Color.Lerp(color, Color.white * 5f, colorSetSpeed * Time.deltaTime);
            frameMaterial.SetColor("_EmissionColor", color);
            yield return null;
        }
    }
}
