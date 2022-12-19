using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SerializableData : MonoBehaviour
{
    [Serializable]
    public class CommandData
    {
        public string commandType;
        public string commandData;
        public int senderId;
    }

    [Serializable]
    public class ProfileData
    {
        public string username;
        public Vector3 color;
        public int id;
    }

    [Serializable]
    public class CardData
    {
        public int cardIndex;
        public int playerId;

        public bool isNeutral;

        public string cardName;
        public string cardDescription;

        public int cardType;

        public int[] includedEvents;

        public double baseCost;
        public double baseDamage;
        public double power;
    }

    [Serializable]
    public class CardState
    {
        public int cardIndedx;

        public int level;
        public double damage;
        public bool isBlocked;

        public int movesBeforeUnblocking;
    }

    [Serializable]
    public class GameData
    {
        public List<CardData> cardDatas;
        public List<ProfileData> players;
        public int playerId;
    }

    [Serializable]
    public class DiceData
    {
        public Vector3 position;
        public Vector3 rotation;
    }

    [Serializable]
    public class Vector3
    {
        public float x, y, z;
    }

    [Serializable]
    public class CardsDataWrapper
    {
        public List<CardData> cards;
    }

    [Serializable]
    public class TextData
    {
        public string key;
        public string content;
    }

    [Serializable]
    public class LocaData
    {
        public List<TextData> textDatas;
    }
}
