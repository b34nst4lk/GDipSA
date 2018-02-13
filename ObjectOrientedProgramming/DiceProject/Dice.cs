using System;

namespace DiceProject
{
    class Dice
    {
        int faceUp;
        int noOfFaces;
        Random r = new Random();

        public Dice() // Default 6 sided dice
        {
            noOfFaces = 6;
            Throw();
        }

        public Dice(int faces) // Default 6 sided dice
        {
            noOfFaces = faces;
            Throw();
        }

        public int GetNoOfFaces()
        {
            return noOfFaces;
        }

        public int GetFace()
        {
            return faceUp;
        }

        public void Throw()
        {
            faceUp = r.Next(1, noOfFaces + 1);
        }


    }
}
