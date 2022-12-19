using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersTable : MonoBehaviour
{
    public static PlayersTable inst;

    public PlayerPanel[] playerPanels;

    [SerializeField] PlayerPanel playerPanelPrefab;

    void Awake()
    {
        inst = this;
    }

    public void AddPlayerPanel(int index, Color color, string name)
    {
        PlayerPanel playerPanel = Instantiate(playerPanelPrefab, transform);
        playerPanel.InitializePanel(index, color, name);
        playerPanels[index] = playerPanel;
    }
}