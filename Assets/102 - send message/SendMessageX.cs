using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SendMessageX : MonoBehaviour
{
    public int serverPort = 4444;
    public InputField messageInput;
    public InputField fromInput;

    void Start()
    {
        SetupServer();
        SetupClient();
    }

    #region Server 

    private void SetupServer()
    {
        if (NetworkServer.active)
        {
            return;
        }

        NetworkServer.RegisterHandler(MsgType.Connect, OnConnected);
        NetworkServer.RegisterHandler(MessageX.MsgType, OnMessageXReceived);

        bool success = NetworkServer.Listen(serverPort);

        if (success)
        {
            Debug.Log("Server Started");
        }
        else
        {
            Debug.Log("Start Server failed");
        }
    }

    private void OnConnected(NetworkMessage msg)
    {
        Debug.Log("A client connected!");
    }

    private void OnMessageXReceived(NetworkMessage msg)
    {
        MessageX mx = msg.ReadMessage<MessageX>();
        Debug.Log(string.Format("SERVER: {0}", mx));
    }

    #endregion

    #region Client

    NetworkClient client;

    private void SetupClient()
    {
        if (client == null)
        {
            client = new NetworkClient();
            client.Connect("127.0.0.1", serverPort);
        }
    }

    public void SendMesssageXToServer()
    {
        MessageX mx = new MessageX();
        mx.Message = messageInput.text;
        mx.From = fromInput.text;

        client.Send(MessageX.MsgType, mx);
        
        Debug.Log(string.Format("CLIENT: {0}", mx));
    }

    #endregion
}
