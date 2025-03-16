using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
namespace DataProvider
{
    public class DbConnectionContext : SqliteConnection
    {
        public override void Close()
        {
            throw new NotImplementedException();
        }
    }
}
