using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKat
{
    public class GUIAssistant
    {
        private int currentLine = 0;

        public Rect originalRect;
        public int lines = 1;

        public float lineHeight = 16f;
        public float fillerPadding = 2;
        public float endPadding = 0;

        public GUIAssistant(Rect _rect, int _lines)
        {
            originalRect = _rect;
            lines = _lines;
        }

        public Rect GetRect()
        {
            Rect newPositionRect = originalRect;
            newPositionRect.size = new Vector2(newPositionRect.size.x, lineHeight);
            newPositionRect.position = newPositionRect.position + new Vector2(0, currentLine * (lineHeight + fillerPadding));

            return newPositionRect;
        }

        public Rect GetRect(float startRef, float endRef)
        {
            startRef = Mathf.Clamp01(startRef);
            endRef = Mathf.Clamp01(endRef);

            Rect newPositionRect = originalRect;

            newPositionRect.size = new Vector2(originalRect.size.x * (endRef - startRef), lineHeight);
            newPositionRect.position = originalRect.position + new Vector2(startRef * originalRect.size.x, currentLine * (lineHeight + fillerPadding));

            return newPositionRect;
        }

        public int NextLine()
        {
            currentLine++;
            return currentLine;
        }

        public int NextLine(int amount)
        {
            currentLine += amount;
            return currentLine;
        }
        public int PreviousLine()
        {
            currentLine--;
            return currentLine;
        }
        public int PreviousLine(int amount)
        {
            currentLine -= amount;
            return currentLine;
        }

        public float GetPropertyHeight()
        {
            return (lines * lineHeight) + ((lines - 1) * fillerPadding) + endPadding;                   // 16 Pixels per line + the default text field padding per line + end Padding;
        }
    }
}