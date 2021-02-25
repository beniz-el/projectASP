using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Session;

using projectASP.Data;
using projectASP.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace projectASP.Pages

{
    public class IndexModel : PageModel
    {

        public Etudiant etudiant { get; set; }
        public Login login { get; set; }
        public Admin admin { get; set; }
        public String Msg;
        private readonly projectASP.Data.ASPContext _context;

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
       
        void connectionString()
        {
            con.ConnectionString = "data source=localhost; database=ASP; integrated security =SSPI;";
        }


        public void OnGet()
        {

        }

        public ActionResult OnPost(Login login)
        {

            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from dbo.admin where login='" + login.login + "' and password='" + login.password + "'";
            dr = com.ExecuteReader();
            if(dr.Read() == false) {
                dr.Close();
                com.CommandText = "select * from dbo.etudiant where login='" + login.login + "' and password='" + login.password + "'";
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    HttpContext.Session.SetString("CIN", dr["CIN"].ToString());
                    HttpContext.Session.SetString("login", dr["login"].ToString());
                    HttpContext.Session.SetString("password", dr["password"].ToString());
                    HttpContext.Session.SetString("nom", dr["nom"].ToString());
                    HttpContext.Session.SetString("prenom", dr["prenom"].ToString());
                    HttpContext.Session.SetString("datenaissance", dr["datenaissance"].ToString());
                    HttpContext.Session.SetString("email", dr["email"].ToString());
                    HttpContext.Session.SetString("tel", dr["tel"].ToString());
                    HttpContext.Session.SetString("CNE", dr["CNE"].ToString());
                    HttpContext.Session.SetString("filiere", dr["filiere"].ToString());
                    HttpContext.Session.SetString("image", dr["image"].ToString()); 
                    return RedirectToPage("./Profile");

                }
                else
                {
                    dr.Close();
                    com.CommandText = "select * from dbo.professeur where login='" + login.login + "' and password='" + login.password + "'";
                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        HttpContext.Session.SetString("CIN", dr["CIN"].ToString());
                        HttpContext.Session.SetString("login", dr["login"].ToString());
                        HttpContext.Session.SetString("password", dr["password"].ToString());
                        HttpContext.Session.SetString("nom", dr["nom"].ToString());
                        HttpContext.Session.SetString("prenom", dr["prenom"].ToString());
                        HttpContext.Session.SetString("datenaissance", dr["datenaissance"].ToString());
                        HttpContext.Session.SetString("email", dr["email"].ToString());
                        HttpContext.Session.SetString("tel", dr["tel"].ToString());
                        HttpContext.Session.SetString("matierespecialise", dr["matierespecialise"].ToString());
                        HttpContext.Session.SetString("filiere", dr["filiere"].ToString());
                        HttpContext.Session.SetString("image", dr["image"].ToString());
                        return RedirectToPage("./Professeur");

                    }
                    else
                    {

                        Msg = "Invalid username or password";
                        return Page();
                    }
                }
            }
            else
            {
                HttpContext.Session.SetString("login", dr["login"].ToString());
                return RedirectToPage("./Admin");
            }
          
            

        }



    }
}
