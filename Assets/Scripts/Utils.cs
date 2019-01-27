using System;
using UnityEngine;

namespace GrassGame
{
    public static class Utils
    {
        public static Position GetPosition()
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            return new Position((int)Math.Round(worldPoint.x), (int)Math.Round(worldPoint.y));
        }
    }
}
