using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibrarieModele;
using chestionarDisciplineMVC.Models;
using AutoMapper;
using NivelServicii.cicluldestudiiNS;
using NivelServicii.programestudiuNS;

namespace chestionarDisciplineMVC.Controllers
{
    public class programdestudiuController : Controller
    {
        private IcicluldestudiiServicii _cicluldestudiiServicii;
        private IprogramestudiuServicii _programestudiuServicii;

        public programdestudiuController(IprogramestudiuServicii programestudiuServicii, IcicluldestudiiServicii cicluldestudiiServicii)
        {
            _programestudiuServicii = programestudiuServicii;
            _cicluldestudiiServicii = cicluldestudiiServicii;
        }

        // GET: programdestudiu
        public async Task<ActionResult> Index()
        {
            var programedestudiu = _programestudiuServicii.GetProgrameDeStudiu();
            var config = new MapperConfiguration(c => c.CreateMap<programedestudiu, programdestudiuModel>());
            var mapper = new Mapper(config);
            var programdestudiu = mapper.Map<List<programedestudiu>, List<programdestudiuModel>>(programedestudiu);
            return View(programdestudiu);
        }

        // GET: programdestudiu/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            programedestudiu programedestudiu = _programestudiuServicii.GetProgramDeStudiu((int)id);
            var config = new MapperConfiguration(c => c.CreateMap<programedestudiu, programdestudiuModel>());
            var mapper = new Mapper(config);
            var programdestudiu = mapper.Map<programedestudiu, programdestudiuModel>(programedestudiu);
            if (programedestudiu == null)
            {
                return HttpNotFound();
            }
            return View(programdestudiu);
        }

        // GET: programdestudiu/Create
        public ActionResult Create()
        {
            List<cicluldestudii> cicluldestudii = _cicluldestudiiServicii.GetCicluriDeStudii();
            ViewBag.id_ciclul_de_studii = new SelectList(cicluldestudii, "id_ciclu_de_studii", "nume_ciclu_de_studii");
            return View();
        }

        // POST: programdestudiu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_programe_de_studiu,nume_programe_de_studiu,id_ciclul_de_studii")] programdestudiuModel programedestudiu)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(c => c.CreateMap<programdestudiuModel, programedestudiu>());
                var mapper = new Mapper(config);
                programedestudiu programdestudiu = mapper.Map<programdestudiuModel, programedestudiu>(programedestudiu);
                _programestudiuServicii.CreateProgramDeStudiu(programdestudiu);
                return RedirectToAction("Index");
            }

            List<cicluldestudii> cicluldestudii = _cicluldestudiiServicii.GetCicluriDeStudii();
            ViewBag.id_ciclul_de_studii = new SelectList(cicluldestudii, "id_ciclu_de_studii", "nume_ciclu_de_studii", programedestudiu.id_ciclul_de_studii);
            return View(programedestudiu);
        }

        // GET: programdestudiu/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            programedestudiu programedestudiu = _programestudiuServicii.GetProgramDeStudiu((int)id);
            var config = new MapperConfiguration(c => c.CreateMap<programedestudiu, programdestudiuModel>());
            var mapper = new Mapper(config);
            var programdestudiu = mapper.Map<programedestudiu, programdestudiuModel>(programedestudiu);
            if (programedestudiu == null)
            {
                return HttpNotFound();
            }

            List<cicluldestudii> cicluldestudii = _cicluldestudiiServicii.GetCicluriDeStudii();
            ViewBag.id_ciclul_de_studii = new SelectList(cicluldestudii, "id_ciclu_de_studii", "nume_ciclu_de_studii", programedestudiu.id_ciclul_de_studii);
            return View(programdestudiu);
        }

        // POST: programdestudiu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_programe_de_studiu,nume_programe_de_studiu,id_ciclul_de_studii")] programdestudiuModel programedestudiu)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(c => c.CreateMap<programdestudiuModel, programedestudiu>());
                var mapper = new Mapper(config);
                programedestudiu programdestudiu = mapper.Map<programdestudiuModel, programedestudiu>(programedestudiu);
                _programestudiuServicii.UpdateProgramDeStudiu(programdestudiu, programedestudiu.id_programe_de_studiu);
                return RedirectToAction("Index");
            }

            List<cicluldestudii> cicluldestudii = _cicluldestudiiServicii.GetCicluriDeStudii();
            ViewBag.id_ciclul_de_studii = new SelectList(cicluldestudii, "id_ciclu_de_studii", "nume_ciclu_de_studii", programedestudiu.id_ciclul_de_studii);
            return View(programedestudiu);
        }

        // GET: programdestudiu/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            programedestudiu programedestudiu = _programestudiuServicii.GetProgramDeStudiu((int)id);
            var config = new MapperConfiguration(c => c.CreateMap<programedestudiu, programdestudiuModel>());
            var mapper = new Mapper(config);
            var programdestudiu = mapper.Map<programedestudiu, programdestudiuModel>(programedestudiu);
            if (programedestudiu == null)
            {
                return HttpNotFound();
            }
            return View(programdestudiu);
        }

        // POST: programdestudiu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            _programestudiuServicii.DeleteProgramDeStudiu(id);
            return RedirectToAction("Index");
        }

    }
}
