using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace NasaProblemCase
{
    internal class Rover
    {
        public int KonumX { get; set; }
        public int KonumY { get; set; }
        public Yon Yon { get; set; }

        public Rover(int konumX, int konumY, char yon)
        {
            this.KonumX = konumX;
            this.KonumY = konumY;
            switch (yon)
            {
                case 'N':
                    this.Yon = Yon.North; break;
                case 'E':
                    this.Yon = Yon.East; break;
                case 'S':
                    this.Yon = Yon.South; break;
                case 'W':
                    this.Yon = Yon.West; break;
            }
        }

        public void RKomut()
        {
            this.Yon++;
            if ((int)this.Yon == 4)
                this.Yon = Yon.North;
        }

        public void LKomut()
        {
            this.Yon--;
            if ((int)this.Yon == -1)
                this.Yon = Yon.West;
        }

        public void MKomut()
        {
            switch (this.Yon)
            {
                case Yon.North:
                    this.KonumY++;
                    break;
                case Yon.West:
                    this.KonumX--;
                    break;
                case Yon.East:
                    this.KonumX++;
                    break;
                case Yon.South:
                    this.KonumY--;
                    break;
            }
        }

        public void HareketEttir(char[] hareketKomutlari)
        {
            foreach (char x in hareketKomutlari)
            {
                switch (x)
                {
                    case 'L':
                        this.LKomut();
                        break;
                    case 'R':
                        this.RKomut();
                        break;
                    case 'M':
                        this.MKomut();
                        break;
                }
            }
        }
    }
}
