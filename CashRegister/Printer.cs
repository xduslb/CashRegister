namespace CashRegister
{
	public class Printer : IPrinter
	{
        public bool HasPrinted { get; set; }
        public virtual void Print(string content)
		{
            // send message to a real printer
            HasPrinted = true;
        }
	}
}
