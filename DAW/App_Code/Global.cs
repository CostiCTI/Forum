using System;
using System.Data;
using System.Linq;
using System.Web;

public static class Global
{
    static string _importantData1;

    public static string ImportantData
    {
        get
        {
            return _importantData1;
        }
        set
        {
            _importantData1 = value;
        }
    }


    static string _importantData2;

    public static string ImportantData2
    {
        get
        {
            return _importantData2;
        }
        set
        {
            _importantData2 = value;
        }
    }
}