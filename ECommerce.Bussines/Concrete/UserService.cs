using ECommerce.Bussines.Abstract;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.Concrete;
using ECommerce.Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Bussines.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<UserDto> AddAsync(UserAddDto userAddDto)
        {
            User user = new()
            {
                FirstName = userAddDto.FirstName,
                LastName = userAddDto.LastName,
                Gender = userAddDto.Gender,
                Email = userAddDto.Email,
                DateOfBirth = userAddDto.DateOfBirth,
                Address = userAddDto.Address,
                Password = userAddDto.Password,
                UserName = userAddDto.UserName,
                CreatedUserId = 1,
                CreatedDate = DateTime.Now,
            };

            var userAdd = await _userDal.AddAsync(user);
            return new UserDto
            {
                FirstName = userAdd.FirstName,
                LastName = userAdd.LastName,
                Gender = userAdd.Gender,
                Email = userAdd.Email,
                DateOfBirth = userAdd.DateOfBirth,
                Address = userAdd.Address,
                UserName = userAdd.UserName,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userDal.DeleteAsync(id);
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _userDal.GetAsync(x => x.Id == id);
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName,
                Address = user.Address,
                Email = user.Email,
                Id = user.Id

            };
        }

        public async Task<IEnumerable<UserDetailDto>> GetListAsync()
        {
            List<UserDetailDto> userDetailDtos = new();
            var response = await _userDal.GetListAsync();
            foreach (var item in response)
            {
                UserDetailDto userDetailDto = new()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Gender = item.Gender == true ? "Erkek" : "Kadın",
                    DateOfBirth = item.DateOfBirth,
                    UserName = item.UserName,
                    Address = item.Address,
                    Email = item.Email,
                    Id = item.Id

                };
                userDetailDtos.Add(userDetailDto);
            }
            return userDetailDtos;
        }

        public async Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var user = await _userDal.GetAsync(x => x.Id == userUpdateDto.Id);
            if (user == null)
                throw new Exception($"{userUpdateDto.Id} userId not found");

            user.FirstName = userUpdateDto.FirstName;
            user.LastName = userUpdateDto.LastName;
            user.Password = userUpdateDto.Password;
            user.PhoneNumber = userUpdateDto.PhoneNumber;
            user.UserName = userUpdateDto.UserName;
            user.DateOfBirth = userUpdateDto.DateOfBirth;
            user.Email = userUpdateDto.Email;
            user.Address = userUpdateDto.Address;
            user.Gender = userUpdateDto.Gender;
            user.UpdatedUserId = 1;
            user.UpdatedDate = DateTime.Now;

            var userUpdate = await _userDal.UpdateAsync(user);

            return new UserUpdateDto
            {

                FirstName = userUpdateDto.FirstName,
                LastName = userUpdateDto.LastName,
                PhoneNumber = userUpdateDto.PhoneNumber,
                UserName = userUpdateDto.UserName,
                DateOfBirth = userUpdateDto.DateOfBirth,
                Email = userUpdateDto.Email,
                Address = userUpdateDto.Address,
                Gender = userUpdateDto.Gender,

            };
        }
    }
}
