using UnityEngine;

public class CardInfoPanel : MonoBehaviour
{
    [SerializeField] TextMesh cardValueTM;
    [SerializeField] TextMesh turnsCount;

    [SerializeField] GameObject[] levels;

    [SerializeField] GameObject dropIcon;
    [SerializeField] GameObject damageIcon;

    [SerializeField] SpriteRenderer typePanel;

    [SerializeField] Renderer infoPanel;

    public void SetCardValue (int value)
    {
        cardValueTM.text = value.ToString();
    }

    public void SetCardStatus(bool isLive)
    {
        if (isLive)
        {
            dropIcon.SetActive(false);
            damageIcon.SetActive(true);
        }
        else
        {
            dropIcon.SetActive(true);
            damageIcon.SetActive(false);
        }
    }

    public void SetLevel(int level)
    {
        for (int i = 0; i < 5; i++)
        {
            if (i == level - 1)
                levels[i].SetActive(true);
            else
                levels[i].SetActive(false);
        }
    }

    public void SetUserColor(Color color)
    {
        infoPanel.material.color = color;
    }

    public void SetTurnsCounter(int turns)
    {
        turnsCount.text = turns.ToString();
    }
}
