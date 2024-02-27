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
using Microsoft.Ajax.Utilities;
using AutoMapper;
using NivelServicii.anidestudiuNS;
using NivelServicii.cicluldestudiiNS;

namespace chestionarDisciplineMVC.Controllers
{
    public class anidestudiuController : Controller
    {

        private IanidestudiuServicii _anidestudiuServicii;
        private IcicluldestudiiServicii _cicluldestudiiServicii;

        public anidestudiuController(IanidestudiuServicii anidestudiuServicii, IcicluldestudiiServicii cicluldestudiiServicii) 
        {
            _anidestudiuServicii = anidestudiuServicii;
            _cicluldestudiiServicii = cicluldestudiiServicii;
        }

        // GET: anidestudiu
        public async Task<ActionResult> Index()
        {           
            var anidestudiu = _anidestudiuServicii.GetAniDeStudiu();
            var config = new MapperConfiguration(c => c.CreateMap<anidestudiu, anidestudiuModel>());
            var mapper = new Mapper(config);
            var andestudiu = mapper.Map<List<anidestudiu>, List<anidestudiuModel>>(anidestudiu);
            return View(andestudiu);
        }

        // GET: anidestudiu/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            anidestudiu anidestudiu = _anidestudiuServicii.GetAnDeStudiu((int)id);
            var config = new MapperConfiguration(c => c.CreateMap<anidestudiu, anidestudiuModel>());
            var mapper = new Mapper(config);
            var andestudiu = mapper.Map<anidestudiu, anidestudiuModel>(anidestudiu);
            if (anidestudiu == null)
            {
                return HttpNotFound();
            }
            return View(andestudiu);
        }

        // GET: anidestudiu/Create
        public ActionResult Create()
        {
            List<cicluldestudii> cicluldestudii = _cicluldestudiiServicii.GetCicluriDeStudii();
            ViewBag.ciclul_de_studii = new SelectList(cicluldestudii, "id_ciclu_de_studii", "nume_ciclu_de_studii");
            return View();
        }

        // POST: anidestudiu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_ani_de_studiu,anul_de_studiu,ciclul_de_studii")] anidestudiuModel anidestudiu)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(c => c.CreateMap<anidestudiuModel, anidestudiu>());
                var mapper = new Mapper(config);
                anidestudiu andestudiu = mapper.Map<anidestudiuModel, anidestudiu>(anidestudiu);
                _anidestudiuServicii.CreateAnDeStudiu(andestudiu);
                return RedirectToAction("Index");
            }
            List<cicluldestudii> cicluldestudii = _cicluldestudiiServicii.GetCicluriDeStudii();
            ViewBag.ciclul_de_studii = new SelectList(cicluldestudii, "id_ciclu_de_studii", "nume_ciclu_de_studii", anidestudiu.ciclul_de_studii);
            return View(anidestudiu);
        }

        // GET: anidestudiu/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anidestudiu anidestudiu = _anidestudiuServicii.GetAnDeStudiu((int)id);
            var config = new MapperConfiguration(c => c.CreateMap<anidestudiu, anidestudiuModel>());
            var mapper = new Mapper(config);
            var andestudiu = mapper.Map<anidestudiu, anidestudiuModel>(anidestudiu);
            if (anidestudiu == null)
            {
                return HttpNotFound();
            }

            List<cicluldestudii> cicluldestudii = _cicluldestudiiServicii.GetCicluriDeStudii();
            ViewBag.ciclul_de_studii = new SelectList(cicluldestudii, "id_ciclu_de_studii", "nume_ciclu_de_studii", anidestudiu.ciclul_de_studii);
            return View(andestudiu);
        }

        // POST: anidestudiu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_ani_de_studiu,anul_de_studiu,ciclul_de_studii")] anidestudiuModel anidestudiu)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(c => c.CreateMap<anidestudiuModel, anidestudiu>());
                var mapper = new Mapper(config);
                anidestudiu andestudiu = mapper.Map<anidestudiuModel, anidestudiu>(anidestudiu);
                _anidestudiuServicii.UpdateAnDeStudiu(andestudiu, anidestudiu.id_ani_de_studiu);
                return RedirectToAction("Index");
            }

            List<cicluldestudii> cicluldestudii = _cicluldestudiiServicii.GetCicluriDeStudii();
            ViewBag.ciclul_de_studii = new SelectList(cicluldestudii, "id_ciclu_de_studii", "nume_ciclu_de_studii", anidestudiu.ciclul_de_studii);
            return View(anidestudiu);
        }

        // GET: anidestudiu/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anidestudiu anidestudiu = _anidestudiuServicii.GetAnDeStudiu((int)id);
            var config = new MapperConfiguration(c => c.CreateMap<anidestudiu, anidestudiuModel>());
            var mapper = new Mapper(config);
            var andestudiu = mapper.Map<anidestudiu, anidestudiuModel>(anidestudiu);
            if (anidestudiu == null)
            {
                return HttpNotFound();
            }
            return View(andestudiu);
        }

        // POST: anidestudiu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            _anidestudiuServicii.DeleteAnDeStudiu(id);
            return RedirectToAction("Index");
        }

    }
}
