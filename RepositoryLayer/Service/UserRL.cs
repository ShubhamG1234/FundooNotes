using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL 
    {
        private readonly FundooContext fundoocontext;

        public UserRL(FundooContext fundoocontext)
        {
            this.fundoocontext = fundoocontext;
        }
        public UserEntity Register(UserRegistrationModel user)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;
                userEntity.Email = user.Email;
                userEntity.Password = user.Password;
                fundoocontext.UserTable.Add(userEntity);
                int result = fundoocontext.SaveChanges();
                if (result >0)
                {
                    return userEntity;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
