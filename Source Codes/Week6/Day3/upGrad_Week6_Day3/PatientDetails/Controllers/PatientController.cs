using Microsoft.AspNetCore.Mvc;
using PatientDetails.Models;
using System.Collections.Generic;
using System.Linq;

namespace PatientDetails.Controllers
{
    public class PatientController : Controller
    {
        private static List<Patient> patients = new List<Patient>()
        {
            new Patient { Id = 1, Name = "Harish", Age = 24, Disease = "Fever" },
            new Patient { Id = 2, Name = "Balaji", Age = 23, Disease = "Cold" },
            new Patient { Id = 3, Name = "Ajay", Age = 24, Disease = "Dengue"}
        };

        // GET ALL
        public IActionResult Index()
        {
            return View(patients);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var patient = patients.FirstOrDefault(x => x.Id == id);
            return View(patient);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }

            patient.Id = patients.Any() ? patients.Max(x => x.Id) + 1 : 1;
            patients.Add(patient);

            return RedirectToAction("Index");
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var patient = patients.FirstOrDefault(x => x.Id == id);
            return View(patient);
        }

        // EDIT (POST)
        [HttpPost]
        public IActionResult Edit(Patient updatedPatient)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedPatient);
            }

            var patient = patients.FirstOrDefault(x => x.Id == updatedPatient.Id);

            if (patient != null)
            {
                patient.Name = updatedPatient.Name;
                patient.Age = updatedPatient.Age;
                patient.Disease = updatedPatient.Disease;
            }

            return RedirectToAction("Index");
        }

        // DELETE (GET)
        public IActionResult Delete(int id)
        {
            var patient = patients.FirstOrDefault(x => x.Id == id);
            return View(patient);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var patient = patients.FirstOrDefault(x => x.Id == id);

            if (patient != null)
            {
                patients.Remove(patient);
            }

            return RedirectToAction("Index");
        }
    }
}