using System;

namespace OnlineOrderingSystem
{
    //  keeps track of where ppl live
    public class Address
    {
        private string streetAddress;
        private string city;
        private string stateProvince;
        private string country;

        public Address(string streetAddress, string city, string stateProvince, string country)
        {
            this.streetAddress = streetAddress;
            this.city = city;
            this.stateProvince = stateProvince;
            this.country = country;
        }

        public string StreetAddress
        {
            get { return streetAddress; }
            set { streetAddress = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string StateProvince
        {
            get { return stateProvince; }
            set { stateProvince = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public bool IsInUSA()
        {
            return country.ToUpper() == "USA" || country.ToUpper() == "UNITED STATES";
        }

        public string GetFullAddress()
        {
            return streetAddress + "\n" + city + ", " + stateProvince + "\n" + country;
        }
    }
}