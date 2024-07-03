using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using secDockerApp.Models;

namespace secDockerApp.Pages;

public class IndexModel : PageModel
{
    public string StudentName { get; private set; } = "PageModel in C#";
    private readonly ILogger<IndexModel> _logger;
    private readonly secDockerApp.Data.SchoolContext _context;

    public IndexModel(ILogger<IndexModel> logger, secDockerApp.Data.SchoolContext context)
    {
        _logger = logger;
        _context = context;
    }
    [BindProperty]
    public List<Student>? _studentLst { get; set; }
    public IActionResult OnGet()
    {
        _studentLst = _context.students?.ToList();
            //this.StudentName = $"{s?.FirstMidName} {s?.LastName}";
        return Page();
    }
    [BindProperty]
    public Student? _student { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (_student != null)
        {
            var noofrow = _context.students.Count();
            if (noofrow > 0) _student.ID = noofrow+1;

            _context.students.Add(_student);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
    //public void OnGet()
    //{
    //    var s = _context.students?.Where(d => d.ID == 1).FirstOrDefault();
    //    this.StudentName = $"{s?.FirstMidName} {s?.LastName}";
    //}
    // [HttpPost]
    //public void OnPost()
    //{
    //Student obj=new Student();
    //if (obj != null)
    //{
    //_context.students.Add(obj);
    //_context.SaveChanges();
    //}
    //}
    // private readonly ILogger<IndexModel> _logger;

    // public IndexModel(ILogger<IndexModel> logger)
    // {
    //     _logger = logger;
    // }

    // public void OnGet()
    // {

    // }
}
