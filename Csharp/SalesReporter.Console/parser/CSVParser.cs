namespace SalesReporterKata;

public class CSVParser : Parser
{
    private static char CSV_SEPARATOR = ',';
    private string[] contentLines;

    public CSVParser(string file) : base(file)
    {
        contentLines = getAllLines();
    }

    private String[] getAllLines()
    {
        return File.ReadAllLines(file); 
    }

    public List<string> parseHeader()
    {
        var columnInfos = new List<string>();
        foreach (var columName in contentLines[0].Split(','))
        {
            columnInfos.Add(columName);
        }
        return columnInfos;
    }

    public IEnumerable<string> parseData()
    {
        return contentLines.Skip(1);
    }

    public override List<OrderDto> CreateOrdersList()
    {
        List<OrderDto> ordersList = new List<OrderDto>();
        foreach (string line in contentLines.Skip(1))
        {
            var cells = line.Split(CSV_SEPARATOR);
            OrderDto orderData = new OrderDto();
            orderData.OrderId = cells[0];
            orderData.Client = cells[1];
            orderData.NumberOfItems = int.Parse(cells[2]);
            orderData.TotalOfBasket = double.Parse(cells[3]);
            orderData.DayOfBuy = cells[4];
            ordersList.Add(orderData);
        }

        return ordersList;
    }
}