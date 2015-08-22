using UnityEngine;
using UnityEngine.Networking;

public class CommandSample : NetworkBehaviour {

	[SyncVar]
    string State = "Init State";

    private void ChangeState()
    {
        State = Random.Range(0, int.MaxValue).ToString();
    }
    
    [Command]
    private void CmdChangeState()
    {
        ChangeState();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 20, 120, 24), State);
        
        if (!isServer)
        {
            if (GUI.Button(new Rect(10, 56, 160, 24), "ChangeState"))
            {
                //  ChangeState();
                CmdChangeState();
            }
        }
    }
}
