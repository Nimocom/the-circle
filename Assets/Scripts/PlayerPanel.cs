using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField] Text userName;
    [SerializeField] Text blood;

    [SerializeField] Image panel;
    [SerializeField] Image userColorImage;

    [SerializeField] Color activeColor;
    [SerializeField] Color inactiveColor;
    [SerializeField] Color deactivatedColor;

    public int playerIndex;

    Coroutine lerpingColor;

    public void InitializePanel(int index, Color color, string name)
    {
        playerIndex = index;
        userColorImage.color = color;
        userName.text = name;
    }

    public void SetBlood(int amount)
    {
        blood.text = amount.ToString();
    }

    public void DeactivatePanel()
    {
        panel.color = deactivatedColor;
    }

    public void HighlightPanel(bool isHighlighted)
    {
        if (lerpingColor != null)
            StopCoroutine(lerpingColor);

        lerpingColor = StartCoroutine(LerpColor(isHighlighted ? activeColor : inactiveColor));
    }

    IEnumerator LerpColor(Color targetColor)
    {
        while (panel.color != targetColor)
        {
            panel.color = Color.Lerp(panel.color, targetColor, 12f * Time.deltaTime);
            yield return null;
        }
    }
}
