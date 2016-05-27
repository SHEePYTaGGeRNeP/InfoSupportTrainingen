using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using StudentTrackASP.Net.Models;

namespace StudentTrackASP.Net.Controllers
{
    using System.Threading;

    public class BuddiesController : Controller
    {
        private MijnContext db = new MijnContext();

        // GET: Buddies
        public ActionResult Index()
        {
            return this.View(new BuddiesIndexModel() { Buddies = this.db.Buddies.ToList() });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public PartialViewResult Index(BuddiesIndexModel model)
        {
            Thread.Sleep(2000);
            model.Buddies = this.db.Buddies.ToList();
            if (!this.ModelState.IsValid)
                return this.PartialView("IndexTable", model.Buddies);

            this.db.Buddies.Add(model.AddingBuddy);
            this.db.SaveChanges();
            model.Buddies.Add(model.AddingBuddy);
            model.AddingBuddy = null;
            return this.PartialView("IndexTable", model.Buddies);
        }

        // GET: Buddies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buddy buddy = this.db.Buddies.Find(id);
            if (buddy == null)
            {
                return this.HttpNotFound();
            }
            return this.View(buddy);
        }

        // GET: Buddies/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Buddies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age,Location,Huisnummer")] Buddy buddy)
        {
            Thread.Sleep(2000);
            if (!this.ModelState.IsValid) return this.View(buddy);
            this.db.Buddies.Add(buddy);
            this.db.SaveChanges();

            return this.RedirectToAction("Index");
        }

        // GET: Buddies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buddy buddy = this.db.Buddies.Find(id);
            if (buddy == null)
            {
                return this.HttpNotFound();
            }
            return this.View(buddy);
        }

        // POST: Buddies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Age,Location,Huisnummer")] Buddy buddy)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Entry(buddy).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return this.View(buddy);
        }

        // GET: Buddies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buddy buddy = this.db.Buddies.Find(id);
            if (buddy == null)
            {
                return this.HttpNotFound();
            }
            return this.View(buddy);
        }

        // POST: Buddies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Buddy buddy = this.db.Buddies.Find(id);
            this.db.Buddies.Remove(buddy);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
