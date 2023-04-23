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
    public class RoomController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();
        static RoomController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44370/api/");
        }

        // GET: Room/List
        public ActionResult List()
        {
            //objective: communicate with our room data api to retrieve a list of rooms
            //curl https://localhost:44370/api/roomdata/listrooms

            string url = "roomdata/listrooms";
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response code is ");
            //Debug.WriteLine(response.StatusCode);

            IEnumerable<RoomDto> rooms = response.Content.ReadAsAsync<IEnumerable<RoomDto>>().Result;
            //Debug.WriteLine("Number of rooms received : ");
            //Debug.WriteLine(rooms.Count());

            return View(rooms);
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            //objective: communicate with our room data api to retrieve one room
            //curl https://localhost:44370/api/roomdata/findroom/{id}

            DetailsRoom ViewModel = new DetailsRoom();

            string url = "roomdata/findroom/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("The response code is ");
            Debug.WriteLine(response.StatusCode);

            RoomDto SelectedRoom = response.Content.ReadAsAsync<RoomDto>().Result;
            Debug.WriteLine("room received : ");
            Debug.WriteLine(SelectedRoom.RoomNo);

            ViewModel.SelectedRoom = SelectedRoom;

            //showcase information about patients related to this room
            //send a request to gather information about patients related to a particular room ID
            url = "patientdata/listpatientsforroom/" + id;
            response = client.GetAsync(url).Result;
            IEnumerable<PatientDto> RelatedPatients = response.Content.ReadAsAsync<IEnumerable<PatientDto>>().Result; 

            ViewModel.RelatedPatients = RelatedPatients;


            return View(ViewModel);
        }

        public ActionResult Error()
        {
            return View();
        }

        // GET: Room/New
        public ActionResult New()
        {
            
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        public ActionResult Create(Room room)
        {
            Debug.WriteLine("the json payload is");
            //Debug.WriteLine(room.RoomNo);
            //objective: add a new room into our system using the API
            //curl -H "Content-Type:application/json" -d @room.json https://localhost:44370/api/roomdata/
            string url = "roomdata/addroom";

            
            string jsonpayload = jss.Serialize(room);

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

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            string url = "roomdata/findroom/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            RoomDto selectedroom = response.Content.ReadAsAsync<RoomDto>().Result;

            return View(selectedroom);
           
        }

        // POST: Room/Update/5
        [HttpPost]
        public ActionResult Update(int id, Room room)
        {
            string url = "roomdata/updateroom/" + id;
            string jsonpayload = jss.Serialize(room);

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

        // GET: Room/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string url = "roomdata/findroom/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            RoomDto selectedroom = response.Content.ReadAsAsync<RoomDto>().Result;

            return View(selectedroom);
        }

        // POST: Room/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string url = "roomdata/deleteroom/" + id;
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
