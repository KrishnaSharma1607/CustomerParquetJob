namespace Project_1.Models  //tells C# this class belongs to "Models"
{
    public class Customer  //Create a publicly accessible blueprint called Customer.
    {
        public int CustomerId { get; set; } // set stores the values inside the object, while get retrieves them when needed.

        private string customerName;

        public string CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
            }
        }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string LoanStatus { get; set; }

        public int CallsToday { get; set; }

        public DateTime LastCallDate { get; set; }
    }
}