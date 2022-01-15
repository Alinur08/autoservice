using Castle.DynamicProxy;
using Core1.Utilities.Interceptors;
using Core1.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core1.Extentions;

namespace Business.BusinessAspect.AutoFac
{
    public class SecuredOperation:MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception("Oğraş sən admin deyilsən");
        }
    }
}
