using Ninject;
using System;
using System.Collections.Generic;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Service;
using System.Web.Mvc;

namespace EpamBlog.Ninject
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type servicetype)
        {
            return kernel.TryGet(servicetype);
        }
        private void AddBindings()
        {
            kernel.Bind<IArticleService>().To<ArticleService>();
            kernel.Bind<IQuizService>().To<QuizService>();
            kernel.Bind<IAnswerService>().To<AnswerService>();
            kernel.Bind<IReviewService>().To<ReviewService>();

        }
        public IEnumerable<object> GetServices(Type servicetype)
        {
            return kernel.GetAll(servicetype);
        }
    }
}