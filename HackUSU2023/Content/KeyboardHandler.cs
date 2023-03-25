using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackUSU2023.Content
{
    public class KeyboardHandler
    {
        public delegate void KeyAction(GameTime gameTime);

        public TimeSpan elapsed;
        public TimeSpan threshold = new TimeSpan(0, 0, 0, 0, 100);

        public List<KeyEntry> suppressed;

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
            suppressed = new List<KeyEntry>();
            elapsed = TimeSpan.Zero;
        }

        public void addEntry(KeyEntry e)
        {
            entries.Add(e);
        }

        public void update(GameTime gameTime)
        {
            elapsed += gameTime.ElapsedGameTime;
            if (elapsed < threshold)
            {
                elapsed -= threshold;
                List<KeyEntry> doneBeingSuppressed = new List<KeyEntry>();
                foreach (KeyEntry e in suppressed)
                {
                    var state = Keyboard.GetState().IsKeyUp(e.key);
                    if (state)
                    {
                        e.action(gameTime);
                        if (e.pressOnly)
                        {
                            entries.Add(e);
                            doneBeingSuppressed.Add(e);
                        }
                    }
                }
                foreach (KeyEntry keyEntry in doneBeingSuppressed)
                {
                    suppressed.Remove(keyEntry);
                }
                foreach (KeyEntry e in entries)
                {
                    var state = Keyboard.GetState().IsKeyDown(e.key);
                    if (state)
                    {
                        e.action(gameTime);
                        if (e.pressOnly)
                        {
                            suppressed.Add(e);
                        }
                    }
                }
                foreach (KeyEntry entry in suppressed)
                {
                    if (entries.Contains(entry))
                    {
                        entries.Remove(entry);
                    }
                }
            }
            
        }
    }
}
