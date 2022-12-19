
using UnityEngine;
using UnityEngine.UI;

public class ChatMessage : MonoBehaviour
{
    [SerializeField] Text message;

    public void SetMessageText(string messageText) => message.text = messageText;
}
