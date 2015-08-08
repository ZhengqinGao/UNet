using UnityEngine;
using UnityEngine.Networking;

public class ComBaseOnNetworkManager : MonoBehaviour {

	private NetworkClient client;

	private float interval = 5f;
	private float time = 0f;
	
	void Start () {
		SetupServer();
		SetupClient();
	}
	
	void Update()
	{
		time += Time.deltaTime;
		if(time >= interval)
		{
			time = time - interval;
			SendMessageToServer();
		}
	}
	
	private void SetupServer()
	{
		if(NetworkServer.active)
		{
			return;
		}
		
		NetworkServer.RegisterHandler(MessageX.MsgType, OnMessageReceived);
		
		NetworkManager.singleton.StartServer();
	}
	
	private void SetupClient()
	{
		client = NetworkManager.singleton.StartClient();
	}
	
	private void OnMessageReceived(NetworkMessage msg)
	{
		Debug.Log(string.Format("SERVER: {0}", msg.ReadMessage<MessageX>()));
	}
	
	private void SendMessageToServer()
	{
		MessageX mx = new MessageX();
		mx.From = "NetworkMangerBase Sample";
		mx.Message = "Hello Rocky!";
		
		client.Send(MessageX.MsgType, mx);
	}
}
