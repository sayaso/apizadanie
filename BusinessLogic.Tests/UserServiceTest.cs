﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Services;


namespace BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;

        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>(); userRepositoryMoq = new Mock<IUserRepository>();
            repositoryWrapperMoq.Setup(x => x.User)
            .Returns(userRepositoryMoq.Object);
            service = new UserService(repositoryWrapperMoq.Object);
        }
    }
}
