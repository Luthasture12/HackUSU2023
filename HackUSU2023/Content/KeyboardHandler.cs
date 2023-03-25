using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackUSU2023.Content
{
    internal class KeyboardHandler
    {
        public delegate void KeyAction(GameTime gameTime);

        public List<KeyEntry> entries;
        public class KeyEntry
        {
            public Keys key;
            public KeyAction action;
            public bool pressOnly;

            public KeyEntry(Keys key, KeyAction action, bool pressOnly)
            {
                this.key = key;
                this.action = action;
                this.pressOnly = pressOnly;
            }


        }

        public KeyboardHandler()
        {
            entries = new List<KeyEntry>();
        }

        public void addEntry(KeyEntry e)
        {
            entries.Add(e);
        }

        public void update(GameTime gameTime)
        {
            foreach (KeyEntry e in entries)
            {
                var state = Keyboard.GetState().IsKeyDown(e.key);
                if (state)
                {
                    e.action(gameTime);
                }
            }
        }
    }
}
