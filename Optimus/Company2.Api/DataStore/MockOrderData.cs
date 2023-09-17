using Company2.Api.Model;

namespace Company2.Api.DataStore
{
    public class MockOrderData
    {
        private readonly List<Order> OrderDetails = new()
        {
            new()
            {
                Consignee = "Optimus Source Address1",
                Consignor = "Optimus Destination Address1",
                Cartons = new List<Dimensions>
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
                Amount = 523f
            },
            new()
            {
                Consignee = "Optimus Source Address2",
                Consignor = "Optimus Destination Address2",
                Cartons = new List<Dimensions>
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
                Amount = 6000f
            },
            new()
            {
                Consignee = "Optimus Source Address3",
                Consignor = "Optimus Destination Address3",
                Cartons = new List<Dimensions>
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
                Amount = 7000f
            }
        };

        public List<Order> GetOrderDetails()
        {
            return OrderDetails;
        }
    }
}