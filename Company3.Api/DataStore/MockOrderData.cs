using Company3.Api.Model;

namespace Company3.Api.DataStore
{
    public class MockOrderData
    {
        private readonly List<Order> OrderDetails = new()
        {
            new()
            {
                Source = "Optimus Source Address1",
                Destination = "Optimus Destination Address1",
                Packages = new List<Package>
                {
                    new Package
                    {
                        Length = 10,
                        Width = 10,
                        Height = 10,
                    },
                    new Package
                    {
                        Length = 10,
                        Width = 10,
                        Height = 10,
                    }
                },
                Quote = 523f
            },
            new()
            {
                Source = "Optimus Source Address2",
                Destination = "Optimus Destination Address2",
                Packages = new List<Package>
                {
                    new Package
                    {
                        Length = 20,
                        Width = 20,
                        Height = 20,
                    },
                    new Package
                    {
                        Length = 20,
                        Width = 20,
                        Height = 20,
                    }
                },
                Quote = 12000f
            },
            new()
            {
                Source = "Optimus Source Address3",
                Destination = "Optimus Destination Address3",
                Packages = new List<Package>
                {
                    new Package
                    {
                        Length = 30,
                        Width = 30,
                        Height = 30,
                    },
                    new Package
                    {
                        Length = 30,
                        Width = 30,
                        Height = 30,
                    }
                },
                Quote = 11000f
            }
        };

        public List<Order> GetOrderDetails()
        {
            return OrderDetails;
        }
    }
}