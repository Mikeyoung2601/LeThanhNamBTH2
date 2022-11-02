using LeThanhNamBTH2.Data;
using LeThanhNamBTH2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeThanhNamBTH2.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController ( ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.Students.ToListAsync();
            return View(model);
        }
        public IActionResult Create()
        {
            Return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            if(ModelState.IsValid)
            {
                _context.Add(std);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(std);
        }
    }
}
// GET: Student/Edit/5
public async Task<IActionResult> Edit(string id)
{
    if (id == null)
    {
        return View("NotFound");
    }

    var student = await  _context.Students.FindAsync(id);
    if(student == null)
    {
        return NotFound();
    }
    return View(student);
}

// POST: Student/Edit/5
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(string id, [Bind("StudentID,StudentName")] Student std)
{
    if (id != std.StudentID)
    {
        return NotFound();
    }
    if (ModelState.IsValid)
    {
        Try
        {
            _context.Update(std);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(std.StudentID))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}


//GET: Product/Delete/5
public async Task<IActionResult> Delete(string id)
{
    if (id == null)
    {
        return NotFound();
    }

    var std = await _context.Students
        .FirstOrDefaultAsync(m => m.StudentID == id);
    if (std = null)
    {
        return NotFound();
    }

    return ViewComponent(std);
}

//POST: Product/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(string id)
{
    var std = await _context.Students.FindAsync(id);
    _context.Students.Remove(std);
    await _context.SaveChangesAsync();
    Return RedirectToAction(nameof(Index));
}
