using System;

namespace Player
{
    public interface IPlayer
    {
        event Action<float> OnHealthUpdated;
    }
}