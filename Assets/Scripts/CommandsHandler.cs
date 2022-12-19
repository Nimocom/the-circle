using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CommandsHandler : MonoBehaviour
{
    public static CommandsHandler inst;

    SerializableData.CommandData commandData;

    List<Action<SerializableData.CommandData>> executionQueue;

    void Awake()
    {
        inst = this;
        DontDestroyOnLoad(gameObject);

        executionQueue = new List<Action<SerializableData.CommandData>>();
    }

    public void HandleCommand(string command)
    {
        commandData = JsonUtility.FromJson<SerializableData.CommandData>(command);

        switch (commandData.commandType)
        {
            case "chatmessage": executionQueue.Add(ChatWindow.inst.AddMessage);  break;
            case "initializegame": executionQueue.Add(MenuManager.inst.InitializeGame); break;
        }
    }

    void Update()
    {
        for (int i = 0; i < executionQueue.Count; i++)
        {
            if (executionQueue[i] != null)
            {
                executionQueue[i](commandData);
                executionQueue.RemoveAt(i);
            }
        }
    }
}
