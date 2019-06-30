using Boruc.LabEquip.Services.SharedKernel;

namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate
{
	public class TaskType : Enumeration
	{
		public static readonly TaskType Verification = new VerificationTaskType();
		public static readonly TaskType Calibration = new CalibrationTaskType();
		public static readonly TaskType Overview = new OverviewTaskType();
		public static readonly TaskType Repair = new RepairTaskType();

		public TaskType(int id, string name) : base(id, name)
		{ }

		private class VerificationTaskType : TaskType
		{
			public VerificationTaskType() : base(1, "Validation")
			{ }
		}

		private class CalibrationTaskType : TaskType
		{
			public CalibrationTaskType() : base(2, "Calibration")
			{
			}
		}

		private class OverviewTaskType : TaskType
		{
			public OverviewTaskType() : base(3, "Overview")
			{
			}
		}

		private class RepairTaskType : TaskType
		{
			public RepairTaskType() : base(4, "Repair")
			{
			}
		}
	}
}