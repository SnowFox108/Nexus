public class e2Data
{
    private string _fieldname;
    private string _fieldvalue;

    public string FieldName { get { return _fieldname; } }
    public string FieldValue { get { return _fieldvalue; } }

    public e2Data(string fieldname, string fieldvalue)
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
        _fieldname = fieldname;
        _fieldvalue = fieldvalue;

    }

}