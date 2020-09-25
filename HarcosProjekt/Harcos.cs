﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HarcosProjekt
{
    class Harcos
    {
        private string nev;
        private int szint;
        private int tapasztalat;
        private int eletero;
        private int alapEletero;
        private int alapSebzes;

        public Harcos(string nev, int statuszSablon)
        {
            this.nev = nev;
            this.szint = 1;
            this.tapasztalat = 0;
            if (statuszSablon == 3)
            {
                this.alapEletero = 8;
                this.alapSebzes = 5;
            }
            else if (statuszSablon == 2)
            {
                this.alapEletero = 12;
                this.alapSebzes = 4;
            }
            else
            {
                this.alapEletero = 15;
                this.alapSebzes = 3;
            }
            this.alapEletero = MaxEletero;
        }

        public string Nev { get => nev; set => nev = value; }
        public int Szint { get => szint; set => szint = value; }
        public int Tapasztalat { get => tapasztalat; set => tapasztalat = value; }
        public int Eletero { get => eletero; set => eletero = value; }
        public int Sebzes { get => alapSebzes + szint; }
        public int Szintlepeshez { get => 10 + szint * 5; }
        public int MaxEletero { get => alapEletero + szint * 3; }
        public void Megkuzd(Harcos masikHarcos) {
            if (this == masikHarcos)
            {
                Console.WriteLine("A két harcos azonos");
            }

            if (this.Eletero == 0 || masikHarcos.Eletero == 0)
            {
                Console.WriteLine("A Harcos életereje 0");
            }
            else
            {
                masikHarcos.Eletero -= this.Sebzes;
                if (masikHarcos.Eletero>0){ this.Eletero -= masikHarcos.Sebzes; }
                masikHarcos.Tapasztalat += masikHarcos.Eletero == 0 ? 0 : (this.Eletero == 0) ? 15 : 10;
                this.Tapasztalat += this.Eletero == 0 ? 0 : (masikHarcos.Eletero == 0) ? 15 : 10;

            }
        }
        //public void Gyogyul() {}
        public override string ToString()
        {
            return String.Format("{0} – LVL:{1} – EXP: {2}/{3} – HP:{4}/{5} – DMG: {6}",
                this.nev, this.szint, this.tapasztalat, Szintlepeshez, this.alapEletero, MaxEletero, Sebzes);
        }

    }
}
