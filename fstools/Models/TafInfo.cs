﻿using System.Diagnostics.CodeAnalysis;

namespace fstools.Models;

[ExcludeFromCodeCoverage]
public class TafInfo
{
    public TafData TafData { get; set; }
}

[ExcludeFromCodeCoverage]
public class TafData
{
    public string IcaoId { get; set; }
    public string RawTAF { get; set; }
    public DateTime IssueTime { get; set; }
    public string ValidTimeTo { get; set; }
    public List<string> Line_by_line { get; set; }
}