﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HackUSU2023
{
    public class Villager : Entity
    {
        private String[] dialogue;

        public String talk() 
        {
            return dialogue[getRandomDialogue()];
        }

        public int getRandomDialogue()
        {
            Random randomizer = new Random();
            return randomizer.Next(dialogue.Length);
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
