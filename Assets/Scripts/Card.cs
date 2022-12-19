using UnityEngine;


public class Card : MonoBehaviour
{
    public double baseCost;
    public double baseDamage;

    public double power;

    public int cardIndex;

    public int playerId;

    public int level;

    public string cardDescription;
    public string cardName;

    public bool isActive;

    public int movesBeforeActivation;

    [SerializeField] CardInfoPanel cardInfoPanel;

    void Awake()
    {
        cardInfoPanel = transform.GetChild(0).GetComponent<CardInfoPanel>();
    }

    public void InitializeCard()
    { 
    
    }

    void OnMouseEnter()
    {
        CardFrame.inst.HighlightCard(this);
    }

    void OnMouseExit()
    {
        CardFrame.inst.gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        CardFrame.inst.SelectCard(this);
    }
}
