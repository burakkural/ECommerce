using ECommerce.Entities.Dtos.UserDtos;
using ECommerce.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ECommerce.WebMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly string baseURL = "http://localhost:63663/api/";
        private readonly HttpClient _client ;

        public UsersController(HttpClient client)
        {
            _client = client;
        }
        public async Task<IActionResult> Index()
        {
            var users =await _client.GetFromJsonAsync<List<UserDetailDto>>(baseURL+ "Users/GetList");
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.GenderList = Utils.Helpers.FillGender();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddViewModel userAddViewModel)
        {
            UserAddDto userAddDto = new ()
            {
                UserName = userAddViewModel.UserName,
                FirstName = userAddViewModel.FirstName,
                LastName = userAddViewModel.LastName,
                Gender = userAddViewModel.GenderID == 1 ? true : false,
                Address = userAddViewModel.Address,
                DateOfBirth = userAddViewModel.DateOfBirth,
                Email = userAddViewModel.Email,
                PhoneNumber = userAddViewModel.PhoneNumber,
                Password = userAddViewModel.Password,          
            };

            var addResponse = await _client.PostAsJsonAsync<UserAddDto>(baseURL + "Users/Add", userAddDto);
            if (addResponse.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _client.GetFromJsonAsync<UserDetailDto>(baseURL + "Users/GetById/"+id);
            UserUpdateViewModel userUpdateViewModel = new()
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                GenderID = user.Gender == true ? 1 : 2,
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
            };
            ViewBag.GenderList = Utils.Helpers.FillGender();
            return View(userUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UserUpdateViewModel userUpdateViewModel)
        {
            UserUpdateDto userUpdateDto = new()
            {
                UserName = userUpdateViewModel.UserName,
                FirstName = userUpdateViewModel.FirstName,
                LastName = userUpdateViewModel.LastName,
                Gender = userUpdateViewModel.GenderID == 1 ? true : false,
                Address = userUpdateViewModel.Address,
                DateOfBirth = userUpdateViewModel.DateOfBirth,
                Email = userUpdateViewModel.Email,
                PhoneNumber = userUpdateViewModel.PhoneNumber,
                Password = userUpdateViewModel.Password,
                Id = id
            };
            var userUpdateResponse = await _client.PutAsJsonAsync(baseURL + "Users/Update",userUpdateDto);
            if (userUpdateResponse.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(userUpdateViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _client.GetFromJsonAsync<UserDetailDto>(baseURL + "Users/GetById/" + id);
            UserDeleteViewModel userUpdateViewModel = new()
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                GenderID = user.Gender == true ? 1 : 2,
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
            };
            ViewBag.GenderList = Utils.Helpers.FillGender();
            return View(userUpdateViewModel);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _client.DeleteAsync(baseURL + "Users/Delete/" + id);
            return RedirectToAction("Index");

        }
    }
}
