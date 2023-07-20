using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Stonks2.DAL.DataAccess;
using Stonks2.DAL.Models;

namespace Stonks2Web
{
    public class ChatHubsController : Controller
    {
        private ChatRoomContext db = new ChatRoomContext();

        // GET: ChatHubs
        public ActionResult Index()
        {
            return View(db.ChatHubs.ToList());
        }

        // GET: ChatHubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stonks2.DAL.Models.ChatHub chatHub = db.ChatHubs.Find(id);
            //Showing only last 50 messages
            chatHub.Messages = chatHub.Messages.OrderByDescending(message => message.TimeStamp).Take(50).OrderBy(message => message.TimeStamp).ToList();
            if (chatHub == null)
            {
                return HttpNotFound();
            }
            return View(chatHub);
        }

        // GET: ChatHubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChatHubs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChatHubId,ChatHubName,ChatHubDescription")] Stonks2.DAL.Models.ChatHub chatHub)
        {
            if (ModelState.IsValid)
            {
                db.ChatHubs.Add(chatHub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chatHub);
        }

        // GET: ChatHubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stonks2.DAL.Models.     ChatHub chatHub = db.ChatHubs.Find(id);
            if (chatHub == null)
            {
                return HttpNotFound();
            }
            return View(chatHub);
        }

        // POST: ChatHubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChatHubId,ChatHubName,ChatHubDescription")] ChatHub chatHub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chatHub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chatHub);
        }

        // GET: ChatHubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stonks2.DAL.Models.ChatHub chatHub = db.ChatHubs.Find(id);
            if (chatHub == null)
            {
                return HttpNotFound();
            }
            return View(chatHub);
        }

        // POST: ChatHubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stonks2.DAL.Models.ChatHub chatHub = db.ChatHubs.Find(id);
            db.ChatHubs.Remove(chatHub);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
