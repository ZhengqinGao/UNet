using UnityEngine.Networking;

// Customize message and Type
//
public class MessageX : MessageBase
{
    public static readonly short MsgType = short.MaxValue;
    
    // Use Field here, NOT Property
    //
    public string Message;
    public string From;

    public override string ToString()
    {
        return string.Format("Message '{0}' from '{1}'", Message, From);
    }
}
