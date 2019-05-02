using UnityEngine;
using UnityEditor;
using SocketIO;
using System;
using Commons;
using Player;

namespace MultiplayerSystem
{
    public class MultiplayerManager : SocketIOComponent
    {
        public event Action<PlayerData> OnPlayerConnected;
        public event Action<PlayerData> OnPlayerJoined;
        PlayerManager playerManager;
        public override void Start()
        {
            base.Start();
            playerManager = ManagerLocator.Instance.GetPlayerManager();
            On("onConnected", OnConnected);
            On("onUserRegister", OnRegister);
            On("onJoinGame", PlayerJoined);
        }
        private void OnConnected(SocketIOEvent socketEvent)
        {

        }
        private void OnRegister(SocketIOEvent socketEvent)
        {
            PlayerData playerData = new PlayerData();
            Debug.Log("OnRegister " + socketEvent.data.ToString());
            socketEvent.data.GetField(ref playerData.playerID, "playerID");
            socketEvent.data.GetField(ref playerData.playerName, "playerName");
            OnPlayerConnected.Invoke(playerData);
            JoinRoom();
        }
        private void PlayerJoined(SocketIOEvent socketEvent)
        {
            Debug.Log("player joined game"+socketEvent.data.ToString());
            PlayerData playerData = new PlayerData();
            socketEvent.data.GetField(ref playerData.playerID, "playerID");
            socketEvent.data.GetField(ref playerData.spawnPoint, "playerSpawn");
            OnPlayerJoined.Invoke(playerData);
        }
        public void JoinGame(string name)
        {
            JSONObject dataToSend = new JSONObject();
            dataToSend.AddField("playerName", name);
            Emit("registerUser", dataToSend);
        }
        public void JoinRoom()
        {
            Emit("joinRoom");
        }
    }
}