using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core1.Utilities.Interceptors;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Core.Utilities.Security.Jwt;
using Core1.Configurations;
using Core1.Business.CloudinaryConfiguration;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutoFacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<EfCarDal>().As<ICarDal>();

            builder.RegisterType<CarSupplyManager>().As<ICarSupplyService>();
            builder.RegisterType<EfCarSupplyDal>().As<ICarSupplyDal>();

            builder.RegisterType<EfSupplyDal>().As<ISupplyDal>();

            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<EfCarDal>().As<ICarDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<CarPhotoManager>().As<ICarPhotoService>();
            builder.RegisterType<EfCarPhotoDal>().As<ICarPhotoDal>();

            builder.RegisterType<SparePartVideoManager>().As<ISparePartVideoService>();
            builder.RegisterType<EfSparePartVideoDal>().As<ISparePartVideoDal>();


            builder.RegisterType<EfSparePartDal>().As<ISparePartDal>();
            builder.RegisterType<SparePartManager>().As<ISparePartService>();
          

            builder.RegisterType<SparePartPhotoManager>().As<ISparePartPhotoService>();
            builder.RegisterType<EfSparePartPhotoDal>().As<ISparePartPhotoDal>();

            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<CloudinaryFileService>().As<IFileService>();

            builder.RegisterType<TransCareManager>().As<ITransCareService>();
            builder.RegisterType<EfTransCareDal>().As<ITransCareDal>();

            builder.RegisterType<TransCarePhotoManager>().As<ITransCarePhotoService>();
            builder.RegisterType<EfTransCarePhotoDal>().As<ITransCarePhotoDal>();

            var assemblies = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions{Selector=new AspectInterceptorSelector()});
        }
    }
}
