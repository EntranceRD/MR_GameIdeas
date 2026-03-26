using Entrance.Games;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public interface IGameManager
    {
        void StartGame();
        void EndGame();
        void Restart();
    }
}