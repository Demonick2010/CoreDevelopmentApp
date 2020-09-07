using CoreDevelopmentApp.Data.Repository;
using CoreDevelopmentApp.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using X.PagedList;

namespace CoreDevelopmentGeneral.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index(int? page)
        {
            var listOfRequests = _repository.GetAllRequests();

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfProducts = listOfRequests.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize
        
            ViewBag.OnePageOfProducts = onePageOfProducts;

            TempData["selectListdata"] = _repository.GetAllApplicationItems();

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editedItem = _repository.GetEdit(id);
            var selectListData = _repository.GetAllApplicationItems();
            TempData["selectListdata"] = new SelectList(selectListData, "Id", "Name");

            return View(editedItem);
        }

        [HttpPost]
        public IActionResult Edit(RequestModel editedModel)
        {
            IEnumerable<ApplicationListModel> selectDataList;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something wrong.. Try again!");

                selectDataList = _repository.GetAllApplicationItems();
                TempData["selectListdata"] = new SelectList(selectDataList, "Id", "Name");

                return View(editedModel);
            }

            _repository.UpdateRequest(editedModel);

            selectDataList = _repository.GetAllApplicationItems();
            TempData["selectListdata"] = new SelectList(selectDataList, "Id", "Name");

            return View(editedModel);
        }
    }
}
