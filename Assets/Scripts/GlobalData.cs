using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public static List<SerializableData.ProfileData> players { get; private set; }
    public static List<SerializableData.CardData> cardDatas { get; private set; }

    public static int playerId { get; private set; }

    public static void InitializeGlobalVariables(SerializableData.CommandData commandData)
    {
        SerializableData.GameData gameData = JsonUtility.FromJson<SerializableData.GameData>(commandData.commandData);

        players = gameData.players;
        cardDatas = gameData.cardDatas;

        playerId = gameData.playerId;
    }
}
