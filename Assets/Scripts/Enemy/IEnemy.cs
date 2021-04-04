using System;
using UnityEngine;

namespace Enemy
{
    public interface IEnemy
    {
        Vector2 Velocity();
        event Action<IEnemyView> OnDied;

        int GetPointValue();
    }
}