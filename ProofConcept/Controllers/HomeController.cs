using System;
using System.Configuration;
using System.Web.Mvc;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace ProofConcept.Controllers
{
    public class HomeController : Controller
    {
        private readonly string configVaultUri = "VaultUri";
        private string _otsConnectionString;
        private const string ConnectionStringAttribute = "test_kv_oms";
        public ActionResult Index()
        {

            var section = (ConnectionStringsSection)ConfigurationManager.GetSection("connectionStrings");
            _otsConnectionString = section.ConnectionStrings[ConnectionStringAttribute].ConnectionString;


            if (string.IsNullOrEmpty(_otsConnectionString))
            {
                throw new InvalidOperationException("Connection string not found in Azure Key Vault.");
            }

            ViewBag.ConnectionString = _otsConnectionString;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}