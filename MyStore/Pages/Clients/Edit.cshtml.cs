//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyStore.Pages.Clients
{
    public class EditModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public String errorMessage = "";
        public String sucessMessage = "";

        private IConfigurationRoot Configuration;
        public EditModel(IConfiguration configRoot){
            Configuration = (IConfigurationRoot)configRoot;
        }

        public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {


                String conneStr = this.Configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection connection = new SqlConnection(conneStr))
                {
                    connection.Open();
                    String SqlQuery = "SELECT * FROM clients WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using( SqlDataReader reader = command.ExecuteReader() )
                        {
                            if( reader.Read() )
                            {
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.phone = reader.GetString(3);
                                clientInfo.address = reader.GetString(4);
                            }
                        }
                    }
                }
            }
            catch( Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }

        public void OnPost()
        {
            clientInfo.id = Request.Form["id"];
            clientInfo.name = Request.Form["name"];
            clientInfo.email = Request.Form["email"];
            clientInfo.phone = Request.Form["phone"];
            clientInfo.address = Request.Form["address"];

            if (clientInfo.name.Length == 0 || clientInfo.email.Length == 0 ||
               clientInfo.phone.Length == 0 || clientInfo.address.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            try
            {

                String conneStr = this.Configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection connection = new SqlConnection(conneStr))
                {
                    connection.Open();
                    String SqlQuery = "UPDATE clients " +
                                    "SET name=@name, email=@email, phone=@phone, address=@address " +
                                    "WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", clientInfo.id);
                        command.Parameters.AddWithValue("@name", clientInfo.name);
                        command.Parameters.AddWithValue("@email", clientInfo.email);
                        command.Parameters.AddWithValue("@phone", clientInfo.phone);
                        command.Parameters.AddWithValue("@address", clientInfo.address);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                Console.WriteLine(errorMessage);
            }

            Response.Redirect("/Clients/Index");
        }
    }
}