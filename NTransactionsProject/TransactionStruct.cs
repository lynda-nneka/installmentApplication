using System;
namespace NTransactionsProject
{
	public struct TransactionPayment
	{
		public string customerName;
		public string itemName;
		public int itemPrice;
		public int amountPaid;
		public InstallmentTypes installmentType;
	}

	public enum InstallmentTypes
	{
		DAILY,
		WEEKLY,
		BIWEEKLY,
		MONTHLY,
		SIXMONTHS,
		ONEYEAR
	}
}

