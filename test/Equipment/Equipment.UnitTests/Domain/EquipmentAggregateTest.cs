using System;
using Xunit;

namespace Boruc.LabEquip.Equipment.UnitTests.Domain
{
	using Services.Equipment.Domain.AggregatesModel.EquipmentAggregate;

	public class EquipmentAggregateTest
	{
		[Fact]
		public void CreateEquipmentItem_Success()
		{
			var name = "equipmentName";
			var number = "1230980123-123-3123";

			var equipmentItem = new Equipment(name, number);

			Assert.NotNull(equipmentItem);
		}

		[Fact]
		public void CreateEquipmentItem_EmptyName_Fail()
		{
			var name = string.Empty;
			var number = "12387_123";

			Assert.Throws<ArgumentNullException>(() => new Equipment(name, number));
		}

		[Fact]
		public void CreateEquipmentItem_EmptyNumber_Fail()
		{
			var name = "fakeName";
			var number = string.Empty;

			Assert.Throws<ArgumentNullException>(() => new Equipment(name, number));
		}

		[Fact]
		public void CreateBookItem_Success()
		{
			var bookId = "123";

			var bookItem = new Book(bookId);

			Assert.NotNull(bookItem);
		}
	}
}
