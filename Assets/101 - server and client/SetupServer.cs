using UnityEngine;
using UnityEngine.Networking;

public class SetupServer : MonoBehaviour
{
    public int listenPort = 4444;

    void Start()
    {
        ServerSetup();
    }

    private void ServerSetup()
    {
        NetworkServer.Listen(listenPort);
        NetworkServer.RegisterHandler(MsgType.Connect, OnConnection);
    }
    
    private void OnConnection(NetworkMessage msg)
    {
        Debug.Log("Server: connection happen");
    }
}
