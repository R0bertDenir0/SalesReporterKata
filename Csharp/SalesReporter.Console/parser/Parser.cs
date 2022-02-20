namespace SalesReporterKata;

public abstract class Parser
{
    protected string file;
    protected Parser(string file)
    
    {
        this.file = file;
    }

    public abstract List<OrderDto> CreateOrdersList();
}