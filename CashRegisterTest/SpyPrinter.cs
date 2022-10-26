using CashRegister;

namespace CashRegisterTest
{
    public class SpyPrinter : IPrinter
    {
        public bool HasPrinted { get; set; }
        public void Print(string content)
        {
            HasPrinted = true;
        }
    }
}
