﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class NetworkGamePlayer : NetworkBehaviour
{
    [SyncVar]
    private string displayName = "Loading...";

    private NetworkManagerLobby room;
    private NetworkManagerLobby Room
    {
        get
        {
            if( room != null)
            {
                return room;
            }
            room = NetworkManager.singleton as NetworkManagerLobby;
            return room;
        }
    }

    public override void OnStartClient()
    {
        DontDestroyOnLoad(gameObject);
        if (!GameMode.hosting)
        {
            Room.GamePlayers.Add(this);
        }        
    }

    public override void OnStopClient()
    {
        if (!GameMode.hosting)
        {
            Room.GamePlayers.Remove(this);
        }        
    }

    [Server]
    public void SetDisplayName(string displayName)
    {
        this.displayName = displayName;
    }

}
