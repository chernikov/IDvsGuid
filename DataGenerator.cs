using System.Data.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using NPoco;

namespace IDvsGuid
{
    public class DataGenerator
    {
        private static string connectionString = "Server=(local);Database=idvsguid;Trusted_Connection=True;";


    
        public void GenerateIdRecords(int count, string payload = "simple")
        {
            using (var dbContext = new IDvsGuidDbContext())
            {
                for (int i = 0; i < count; i++)
                {
                    dbContext.IdRecords.Add(new IdRecord()
                    {
                        Data = payload
                    });
                    dbContext.SaveChanges();
                }
            }
        }

        public void GenerateGuidRecords(int count, string payload = "simple")
        {
            using (var dbContext = new IDvsGuidDbContext())
            {
                for (int i = 0; i < count; i++)
                {
                    dbContext.GuidRecords.Add(new GuidRecord()
                    {
                        Data = payload
                    });
                    dbContext.SaveChanges();
                }
            }
        }


        public void GenerateIdRecordsDapper(int count, string payload = "simple")
        {
            using (var db = new SqlConnection(connectionString))
            {
                for (int i = 0; i < count; i++)
                {
                    db.Execute("INSERT INTO IdRecords(Data) VALUES (@payload)", new { payload });
                }
            }
        }
        public void GenerateGuidRecordsDapper(int count, string payload = "simple")
        {
            using (var db = new SqlConnection(connectionString))
            {
                for (int i = 0; i < count; i++)
                {
                    db.Execute("INSERT INTO GuidRecords(ID, Data) VALUES (NEWID(), @payload)", new { payload });
                }
            }
        }


        public void GenerateIdRecordsNPoco(int count, string payload = "simple")  {

             using (var db = new Database(connectionString, DatabaseType.SqlServer2008, SqlClientFactory.Instance)) 
             {
                for (int i = 0; i < count; i++)
                {
                    db.Execute("INSERT INTO IdRecords(Data) VALUES (@payload)", new { payload });
                }
             }
        }

         public void GenerateGuidRecordsNPoco(int count, string payload = "simple")
        {
            using (var db  = new Database(connectionString, DatabaseType.SqlServer2008, SqlClientFactory.Instance))
            {
                for (int i = 0; i < count; i++)
                {
                    db.Execute("INSERT INTO GuidRecords(ID, Data) VALUES (NEWID(), @payload)", new { payload });
                }
            }
        }

    }
}