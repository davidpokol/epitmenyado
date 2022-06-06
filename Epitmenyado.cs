using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epitmenyado
{
    class Epitmenyado
    {
        static void Main(string[] args)
        {

            #region 1. feladat
            const string FILENAME = "utca.txt";
            FileUtil fileUtil = new FileUtil();
            List<Building> buildings = fileUtil.readBuildings(FILENAME);
            #endregion

            #region 2. feladat
            Service service = new Service(buildings);
            Console.WriteLine("2. feladat. A mintában {0} telek szerepel.",  buildings.Count());
            #endregion

            #region 3 .feladat
            Console.Write("3. feladat. Egy tulajdonos adószáma: ");
            int userTaxNumber = int.Parse(Console.ReadLine());
            service.writeOutBuildingsByTaxNumber(userTaxNumber);
            #endregion

            #region 5. feladat 
            Console.WriteLine("5. feladat");
            service.findBands();
            #endregion


            #region 6. feladat 
            Console.WriteLine("6. feladat. A több sávba sorolt utcák:");
            service.streetReview();
            #endregion

            #region 7. feladat
            service.taxToFile("fizetendo.txt");
            #endregion

            Console.ReadKey();
        }     
    }
}
