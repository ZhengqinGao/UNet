using UnityEngine.Networking;
using UnityEngine;

public class SyncVarSample : NetworkBehaviour
{

    [SyncVar]
    string State;

    void Start()
    {
		Init();
    }

    private void Init()
    {
        State = "Init State";
    }

	private void ChangeState()
	{
		State = "State Changed";
	}

	void OnGUI()
	{
		GUI.Label(new Rect(10, 20, 120, 24), State);
		
		if(isServer)
		{
			if(GUI.Button(new Rect(10, 56, 160, 24), "ChangeState"))
			{
				ChangeState();
			}
		}
	}
}
