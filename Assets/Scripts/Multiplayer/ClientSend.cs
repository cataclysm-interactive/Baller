using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ClientSend : MonoBehaviour
{
    /// <summary>Sends a packet to the server via TCP.</summary>
    /// <param name="_packet">The packet to send to the sever.</param>
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    /// <summary>Sends a packet to the server via UDP.</summary>
    /// <param name="_packet">The packet to send to the sever.</param>
    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    #region Packets
    /// <summary>Lets the server know that the welcome message was received.</summary>
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(PlayerPrefs.GetString("Username"));

            SendTCPData(_packet);
        }
    }

    public static void Matchmake(int betAmount)
    {
        using(Packet packet = new Packet ((int)ClientPackets.findMatch))
        {
            packet.Write(Client.instance.myId);
            packet.Write(betAmount);
            SendTCPData(packet);
        }
    }

    public static void FinishedMatch(int score, int match)
    {
        using (Packet packet = new Packet((int) ClientPackets.gameFinished))
        {
            packet.Write(score);
            packet.Write(match);
            SendTCPData(packet);
        }
    }

    #endregion
}
