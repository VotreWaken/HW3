using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace WindowsFormsApp28.Models
{
    public class DataBase
    {
        SqlConnection connection = null;
        DataSet dataSet = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();
        public DataBase()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["library"].ConnectionString;
        }

        public DataTable SearchByName(string name)
        {
            dataSet.Tables.Clear();

            var selectCommand = connection.CreateCommand();
            selectCommand.CommandText = $"SELECT B.Name, A.FirstName+' '+A.LastName as 'Author Name', P.Name " +
                $"from Books as B join Authors AS A on B.Id_Author=A.Id join Press AS P on B.Id_Press=P.Id WHERE B.Name LIKE '%{name}%'";

            adapter.SelectCommand = selectCommand;

            adapter.Fill(dataSet);

            return dataSet.Tables[0];
        }

        public DataTable SearchByAuthor(string name)
        {
            dataSet.Tables.Clear();

            var selectCommand = connection.CreateCommand();
            selectCommand.CommandText = $"SELECT B.Name, A.FirstName+' '+A.LastName " +
                $"FROM Books AS B join Authors AS A on B.Id = A.Id " +
                $"WHERE A.FirstName LIKE '%{name}%' OR A.LastName LIKE '%{name}%'";

            adapter.SelectCommand = selectCommand;

            adapter.Fill(dataSet);

            return dataSet.Tables[0];
        }

        public DataTable SearchByCategories(string name)
        {
            dataSet.Tables.Clear();

            var selectCommand = connection.CreateCommand();
            selectCommand.CommandText = $"SELECT B.Name, C.Name FROM Books AS B join Categories AS C on B.Id = C.Id WHERE C.Name LIKE '%{name}%'";

            adapter.SelectCommand = selectCommand;

            adapter.Fill(dataSet);

            return dataSet.Tables[0];
        }
    }


}
