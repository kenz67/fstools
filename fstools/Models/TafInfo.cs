namespace fstools.Models;

public class TafInfo
{
    public TafData TafData { get; set; }
}

public class TafData
{
    public string IcaoId { get; set; }
    public string RawTAF { get; set; }
    public DateTime IssueTime { get; set; }
    public string ValidTimeTo { get; set; }
    public List<string> Line_by_line { get; set; }
}

/*
KSFO 191720Z 1918/2024 19025G40KT 6SM SHRA SCT030 OVC050 
  FM200400 18010KT P6SM VCSH OVC050 
  FM201800 20011G19KT 4SM RA BR SCT025 OVC050

*/