using UnityEngine;
using UnityEngine.Networking;

public class RpcSample : NetworkBehaviour {

    string State = "Init State";

    private void ChangeState()
    {
        State = Random.Range(0, int.MaxValue).ToString();
    }
    
	[ClientRpc]
	private void RpcChangeState() 
	{
		ChangeState();
	}
	
    void OnGUI()
    {
        GUI.Label(new Rect(10, 20, 120, 24), State);
        
        if (isServer)
        {
            if (GUI.Button(new Rect(10, 56, 160, 24), "ChangeState"))
            {
                RpcChangeState();
            }
        }
    }
}
