//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyStore.Pages.Clients
{
    public class DeleteModel : PageModel
    {
        public String errorMessage = "";
        public String sucessMessage = "";

        private IConfigurationRoot Configuration;
        public DeleteModel(IConfiguration configRoot){
            Configuration = (IConfigurationRoot)configRoot;
        }

        public void OnGet()
        {
			try
			{
				String id = Request.Query["id"];

				String conneStr = this.Configuration.GetConnectionString("DefaultConnection");

				using (SqlConnection connection = new SqlConnection(conneStr))
				{
					connection.Open();

					String SqlQuery = "DELETE FROM clients WHERE id=@id";

					using (SqlCommand command = new SqlCommand(SqlQuery, connection))
					{
						command.Parameters.AddWithValue("@id", id);

						command.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Response.Redirect("/Clients/Index");
		}

        public void OnPost()
        {
           
        }
    }
}