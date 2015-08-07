using UnityEngine.Networking;

// Customize message and Type
//
public class MessageX : MessageBase
{
    public static readonly short MsgType = short.MaxValue;

    public string Message { get; set; }
    public string From { get; set; }

    public override string ToString()
    {
        return string.Format("Message '{0}' from '{1}'", Message, From);
    }
}
