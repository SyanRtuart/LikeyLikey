using LikeyLikey.Abstractions;
using LikeyLikey.Helpers;
using LikeyLikey.ViewModels;
using LikeyLikey.Views;
using Moq;
using NUnit.Framework;

namespace LikeyLikey.Android.Tests
{
    [TestFixture]
    public class LoginPageViewModelTests
    {
        private LoginPageViewModel _viewModel;
        private Mock<IPageService> _pageService;
        private Mock<IApiService> _apiService;

        [SetUp]
        public void Setup()
        {
            _pageService = new Mock<IPageService>();
            _apiService = new Mock<IApiService>();
            _viewModel = new LoginPageViewModel(_pageService.Object, _apiService.Object);
        }


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

        [Test]
        public void myTest()
        {
        
        }
    }
}
