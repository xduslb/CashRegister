namespace CashRegister
{
    public interface IPrinter
    {
        public bool HasPrinted { get; set; }
        public void Print(string content);
    }
}
