using System;
using System.Collections;

namespace NTransactionsProject
{
	public class TransactionsManager
	{
		public List<TransactionPayment> transactionsList = new List<TransactionPayment>();

		public void Start()
		{
			TaskSelect();
		}

		private void TaskSelect()
		{
			Console.WriteLine("Press 1 To Add Payment\nPress 2 To View Payments");

			try
			{
				string taskInput = Console.ReadLine();
				int taskInputNumber = Int32.Parse(taskInput);

				if (taskInputNumber == 1)
				{
					AddPayment();
				}
				else if(taskInputNumber == 2)
				{
					ViewPayments();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Please enter the appropriate input (1 or 2)");
				Start();
			}
		}

		private void AddPayment()
		{
			try
			{
                Console.WriteLine("Please enter the customer's name");
				string customerNameInput = Console.ReadLine();

				Console.WriteLine("What Item was bought?");
				string itemInput = Console.ReadLine();

                Console.WriteLine("What is the Item's price?");
                string itemPriceInput = Console.ReadLine();
                int itemPriceInputNumber = Int32.Parse(itemPriceInput);

                Console.WriteLine("Please select the installment\n1. Daily\n2. Weekly\n3. Bi-Weekly\n4. Monthly\n5. Six Months\n6. One year");
				string installmentInput = Console.ReadLine();
				int installmentNumber = Int32.Parse(installmentInput);
				InstallmentTypes installmentType = (InstallmentTypes)installmentNumber;

				Console.WriteLine("How much is to be paid?");
				string amountPaidInput = Console.ReadLine();
				int amountPaidNumber = Int32.Parse(amountPaidInput);

				TransactionPayment transaction = new TransactionPayment();
				transaction.customerName = customerNameInput;
				transaction.itemName = itemInput;
				transaction.itemPrice = itemPriceInputNumber;
				transaction.installmentType = installmentType;
				transaction.amountPaid = amountPaidNumber;

				transactionsList.Add(transaction);

				Console.WriteLine("Payment Added");

				TaskSelect();
            }
            catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private void ViewPayments()
		{ 
            Console.WriteLine("You have " + transactionsList.Count + " Transaction(s)");

			for(var i = 0; i < transactionsList.Count; i++)
			{
				TransactionPayment currentTransaction = transactionsList[i];
				string installmentType = GetInstallmentName(currentTransaction.installmentType);

				Console.WriteLine(
					""
					+
                    "\nCustomer Name: " + currentTransaction.customerName
                    + "\nItem: " + currentTransaction.itemName
                    + "\nItem Price: " + currentTransaction.itemPrice
					+ "\nInstallment Type: " + installmentType
					+ "\nAmount Paid: " + currentTransaction.amountPaid
                    );
			}

			TaskSelect();
        }

		private string GetInstallmentName(InstallmentTypes type)
		{
			switch (type) {
				case InstallmentTypes.DAILY:
					return "Daily";
				case InstallmentTypes.WEEKLY:
					return "Weekly";
				case InstallmentTypes.BIWEEKLY:
                    return "Bi-weekly";
				case InstallmentTypes.MONTHLY:
                    return "Monthly";
				case InstallmentTypes.SIXMONTHS:
                    return "Six Months";
				case InstallmentTypes.ONEYEAR:
                    return "One year";
			}

			return "";
		}
    }
}

