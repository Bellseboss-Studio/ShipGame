using System;

namespace Player
{
    public interface IPlayerMovment
    {
        
        event Action<float> OnPlayerMove;
    }
}