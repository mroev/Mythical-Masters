using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mythical_masters
{
    internal class Hero
    {
        public string Name { get; }
        public int Stärke { get; }
        public int Intelligenz { get; }
        public int Geschick { get; }

        public Hero(string name, int stärke, int intelligenz, int geschick)
        {
            Name = name;
            Stärke = stärke;
            Intelligenz = intelligenz;
            Geschick = geschick;
        }

        public override string ToString()
        {
            return "Name: " + Name + ", Stärke: " + Stärke + ", Intelligenz: " + Intelligenz + ", Geschick: " + Geschick;
        }
    }

    internal class Mert : Hero
    {
        public int schmal { get; }

        public Mert(string name, int stärke, int intelligenz, int geschick, int mertigkeit)
            : base(name, stärke, intelligenz, geschick)
        {
            schmal = schmal;
        }

        public override string ToString()
        {
            return base.ToString() + $", Breite: {schmal}";
        }
    }

    internal class Krieger : Hero
    {
        public int Rüstung { get; }

        public Krieger(string name, int stärke, int intelligenz, int geschick, int rüstung)
            : base(name, stärke, intelligenz, geschick)
        {
            Rüstung = rüstung;
        }

        public override string ToString()
        {
            return base.ToString() + $", Rüstung: {Rüstung}";
        }
    }

    internal class Magier : Hero
    {
        public int Mana { get; }

        public Magier(string name, int stärke, int intelligenz, int geschick, int mana)
            : base(name, stärke, intelligenz, geschick)
        {
            Mana = mana;
        }

        public override string ToString()
        {
            return base.ToString() + $", Mana: {Mana}";
        }
    }

    internal class Schurke : Hero
    {
        public int Böse { get; }

        public Schurke(string name, int stärke, int intelligenz, int geschick, int böse)
            : base(name, stärke, intelligenz, geschick)
        {
            Böse = böse;
        }

        public override string ToString()
        {
            return base.ToString() + $", Böse: {Böse}";
        }
    }
}