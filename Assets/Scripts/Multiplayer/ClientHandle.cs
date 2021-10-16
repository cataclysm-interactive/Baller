using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.LogWarning($"Message from server: {_msg}");
        Client.instance.myId = _myId;
        UIManager.instance.HideLoadingScreen();
        ClientSend.WelcomeReceived();

        // Now that we have the client's id, connect UDP
        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void StartMatch(Packet packet)
    {
        int match = packet.ReadInt();
        int amount = packet.ReadInt();

        if(match == 0)
        {
            Debug.LogWarning("No match made. No other users online");
            MultiplayerManager.instance.NoMatch();
        }

        if(match > 0)
        {
            MultiplayerManager.instance.MatchFound(match);
        }
    }

}
