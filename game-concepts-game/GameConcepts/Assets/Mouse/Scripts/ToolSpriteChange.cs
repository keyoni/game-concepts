using System;
using UnityEngine;
using UnityEngine.UI;

namespace Mouse
{
    public class ToolSpriteChange : MonoBehaviour
    {
        public Texture2D cursorDefault;
        public Texture2D cursorTexture;
        
        public Vector2 hotSpot = Vector2.zero;
        public CursorMode cursorMode = CursorMode.ForceSoftware;
        
        void Start()
        {
            Cursor.SetCursor(null ,hotSpot,cursorMode);
            cursorTexture = GetComponent<SpriteRenderer>().sprite.texture;
           
        }
        private void OnMouseUp()
        {
                
            Cursor.SetCursor(cursorTexture,hotSpot,cursorMode);
        }

        // private void OnMouseExit()
        // {
        //     Cursor.SetCursor(null, Vector2.zero, cursorMode);
        // }
    }
}
