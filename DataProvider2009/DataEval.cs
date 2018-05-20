using System;

public class DataEval
{

    public static string SingleQuoteText(string value)
    {
        value = "'" + value + "'";
        return value;
    }

    public static string  QuoteText(string value)
    {
        value = "\"" + value + "\"";
        return value;
    }

    public static string QuoteTextLike(string value)
    {
        value = "(\"%" + value + "%\")";
        return value;
    }

    public static bool IsEmptyQuery(string value)
    {
        if (value == "" || value == null)
        {
            return true;
        }

        return false;
    }

    public static bool IsNegativeQuery(string value)
    {
        if (value == "" || value == null || value == "-1")
        {
            return true;
        }

        return false;
    }


    public static string Convert_BoolToString(bool value)
    {
        if (value)
        {
            return "1";
        }
        else
        {
            return "0";
        }
    }

    public static bool Convert_StringToBool(string value)
    {
        if (value == "1")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static string DateTypeConvert(string UpdateValue)
    {
        string updateValue = Convert.ToDateTime(UpdateValue).Year.ToString()
            + "-"
            + Convert.ToDateTime(UpdateValue).Month.ToString()
            + "-"
            + Convert.ToDateTime(UpdateValue).Day.ToString();

        return updateValue;
    }

    public static string DateTimeTypeConvert(string UpdateValue)
    {
        string updateValue = Convert.ToDateTime(UpdateValue).Year.ToString()
            + "-"
            + Convert.ToDateTime(UpdateValue).Month.ToString()
            + "-"
            + Convert.ToDateTime(UpdateValue).Day.ToString()
            + " "
            + Convert.ToDateTime(UpdateValue).Hour.ToString()
            + ":"
            + Convert.ToDateTime(UpdateValue).Minute.ToString()
            + ":"
            + Convert.ToDateTime(UpdateValue).Second.ToString();

        return updateValue;
    }

}

