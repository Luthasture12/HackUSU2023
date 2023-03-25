using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HackUSU2023
{
    internal class Villager: Entity
    {
        private String[] dialogue;

        public String talk() 
        {
            return dialogue[getRandomDialogue()];
        }

        public int getRandomDialogue()
        {
            Random randomizer = new Random();
            int dialogueChoice = randomizer.Next(dialogue.Length);
            return dialogueChoice;
        }

        public Villager() 
        {
            width = 64;
            height = 64;
            Random randomizer = new Random();
            x = randomizer.Next(MainGame.screenWidth);
            y = randomizer.Next(MainGame.screenHeight);
            // 1,056 w x 2,176 h

        }
    }
}
