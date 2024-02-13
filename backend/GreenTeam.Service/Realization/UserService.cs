﻿using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.Entities;
using GreenTeam.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Service.Realization
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Role> _roleRepository;
        public UserService(IUserRepository userRepository,
                                IRepository<Role> roleRepository) {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async void Create(User user, int roleId)
        {
            var role = await _roleRepository.Get(roleId);
            _userRepository.Create(user, role);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public User Get(int id)
        {
            var user = _userRepository.Get(id);
            user.Roles.First().Users = new List<User>();
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async void Update(User user, int roleId)
        {
            var role = await _roleRepository.Get(roleId);
            _userRepository.Update(user, role);
        }
    }
}
