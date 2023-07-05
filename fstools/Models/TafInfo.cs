namespace fstools.Models;

public class TafInfo
{
    public TafData TafData { get; set; }
}

public class TafData
{
    public string Station_id { get; set; }
    public string Raw { get; set; }
    public DateTime Issue_time { get; set; }
    public string Valid_time { get; set; }
    public List<string> Line_by_line { get; set; }
}