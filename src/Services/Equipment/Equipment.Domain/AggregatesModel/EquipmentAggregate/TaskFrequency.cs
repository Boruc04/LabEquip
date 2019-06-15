namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate
{
	using Boruc.LabEquip.Services.SharedKernel;

	public class TaskFrequency : Enumeration
	{
		public static TaskFrequency Monthly = new MonthlyTaskFrequency();
		public static TaskFrequency Yearly = new YearlyTaskFrequency();

		public TaskFrequency(int id, string name) : base(id, name)
		{
		}

		private class MonthlyTaskFrequency : TaskFrequency
		{
			public MonthlyTaskFrequency() : base(1, "Monthly")
			{
			}
		}

		private class YearlyTaskFrequency : TaskFrequency
		{
			public YearlyTaskFrequency() : base(2, "Yearly")
			{
			}
		}
	}
}