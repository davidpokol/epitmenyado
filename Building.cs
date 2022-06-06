using System.Collections.Generic;

namespace epitmenyado
{
    class Building
    {
        private int taxNumber;
        private string street;
        private string houseNumber;
        private char taxBand;
        private int floorSpace;

        public Building()
        {
        }
        public Building(string street, char taxBand)
        {
            this.street = street;
            this.taxBand = taxBand;
        }

        public void setTaxNumber(int taxNumber)
        {
            this.taxNumber = taxNumber;
        }
        public void setStreet(string street)
        {
            this.street = street;
        }
        public void setHouseNumber(string houseNumber)
        {
            this.houseNumber = houseNumber;
        }
        public void setTaxBand(char taxBand)
        {
            this.taxBand = taxBand;
        }
        public void setFloorSpace(int floorSpace)
        {
            this.floorSpace = floorSpace;
        }

        //-----------------

        public int getTaxNumber()
        {
            return taxNumber;
        }
        public string getStreet()
        {
            return street;
        }
        public string getHouseNumber()
        {
            return houseNumber;
        }
        public char getTaxBand()
        {
            return taxBand;
        }
        public int getFloorSpace()
        {
            return floorSpace;
        }

        public override bool Equals(object obj)
        {
            return obj is Building building &&
                   taxNumber == building.taxNumber &&
                   street == building.street &&
                   houseNumber == building.houseNumber &&
                   taxBand == building.taxBand &&
                   floorSpace == building.floorSpace;
        }

        public override int GetHashCode()
        {
            int hashCode = -46268123;
            hashCode = hashCode * -1521134295 + taxNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(street);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(houseNumber);
            hashCode = hashCode * -1521134295 + taxBand.GetHashCode();
            hashCode = hashCode * -1521134295 + floorSpace.GetHashCode();
            return hashCode;
        }
    }

}
