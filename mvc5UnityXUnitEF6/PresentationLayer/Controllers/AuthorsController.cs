using AutoMapper;
using ServiceLayer.Models;
using ServiceLayer.Service;
using System.Net;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class AuthorsController : Controller
    {
        private IAuthorService _sv { get; set; }
        private IUnitOfWorkService _uow { get; set; }
        private IMapper _mapper { get; set; }
        // GET: Authors
        public AuthorsController(IAuthorService sv, IUnitOfWorkService uow,IMapper mapper)
        {
            _mapper = mapper;
            _sv = sv;
            _uow = uow;

        }
        public ActionResult Index()
        {
            return View(_sv.GetList());
        }

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorVM author = _sv.Details(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Age")] AuthorVM author)
        {
            if (ModelState.IsValid)
            {
                _sv.Create(author);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorVM author = _sv.Details(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Age")] AuthorVM author)
        {
            if (ModelState.IsValid)
            {
                _sv.Edit(author);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorVM author = _sv.Details(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _sv.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
