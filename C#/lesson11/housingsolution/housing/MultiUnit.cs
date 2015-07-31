using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HousingNamespace;
using IUnitNamespace;

namespace MultiUnitNamespace
{
    public class MultiUnit : PropretyManager,IUnit 
    {
        int number;
        string typeOfHouse;
        
        public MultiUnit()
        {
        }
        public MultiUnit(int num, string tpOfHouse, string address, int yearBuilt)
            : base(address, yearBuilt)
        {
            number = num;
            typeOfHouse = tpOfHouse;
        }
        public int getNumbersofUnit()
        {
            return 3;
        }
        public string Print()
        {
            string print = base.Print() + "\nHouse NUmber:" + number + "\nType of House:" + typeOfHouse;
            return print;
        }


    }
}
