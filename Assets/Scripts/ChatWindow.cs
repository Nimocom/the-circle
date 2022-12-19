
using UnityEngine;
using UnityEngine.UI;

public class ChatWindow : MonoBehaviour
{
    public static ChatWindow inst;

    [SerializeField] Transform messagesContentRoot;

    [SerializeField] ChatMessage chatMessagePrefab;

    [SerializeField] ScrollRect scrollbar;

    [SerializeField] InputField inputField;

    bool isFocused;

    void Awake()
    {
        inst = this;
    }

    public void AddMessage(SerializableData.CommandData commandData)
    {
        Instantiate(chatMessagePrefab, messagesContentRoot).SetMessageText(commandData.commandData);
        scrollbar.velocity = new Vector2(0f, 300f);
    }

    public void SendMessageToServer(InputField inputField)
    {
        if (inputField.text.Length == 0)
            return;

        var cmd = new SerializableData.CommandData();

        cmd.commandType = "chatmessage";
        cmd.commandData = inputField.text;

        inputField.text = "";

        ServerHandler.inst.SendCommand(JsonUtility.ToJson(cmd));
    }

    void Update()
    {
        if (isFocused && Input.GetKeyDown(KeyCode.Return))
        {
            SendMessageToServer(inputField);
        }

        isFocused = inputField.isFocused;
    }
}
