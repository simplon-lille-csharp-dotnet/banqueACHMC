using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class Client
    {
        public string LastName
        {
            get => default;
            set
            {
            }
        }

        public string FirstName
        {
            get => default;
            set
            {
            }
        }

        public string NumClient
        {
            get => default;
            set
            {
            }
        }

        List<ITransactionnel> transactionList = new List<ITransactionnel>();
    }
}