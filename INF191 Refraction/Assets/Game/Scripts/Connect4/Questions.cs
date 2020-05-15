using System.IO;
using Newtonsoft.Json;

public class TierSet
{
    public string[] tier1;
    public string[] tier2;
    public string[] tier3;
}

public class Questions
{
    public TierSet employer;
    public TierSet employee;
}
