using Company1.Api.Model;

namespace Company1.Api.DataStore
{
    public class MockOrderData
    {
        private readonly List<Order> OrderDetails = new()
        {
            new()
            {
                ContactAddress = "Optimus Source Address1",
                WarehouseAddress = "Optimus Destination Address1",
                PackageDimensions = new List<Dimensions>
                {
                    new Dimensions
                    {
                        Length = 10,
                        Width = 10,
                        Height = 10,
                    },
                    new Dimensions
                    {
                        Length = 10,
                        Width = 10,
                        Height = 10,
                    }
                },
                Total = 1000.50f
            },
            new()
            {
                ContactAddress = "Optimus Source Address2",
                WarehouseAddress = "Optimus Destination Address2",
                PackageDimensions = new List<Dimensions>
                {
                    new Dimensions
                    {
                        Length = 20,
                        Width = 20,
                        Height = 20,
                    },
                    new Dimensions
                    {
                        Length = 20,
                        Width = 20,
                        Height = 20,
                    }
                },
                Total = 2000.50f
            },
            new()
            {
                ContactAddress = "Optimus Source Address3",
                WarehouseAddress = "Optimus Destination Address3",
                PackageDimensions = new List<Dimensions>
                {
                    new Dimensions
                    {
                        Length = 30,
                        Width = 30,
                        Height = 30,
                    },
                    new Dimensions
                    {
                        Length = 30,
                        Width = 30,
                        Height = 30,
                    }
                },
                Total = 3000.50f
            }
        };

        public List<Order> GetOrderDetails()
        {
            return OrderDetails;
        }
    }
}