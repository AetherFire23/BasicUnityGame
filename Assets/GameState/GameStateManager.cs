using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.PackageManager;
using Zenject;

namespace Assets.GameState
{
    public class GameStateManager : IInitializable
    {
        public Guid PlayerUID { get; set; } // inited through IInitializable

        [Inject] private PlayerOptions _playerOptions;
        private readonly GlobalTick _globalTick;
        private readonly ClientCalls _client;
        private GameState _gameState;

        public GameStateManager(ClientCalls clientCalls, GlobalTick globalTick)
        {
            _globalTick = globalTick;
            _client = clientCalls;
        }

        public void Initialize()
        {
            this.PlayerUID = new Guid(_playerOptions.PlayerGuid);
            if (String.IsNullOrEmpty(this.PlayerUID.ToString()))
            {
                throw new Exception("PlayerUID must be set");
            }
            _client.Initialize(PlayerUID);
        }

        private void RefreshGameState()
        {
            DateTime? timeStamp = _gameState == null ? null : _gameState.TimeStamp;
            _gameState = _client.GetGameState(this.PlayerUID, timeStamp).AsTask().Result;
        }

        private void OnTimerTick(object source, EventArgs e)
        {
            RefreshGameState();
            _globalTick.SubscribedMembers.Add(this.GetType().Name);
        }
    }
}
