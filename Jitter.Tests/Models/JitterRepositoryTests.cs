using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jitter.Models;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;

namespace Jitter.Tests.Models
{
    [TestClass]
    public class JitterRepositoryTests
    {
        [TestMethod]
        public void JitterContextEnsureICanCreateInstance()
        {
            JitterContext context = new JitterContext();
            Assert.IsNotNull(context);

        }

        [TestMethod]
        public void JitterRepositoryEnsureICanCreatInstance()
        {
            JitterRepository repository = new JitterRepository();
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void JitterRepositoryEnsureICanGetAllUsers()
        {
            //Arrange
            var expected = new List<JitterUser>
            {
                new JitterUser { Handle = "adam1"},
                new JitterUser { Handle = "rumbadancer1" }
            };

            //stubbing is replacing the real return value with what we want it to return


            Mock<JitterContext> mock_context = new Mock<JitterContext>();
            Mock<DbSet<JitterUser>> mock_set = new Mock<DbSet<JitterUser>>();//see JitterContext.cs

            mock_set.Object.AddRange(expected);

            //This is Stubbing the JitterUsers Property getter
            mock_context.Setup(a => a.JitterUsers).Returns(mock_set.Object);
                
            //looks at all the behaviors of this class and duplicate it, tests a class in isolation
            JitterRepository repository = new JitterRepository(mock_context.Object);//getter that references the underlying mocked class);

            //Act
            var actual = repository.GetAllUsers();
            //Assert
            //Assert.AreEqual("adam1", actual.First().Handle);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void JitterRepositoryEnsureIHaveAContext()
        {
            //Arrange
            JitterRepository repository = new JitterRepository();

            //Act
            var actual = repository.Context;
            //Assert
            Assert.IsInstanceOfType(actual, typeof(JitterContext));
        }
    }
}
