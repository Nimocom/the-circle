using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager inst;

    [SerializeField] InputField ipAddress;
    [SerializeField] InputField port;
    [SerializeField] InputField nickname;

    [SerializeField] Text warning;

    [SerializeField] Button connectButton;

    void Awake()
    {
        inst = this;
    }

    public void Connect()
    {
        if (ipAddress.text.Length < 3)
            return;
        if (nickname.text.Length < 2)
            return;
        if (port.text.Length < 3)
            return;

        ServerHandler.inst.Connect(ipAddress.text, int.Parse(port.text));

        warning.text = "Please wait...";

        ipAddress.interactable = false;
        port.interactable = false;
        nickname.interactable = false;
        connectButton.interactable = false;
    }

    public void InitializeGame(SerializableData.CommandData commandData)
    {
        GlobalData.InitializeGlobalVariables(commandData);
        warning.text = "Loading...";
        SceneManager.LoadSceneAsync(1);
    }
}
