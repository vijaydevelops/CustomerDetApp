using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerDetMigrations.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CustomerDetWebApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustDbContext _context;

        private readonly IConfiguration _config;

        public CustomersController(CustDbContext context, IConfiguration config)
        {
            _context = context;

            _config = config;
        }


        // GET: Customers
        public async Task<IActionResult> Index()
        {
            if(TempData["ReturnedMessage"] != null)
            {
                ViewBag.ReturnedMessage = TempData["ReturnedMessage"];
            }

            string baseUrl = _config.GetValue<string>(
                    "WebAPIBaseUrl");
            string apiUrl = baseUrl + "customers";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        // var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                        var customers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Customer>>(data);

                        // ViewBag.ReturnedMessage = "Success";

                        return View(customers);
                    }
                    else
                    {
                        // return View(await _context.Customers.ToListAsync());

                        var custs = new List<Customer>();
                        ViewBag.ReturnedMessage = "Failed in retrieving customer details data..";
                        return View(custs);
                    }
                }
                catch (Exception ex)
                {
                    var custs = new List<Customer>();
                    ViewBag.ReturnedMessage = "Failed in retrieving customer details data.." + ex.Message;
                    return View(custs);
                }
            }
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (TempData["ReturnedMessage"] != null)
            {
                ViewBag.ReturnedMessage = TempData["ReturnedMessage"];
            }

            if (id == null)
            {
                // return NotFound();
                TempData["ReturnedMessage"] = "Customer Id required to get details..";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var customer_withInfo = await getDetail(id.Value);

                if (customer_withInfo.Item1 == null)
                {
                    // return NotFound();
                    TempData["ReturnedMessage"] = customer_withInfo.Item2; // "Requested Customer Id does not exist..";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(customer_withInfo.Item1);
                }
            }
        }



        public async Task<Tuple<Customer,string>> getDetail(long id)
        {
            string statusMessage = "";

            string baseUrl = _config.GetValue<string>(
                    "WebAPIBaseUrl");
            string apiUrl = baseUrl + "customers/" + id;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    // var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    var customer = Newtonsoft.Json.JsonConvert.DeserializeObject<Customer>(data);

                    return (new Tuple<Customer, string>(customer, statusMessage));
                }
                else
                {
                    /*
                    var customer = await _context.Customers
                                    .FirstOrDefaultAsync(m => m.Id == id);

                    // var customer = await _context.Customers.FindAsync(id);

                    customer = new Customer();
                    // empty object
                    */

                    statusMessage = "Failed in getting of requested customer..";

                    return (new Tuple<Customer, string>(null, statusMessage));

                }
            }
        }





        // GET: Customers/Create
        public IActionResult Create()
        {
            if (TempData["ReturnedMessage"] != null)
            {
                ViewBag.ReturnedMessage = TempData["ReturnedMessage"];
            }

            return View();
        }



        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,custCode,custName,custAddress,country,custEmail,custContactNo")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                // _context.Add(customer);

                // await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));

                string baseUrl = _config.GetValue<string>(
                   "WebAPIBaseUrl");
                string apiUrl = baseUrl + "customers/create";


                var customer_withInfo = await postSingleItemData(apiUrl, customer);

                TempData["ReturnedMessage"] = customer_withInfo.Item2; // "Requested Customer Id does not exist..";
                return RedirectToAction(nameof(Index));

                /*
                if (customer_withInfo.Item1 == null){

                } else{   

                }
                */
            } 
            else
            {
                ViewBag.ReturnedMessage = "Data invalid..";
                return View(customer);
            }

            
        }



        public async Task<Tuple<Customer, string>> postSingleItemData(string apiUrl, Customer cust, bool isUpdate = false)
        {

            string statusMessage = "";


            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(cust);
                var cust_dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                // var resp_contents = await response.Content.ReadAsStringAsync(); // for testing
                // var r1 = response.IsSuccessStatusCode; // for testing

                /*
                var content2 = new FormUrlEncodedContent(cust_dict);
                HttpResponseMessage response2 = await client.PostAsync(apiUrl, content);
                var resp_contents2 = await response2.Content.ReadAsStringAsync();
                var r2 = response2.IsSuccessStatusCode;
                */

                // TEST RESULT : Both techniques work

                if (response.IsSuccessStatusCode)
                {
                    var resp_contents = await response.Content.ReadAsStringAsync();
                    // var data = resp_contents; //  await response.Content.ReadAsStringAsync();
                    var messageData = Newtonsoft.Json.JsonConvert.DeserializeObject<Customer>(resp_contents);

                    // TempData["ReturnedMessage"] = "Data Successfully added";
                    // return RedirectToAction(nameof(Index));

                    statusMessage = !isUpdate ?"Customer Data saved successfully" : "Customer Data updated successfully";

                    return (new Tuple<Customer, string>(messageData, statusMessage));

                }
                /*
                else if (response2.IsSuccessStatusCode)
                {
                    var data = resp_contents2; // await response2.Content.ReadAsStringAsync();
                    var messageData = Newtonsoft.Json.JsonConvert.DeserializeObject<Customer>(data);

                    TempData["ReturnedMessage"] = "Data Successfully added";
                    return RedirectToAction(nameof(Index));
                }
                */
                else
                {
                    // for test, check resp_contents value

                    // TempData["ReturnedMessage"] = "Failed saving customer data";
                    // return RedirectToAction(nameof(Index));

                    statusMessage = !isUpdate ?"Failed saving customer data" : "Failed updating customer data";
                    return (new Tuple<Customer, string>(null, statusMessage));
                }
            }
        }




        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (TempData["ReturnedMessage"] != null)
            {
                ViewBag.ReturnedMessage = TempData["ReturnedMessage"];
            }

            if (id == null)
            {
                // return NotFound();
                TempData["ReturnedMessage"] = "Customer Id required to update details..";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var customer_withInfo = await getDetail(id.Value);

                if (customer_withInfo.Item1 == null)
                {
                    // return NotFound();
                    TempData["ReturnedMessage"] = customer_withInfo.Item2; // "Requested Customer Id does not exist..";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(customer_withInfo.Item1);
                }
            }
        }




        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,custCode,custName,custAddress,country,custEmail,custContactNo")] Customer customer)
        {
            if(id != customer.Id)
            {
                TempData["ReturnedMessage"] = "Posted data does not match requested Id..";
                return RedirectToAction(nameof(Index));
            }


            if (ModelState.IsValid)
            {
                // _context.Update(customer);

                // await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));

                string baseUrl = _config.GetValue<string>(
                   "WebAPIBaseUrl");
                string apiUrl = baseUrl + "customers/edit/" + id;

                var customer_withInfo = await postSingleItemData(apiUrl, customer, isUpdate: true);

                TempData["ReturnedMessage"] = customer_withInfo.Item2; // "Requested Customer Id does not exist..";
                return RedirectToAction(nameof(Index));

                /*
                if (customer_withInfo.Item1 == null){

                } else{   

                }
                */
            }

            ViewBag.ReturnedMessage = "Data invalid..";
            return View(customer);
        }

        // FOR TESTING INITIALY USED
        [HttpPost, ActionName("Delete2")]
        [ValidateAntiForgeryToken]
        public async Task<string> DeleteConfirmed2([Bind("Id")] Customer cust)
        {
            long x_id = cust.Id;
            /*
            Request.EnableBuffering();
            var jsonData = await new StreamReader(Request.Body).ReadToEndAsync();
            // return jsonData;
            */
            string baseUrl = _config.GetValue<string>(
                   "WebAPIBaseUrl");
            string apiUrl = baseUrl + "customers/delete/" + x_id;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(new { id = x_id }), Encoding.UTF8, "application/json");
                // stringcontent used to generate headers

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var messageData = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageReturn>(data);

                    TempData["ReturnedMessage"] = messageData.message;
                    
                }
                else
                {
                    TempData["ReturnedMessage"] = "Failed deleting selected customer";
                }


                return TempData["ReturnedMessage"].ToString();

                // stringcontent used to generate headers
                // return new StringContent(TempData["ReturnedMessage"].ToString(), Encoding.UTF8, "text/plain");
            }

        }


        // NEEDS LEARNING
        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed([Bind("item.Id")] Customer cust)
        public async Task<IActionResult> DeleteConfirmed([FromBody] int id)
        {
            // dynamic obj = await Request.Content.ReadAsAsync<JObject>();
            // var y = obj.var1;

            // Request.RequestUri.ParseQueryString()[key]

            /*
            Validate.IsNotNull("formDataCollection", formDataCollection);
            */
            var x_id = id;

            Request.EnableBuffering();
            var jsonData = await new StreamReader(Request.Body).ReadToEndAsync();
            

            /*
            var p = Request.Content.ReadAsAsync<JObject>();
            return (T)Convert.ChangeType(p.Result[key], typeof(T)); // example conversion, could be null...
            */

            string baseUrl = _config.GetValue<string>(
                   "WebAPIBaseUrl");
            string apiUrl = baseUrl + "customers/delete/" + x_id;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(new { id = x_id }), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var messageData = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageReturn>(data);

                    TempData["ReturnedMessage"] = messageData.message;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ReturnedMessage"] = "Failed deleting selected customer";
                    return RedirectToAction(nameof(Index));
                }
            }

            /*
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            */
        }




        private bool CustomerExists(long id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
