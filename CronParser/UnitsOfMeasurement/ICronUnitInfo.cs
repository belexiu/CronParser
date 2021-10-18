using System.Collections.Generic;

namespace CronParser.UnitsOfMeasurement
{
    public interface ICronUnitInfo
    {        
        int Min { get; }
        
        int Max { get; }

        IDictionary<string, int> AlternativeNamings { get; }
    }
}
