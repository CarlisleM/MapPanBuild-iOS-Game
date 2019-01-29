﻿using System;
using UnityEngine;

namespace GrassGame
{
    public static class Utils
    {
        public static Position GetMousePosition()
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            return new Position((int)Math.Round(worldPoint.x), (int)Math.Round(worldPoint.y));
        }

        public static Position GetTemplatePosition()
        {
            Vector2 templatePos = GameObject.Find(TemplateScript.currentlySelectedObject + "(Clone)").transform.position;

            Debug.Log("xTemplatePos: " + templatePos.x + " yTemplatePos: " + templatePos.y);

            return new Position((int)templatePos.x, templatePos.y);
        }
    }
}
