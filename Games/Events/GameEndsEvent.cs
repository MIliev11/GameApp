using System;
using Games.Model.ButtonsGame;
using Prism.Events;

namespace Games.Events
{
    public class GameEndsEvent : PubSubEvent
    {
        public GameEndsEvent()
        {
        }
    }
}
