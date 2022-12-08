using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermWeb.Data;
using TermWeb.Models;

namespace TermWeb.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly TermWebContext _context;

        public ArticlesController(TermWebContext context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index(string category, string searchString)
        {
            if (_context.Article == null)
            {
                return Problem("Entity set 'TermWebContext.Article'  is null.");
            }

            IQueryable<string> genreQuery = from m in _context.Article
                                            orderby m.Head
                                            select m.Head;

            var articles = from m in _context.Article
                         select m;

            articles = articles.OrderByDescending(s => s.PostDate);

            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(s => s.Title!.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(category))
            {
                articles = articles.Where(x => x.Head == category);
            }

            foreach (var article in articles)
            {
                if (article.Deadline < DateTime.Now) article.IsStillGoing = false;
                else article.IsStillGoing = true;

                TimeSpan ts = article.Deadline.Subtract(DateTime.Now);

                article.RemainDate = ts.ToString(@"dd\:hh\:mm\:ss");
            }




            var categoryVM = new CategoryViewModel
            {
                Category = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Articles = await articles.ToListAsync()
            };

            return View(categoryVM);
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id, bool like)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            if (article.Deadline < DateTime.Now) article.IsStillGoing = false;
            else article.IsStillGoing = true;

            TimeSpan ts = article.Deadline.Subtract(DateTime.Now);

            article.RemainDate = ts.ToString(@"dd\:hh\:mm\:ss");

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Kudos,Head,IsStillGoing,WriterID,MallName,Price,PostDate,DeliverPrice,Etc,Currency,Deadline,RemainDate,Password,OrigPrice,Link,Discount,ConfirmPassword")] Article article)
        {
            

            if (ModelState.IsValid)
            {
                article.Discount = (article.OrigPrice - article.Price) / article.OrigPrice * 100;

                if (article.Deadline < DateTime.Now) article.IsStillGoing = false;
                else article.IsStillGoing = true;

                TimeSpan ts = article.Deadline.Subtract(DateTime.Now);

                article.RemainDate = ts.ToString(@"dd\:hh\:mm\:ss");

                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Kudos,Head,IsStillGoing,WriterID,MallName,Price,PostDate,DeliverPrice,Etc,Currency,Deadline,RemainDate,Password,OrigPrice,Link,Discount,ConfirmPassword")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                article.Discount = (article.OrigPrice - article.Price) / article.OrigPrice * 100;

                if (article.Deadline < DateTime.Now) article.IsStillGoing = false;
                else article.IsStillGoing = true;

                TimeSpan ts = article.Deadline.Subtract(DateTime.Now);

                article.RemainDate = ts.ToString(@"dd\:hh\:mm\:ss");

                

                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            if (article.Deadline < DateTime.Now) article.IsStillGoing = false;
            else article.IsStillGoing = true;

            TimeSpan ts = article.Deadline.Subtract(DateTime.Now);

            article.RemainDate = ts.ToString(@"dd\:hh\:mm\:ss");

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Article.FindAsync(id);
            _context.Article.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.Id == id);
        }

    }
}
