using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestRS.Core.Commands;
using TestRS.Web.Models;

namespace TestRS.Web.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISender _mediator;

    public HomeController(ILogger<HomeController> logger, ISender mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        _logger.LogInformation("Started uploading a file");
        try
        {
            if (file == null)
            {
                ViewBag.Message = "No file selected";
                return View("Index");
            }

            var command = new FileArchiveCommand(file);

            var archiveResponse = await _mediator.Send(command);

            if (archiveResponse.IsSuccess)
            {
                ViewBag.Message = "File Upload Successful";
                ViewBag.FileId = archiveResponse.Id;

                _logger.LogInformation($"File with id: {archiveResponse.Id} was archived succesfully");
                return View("GetArchive");
            }
            else
            {
                _logger.LogInformation($"File with id: {archiveResponse.Id} couldn't be archived");
                ViewBag.Message = "File Upload Failed";
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            ViewBag.Message = "File Upload Failed";
        }

        _logger.LogInformation("Finished uploading a file");
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
