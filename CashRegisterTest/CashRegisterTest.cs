using Moq;

namespace CashRegisterTest
{
	using CashRegister;
    using Xunit;
    public class CashRegisterTest
	{
		[Fact]
		public void Should_process_execute_printing()
		{
			//given
            var printer = new SpyPrinter();
            var cashRegister = new CashRegister(printer);
            var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			//verify that cashRegister.process will trigger print
			Assert.True(printer.HasPrinted);
        }

        [Fact]
        public void Should_call_print_when_process_be_called_when_given_purchase()
        {
            //given
            var printerMock = new Mock<Printer>();
			var cashRegister = new CashRegister(printerMock.Object);
            var purchase = new Purchase();
            
            //when
            cashRegister.Process(purchase);
            
            //then
            printerMock.Verify(_=>_.Print(It.IsAny<string>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Should_print_purchase_content_when_run_process_given_stub_purchase()
        {
            //given
            var printerMock = new Mock<Printer>();
            var cashRegister = new CashRegister(printerMock.Object);
            var purchaseMock = new Mock<Purchase>();
            purchaseMock.Setup(_ => _.AsString())
                .Returns("moq string");

            //when
            cashRegister.Process(purchaseMock.Object);

            //then
            printerMock.Setup(_ => _.Print(It.IsAny<string>()))
                .Callback<string>(item => Assert.Equal("moq string", item));
        }
    }
}
