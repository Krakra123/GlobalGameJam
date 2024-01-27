using System.Collections.Generic;

public class ChatEventList 
{
    public Dictionary<string, EventKey> ChatEventKey = new Dictionary<string, EventKey>();

    public ChatEventList()
    {
        ChatEventKey.Add("none", EventKey.None);
        
    }
}
