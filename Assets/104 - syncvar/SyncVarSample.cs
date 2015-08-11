using UnityEngine.Networking;
using UnityEngine;

public class SyncVarSample : NetworkBehaviour
{
    [SyncVar]
    string State = "Init State";

    private void ChangeState()
    {
        
        State = Random.Range(0, int.MaxValue).ToString();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 20, 120, 24), State);
        
        // 因为 UNet 是以 Server 为主导的系统，只有在 Server 端改变值才能起作用
        //
        if (isServer)
        {
            if (GUI.Button(new Rect(10, 56, 160, 24), "ChangeState"))
            {
                ChangeState();
            }
        }
    }
}
