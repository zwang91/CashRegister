using Moq;

namespace CashRegisterTest
{
	using CashRegister;
	using System.Reflection;
	using Xunit;

	public class CashRegisterTest
	{
		[Fact]
		public void Should_process_execute_printing()
		{
			//given
            SpyPrinter printer = new SpyPrinter();
            var cashRegister = new CashRegister(printer);
            var purchase = new Purchase();
			//when
            cashRegister.Process(purchase);
			//then
			//verify that cashRegister.process will trigger print
            Assert.True(printer.HasPrinted);
        }

		[Fact]
		public void Should_print_call_when_run_process_given_spy_printer()
        {
			//given
            var spyPrinter = new Mock<Printer>();
            var cashRegister = new CashRegister(spyPrinter.Object);
            var purchase = new Purchase();
            //when
            cashRegister.Process(purchase);
            //then
            spyPrinter.Verify(_ => _.Print(It.IsAny<string>()));
        }

		[Fact]
		public void Should_print_purchase_content_when_run_process_given_stub_purchase()
        {
            //given
            var spyPrinter = new Mock<Printer>();
            var cashRegister = new CashRegister(spyPrinter.Object);
            var stubPurchase = new Mock<Purchase>();
            stubPurchase.Setup(_ => _.AsString()).Returns("moq stub purchase");
            //when
            cashRegister.Process(stubPurchase.Object);
            //then
            spyPrinter.Verify(_ => _.Print("moq stub purchase"));
        }
    }
}
