using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{

    // Class Declaration
    class Cars
    {

        // Instance Variables
        public string carBrand;
        public string model;
        public string color;
        public string transmission;
        public string engine;
        public int year;
        public int distanceKm;
        public int salesPrice;
        public int purchasePrice;
        public int result;
        public bool forSale;

        // Constructor Declaration of Class
        public Cars(string CarBrand, string Model, string Color, string Transmission, string Engine, int Year, int DistanceKm, int SalesPrice, int PurchasePrice, int Result, bool ForSale)
        {
            carBrand = CarBrand;
            model = Model;
            color = Color;
            transmission = Transmission;
            engine= Engine;
            year = Year;
            distanceKm = DistanceKm;
            salesPrice = SalesPrice;
            purchasePrice = PurchasePrice;
            result = Result;
            forSale = ForSale;
        }
    }
}
