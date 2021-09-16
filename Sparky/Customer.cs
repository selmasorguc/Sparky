﻿namespace Sparky
{
    using System;

    public class Customer
    {
        public string GreetMessage { get; set; }

        public int Discount = 15;

        public int OrderTotal { get; set; }

        public string GreetAndCombineNames(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Empty first name");
            }

            GreetMessage = $"Hello, {firstName} {lastName}";
            Discount = 20;
            return GreetMessage;
        }

        public CustomerType GetCustomerDetails()
        {
            if (OrderTotal < 100) return new BasicCustomer();

            return new PlatinumCustomer();
         }
}

    public class CustomerType
    {
    }

    public class BasicCustomer : CustomerType
    {
    }

    public class PlatinumCustomer : CustomerType
    {
    }
}
