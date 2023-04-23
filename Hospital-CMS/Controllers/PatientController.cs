using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using Hospital_CMS.Models;
using Hospital_CMS.Models.ViewModels;
using System.Web.Script.Serialization;



namespace Hospital_CMS.Controllers
{
    public class PatientController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();
        static PatientController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44370/api/");
        }

        // GET: Patient/List
        public ActionResult List()
        {
            //objective: communicate with our patient data api to retrieve a list of patients
            //curl https://localhost:44370/api/patientdata/listpatients

            string url = "patientdata/listpatients";
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response code is ");
            //Debug.WriteLine(response.StatusCode);

            IEnumerable<PatientDto> patients = response.Content.ReadAsAsync<IEnumerable<PatientDto>>().Result;
            //Debug.WriteLine("Number of patients received : ");
            //Debug.WriteLine(patients.Count());

            return View(patients);
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            //objective: communicate with our patient data api to retrieve one patient
            //curl https://localhost:44370/api/patientdata/findpatient/{id}

            string url = "patientdata/findpatient/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("The response code is ");
            Debug.WriteLine(response.StatusCode);

            PatientDto selectedpatient = response.Content.ReadAsAsync<PatientDto>().Result;
            Debug.WriteLine("patient received : ");
            Debug.WriteLine(selectedpatient.PFName + selectedpatient.PLName);

            return View(selectedpatient);
        }
        public ActionResult Error()
        {
            return View();
        }

        // GET: Patient/New
        public ActionResult New()
        {
            //information about all rooms in the system.
            //GET api/roomdata/listrooms

            string url = "roomdata/listrooms";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<RoomDto> roomsOptions = response.Content.ReadAsAsync<IEnumerable<RoomDto>>().Result;

            return View(roomsOptions);
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            Debug.WriteLine("the json payload is");
            //Debug.WriteLine(patient.PFName + patient.PLName);
            //objective: add a new patient into our system using the API
            //curl -H "Content-Type:application/json" -d @patient.json https://localhost:44370/api/patientdata/
            string url = "patientdata/addpatient";

            
            string jsonpayload = jss.Serialize(patient);

            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
           
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            UpdatePatient ViewModel = new UpdatePatient();

            //the existing patient information
            string url = "patientdata/findpatient/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            PatientDto SelectedPatient = response.Content.ReadAsAsync<PatientDto>().Result;
            ViewModel.SelectedPatient = SelectedPatient;

            //all rooms to choose from when updating this patient

            //the existing patient information
            url = "roomdata/listrooms/" + id;
            response = client.GetAsync(url).Result;
            IEnumerable<RoomDto> RoomOptions = response.Content.ReadAsAsync<IEnumerable<RoomDto>>().Result;

            ViewModel.RoomOptions = RoomOptions;

            return View(ViewModel);
        }

        // POST: Patient/Update/5
        [HttpPost]
        public ActionResult Update(int id, Patient patient)
        {
            string url = "patientdata/updatepatient/" + id;
            string jsonpayload = jss.Serialize(patient);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            Debug.WriteLine(content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Patient/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string url = "patientdata/findpatient/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            PatientDto selectedpatient = response.Content.ReadAsAsync<PatientDto>().Result;

            return View(selectedpatient);
        }

        // POST: Patient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string url = "patientdata/deletepatient/" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            Debug.WriteLine(content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}
