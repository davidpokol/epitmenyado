using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epitmenyado
{
    class Service
    {
        FileUtil fileUtil = new FileUtil();
        List<Building> buildings = new List<Building>();

        public Service(List<Building> buildings)
        {
            this.buildings = buildings;
        }

        public void writeOutBuildingsByTaxNumber(int taxNumber)
        {
            bool isFound = false;
            foreach (Building b in buildings)
            {
                if (b.getTaxNumber() == taxNumber)
                {
                    isFound = true;
                    Console.WriteLine(b.getStreet() + " utca " + b.getHouseNumber());
                }

            }
            if (!isFound)
            {
                Console.WriteLine("Nem szerepel az adatállományban.");
            }
        }
        #region 5. feladat
        public void findBands()
        {
            int bandCount;
            int taxSum;
            for (int i = 65; i <= 65; i++)
            {
                bandCount = 0;
                taxSum = 0;
                foreach (Building b in buildings)
                {
                    if (b.getTaxBand() == (char) i)
                    {
                        bandCount++;
                        taxSum += ado(b.getTaxBand(), b.getFloorSpace());
                    }

                }
                Console.WriteLine("{0} sávba {1} telek esik, az adó {2} Ft.",(char) i, bandCount, taxSum);
            }
        }
        #endregion
        #region 4. feladat
        private int ado(char taxband, int floorSpace)
        {
            int amount = 0;
            switch (taxband)
            {
                case 'A':
                    amount = 800 * floorSpace;
                    break;

                case 'B':
                    amount = 600 * floorSpace;
                    break;

                case 'C':
                    amount = 100 * floorSpace;
                    break;
            }
            return amount >= 10000 ? amount : 0;
        }
        #endregion 
        public void streetReview()
        {
            HashSet<String> street = getBuildingStreets();
            HashSet<Building> buildings = getBuildingSet();

            int times;
            foreach(String s in street)
            {
                times = 0;
                foreach (Building b in buildings)
                {
                    if (s == b.getStreet())
                    {
                        times++;

                    }
                }
                if(times > 1 )
                {
                    Console.WriteLine(s);
                }
                times = 0;

                
            }
        }
        private HashSet<String> getBuildingStreets()
        {
            HashSet<String> buildingsSet = new HashSet<String>();
            foreach (Building b in buildings)
            {
                buildingsSet.Add(b.getStreet());
            }
            return buildingsSet;
        }

        private HashSet<Building> getBuildingSet()
        {
            HashSet<Building> buildingsSet = new HashSet<Building>();
            foreach (Building b in buildings)
            {
                buildingsSet.Add(new Building(b.getStreet(),b.getTaxBand()));
            }
            return buildingsSet;
        }

        private HashSet<int> getTaxNumbers()
        {
            HashSet<int> buildingsSet = new HashSet<int>();
            foreach (Building b in buildings)
            {
                buildingsSet.Add(b.getTaxNumber());
            }
            return buildingsSet;
        }

        public void taxToFile(string filename)
        {
            List<KeyValuePair<int, int>> kvList = new List<KeyValuePair<int, int>>();
            int sum;
            foreach(int b in getTaxNumbers())
            {
                sum = 0;
                foreach(Building bs in buildings)
                {
                    if(b == bs.getTaxNumber())
                    {
                        sum += ado(bs.getTaxBand(), bs.getFloorSpace());
                    }
                }
                kvList.Add(new KeyValuePair<int, int> (b, sum)); 
            }
            fileUtil.writeToFile(kvList, filename);
        }
    }
}
