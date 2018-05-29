using LikeyLikey.Abstractions;
using LikeyLikey.ViewModels;
using Moq;
using NUnit.Framework;

namespace LikeyLikey.Android.Tests
{
    [TestFixture]
    public class LoginPageViewModelTests
    {
        private LoginPageViewModel _viewModel;
        private Mock<IPageService> _pageService;

        [SetUp]
        public void Setup()
        {
            _pageService = new Mock<IPageService>();
            _viewModel = new LoginPageViewModel(_pageService.Object);
        }

        //[Test]
        //public void LoginAttempt_InvalidCredentials_DisplayInvalidCredentialsMessage()
        //{

        //    _viewModel.Email = "1";
        //    _viewModel.Password = "1";

        //    _viewModel.LoginAttemptCommand.Execute(null);

        //    Assert.That(_viewModel.)

        //}

        [Test]
        public void CanLogin_UsernameAndPasswordNotNull_ReturnsTrue()
        {
            _viewModel.Email = "a";
            _viewModel.Password = "b";

            var response = _viewModel.LoginAttemptCommand.CanExecute(null);

            Assert.IsTrue(response);
        }

        [Test]
        public void CanLogin_UsernameAndPasswordEmptyString_ReturnsFalse()
        {
            _viewModel.Email = "";
            _viewModel.Password = "";

            var response = _viewModel.LoginAttemptCommand.CanExecute(null);

            Assert.IsFalse (response);
        }

    }
}
