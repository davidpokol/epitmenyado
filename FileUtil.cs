using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace epitmenyado
{
    class FileUtil
    {
        public FileUtil()
        {

        }

        public List<Building> readBuildings(string filename)
        {
            string[] data = File.ReadAllLines(filename, Encoding.Default);

            List<Building> buildings = new List<Building>();

            for (int i = 1; i < data.Length; i++)
            {
                string[] split = data[i].Split(' ');
                Building building = new Building();

                building.setTaxNumber(int.Parse(split[0]));
                building.setStreet(split[1]);
                building.setHouseNumber(split[2]);
                building.setTaxBand(char.Parse(split[3]));
                building.setFloorSpace(int.Parse(split[4]));

                buildings.Add(building);
            }
            return buildings;
        }

        public void writeToFile(List<KeyValuePair<int, int >> list, string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            KeyValuePair<int, int> firstElement = list.ToList()[0];
            sw.Write(firstElement.Key + " " + firstElement.Value);
            foreach(var l in list.GetRange(1,list.Count-1))
            {
                sw.WriteLine();
                sw.Write(l.Key + " " + l.Value);
            }
            sw.Close();
        }
    }
}
