using UnityEngine;
using UnityEngine.Networking;

public class SimpleNetworkGUI : MonoBehaviour
{
	bool isHaveNetworkRole = false;
	
	void Start()
	{
		isHaveNetworkRole = false;
	}
	
	private void OnDisconnected(NetworkMessage msg)
	{
		isHaveNetworkRole = false;
		Application.LoadLevel(Application.loadedLevel);
	}
	
    void OnGUI()
    {
		if(isHaveNetworkRole)
		{
			if(GUI.Button(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 12, 160, 24), "Stop"))
			{
				NetworkManager.singleton.StopServer();
				NetworkManager.singleton.StopClient();
				OnDisconnected(null);
			}
			return;
		}
		
		if(GUI.Button(new Rect(Screen.width / 2f - 80, Screen.height / 2 - 12, 160, 24), "Start Server"))
		{
			isHaveNetworkRole = NetworkManager.singleton.StartServer();
		}
		
		if(GUI.Button(new Rect(Screen.width / 2f - 80, Screen.height / 2 + 24, 160, 24), "Start Client"))
		{
			var client = NetworkManager.singleton.StartClient();
			client.RegisterHandler(MsgType.Disconnect, OnDisconnected);
			isHaveNetworkRole = true;
		}
	}
}
