using System;

namespace Berek2020
{
    internal class Munkavallalo
    {
        private string munkavallaloNev;
        private bool ferfi;
        private string reszleg;
        private int belepesEv;
        private int ber;

        public Munkavallalo(string adatSor)
        {
            string[] mezok = adatSor.Split(';');
            munkavallaloNev = mezok[0];
            ferfi = mezok[1] == "férfi";
            reszleg = mezok[2];
            belepesEv = int.Parse(mezok[3]);
            ber = int.Parse(mezok[4]);
        }

        public string Nev
        {
            get => munkavallaloNev;
            set => munkavallaloNev = value;
        }

        public bool Neme
        {
            get => ferfi;
            set => ferfi = value;
        }

        public string Reszleg
        {
            get => reszleg;
            set => reszleg = value;
        }

        public int BelepesEv
        {
            get => belepesEv;
            set => belepesEv = value;
        }

        public int Ber
        {
            get => ber;
            set => ber = value;
        }
    }
}