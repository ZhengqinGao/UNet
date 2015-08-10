using UnityEngine;
using UnityEngine.Networking;

public class SimpleNetworkGUI : MonoBehaviour
{
	bool isHaveNetworkRole = false;
	
	void Start()
	{
		isHaveNetworkRole = false;
	}
	
    void OnGUI()
    {
		if(isHaveNetworkRole)
		{
			return;
		}
		
		if(GUI.Button(new Rect(Screen.width / 2f - 80, Screen.height / 2 - 12, 160, 24), "Start Host"))
		{
			NetworkManager.singleton.StartHost();
			isHaveNetworkRole = true;
		}
		
		if(GUI.Button(new Rect(Screen.width / 2f - 80, Screen.height / 2 + 24, 160, 24), "Start Client"))
		{
			NetworkManager.singleton.StartClient();
			isHaveNetworkRole = true;
		}
		
	}
}
