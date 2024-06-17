using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: UsersController
        public async Task <ActionResult> Index()
        {
            return View(await _userService.GetAllAsync());
        }

        // GET: UsersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return View(_mapper.Map<UserViewModel>(user));
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel createUserViewModel)
        {
            if (!ModelState.IsValid) return View(createUserViewModel);
            var user = _mapper.Map<User>(createUserViewModel);
            await _userService.InsertAsync(user);

            ViewBag.Sucesso = "Customer Registered!";

            return RedirectToAction("Index");
        }

        // GET: UsersController/Edit/5
        public async Task <ActionResult> Edit(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return View(_mapper.Map<UpdateUserViewModel>(user));
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(UpdateUserViewModel updateUserViewModel)
        {
            if (!ModelState.IsValid) return View(updateUserViewModel);
            var user = _mapper.Map<User>(updateUserViewModel);
            await _userService.UpdateAsync(user);

            ViewBag.Sucesso = "Customer Updated!";

            return RedirectToAction("Index");
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
