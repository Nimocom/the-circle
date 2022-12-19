using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgreementWindow : MonoBehaviour
{
    [SerializeField] List<Card> desiredCards;
    [SerializeField] List<Card> suggestedCards;

    [SerializeField] int desiredDrops;
    [SerializeField] int suggestedDrops;

    [SerializeField] Transform desiredCardsContentRoot;
    [SerializeField] Transform suggestedCardsContentRoot;

    [SerializeField] Text cardInfoTextPrefab;

    Dictionary<Card, GameObject> tableDependencies;

    void Awake()
    {
        desiredCards = new List<Card>();
        suggestedCards = new List<Card>();
        tableDependencies = new Dictionary<Card, GameObject>();
    }

    void Start()
    {
        CardFrame.inst.cardSelected += OnCardSelectedCAllback;
    }

    void OnCardSelectedCAllback(Card card)
    {
        if (card.playerId == -1)
            return;

        else if (card.playerId == GlobalData.playerId)
        {
            if (suggestedCards.Contains(card))
            {
                var tableGo = tableDependencies[card];
                tableDependencies.Remove(card);
                Destroy(tableGo);

                suggestedCards.Remove(card);

                return;
            }

            suggestedCards.Add(card);

            var info = Instantiate(cardInfoTextPrefab, suggestedCardsContentRoot);
            info.text = card.cardName + " (" + card.baseCost + ")";

            tableDependencies.Add(card, info.gameObject);
        }
        else
        {
            if (desiredCards.Contains(card))
            {
                var tableGo = tableDependencies[card];
                tableDependencies.Remove(card);
                Destroy(tableGo);

                desiredCards.Remove(card);

                return;
            }

            desiredCards.Add(card);

            var info = Instantiate(cardInfoTextPrefab, desiredCardsContentRoot);
            info.text = card.cardName + " (" + card.baseCost + ")";

            tableDependencies.Add(card, info.gameObject);
        }
    }
}
