namespace Data_Annotations_EF.models.DB;

public static class ORM_Manager
{
    public static string Server
    {
        get => server;
        set => server = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static string Db
    {
        get => db;
        set => db = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static string User
    {
        get => user;
        set => user = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static string Pw
    {
        get => pw;
        set => pw = value ?? throw new ArgumentNullException(nameof(value));
    }

    private static string server = "localhost";
    private static string db = "orm_fluent";
    private static string user = "root";
    private static string pw = "SHW_Destroyer02";
    
    
}