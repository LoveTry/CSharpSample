using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public class Notice
    {
        //服务定位器
        private IMessageingService svc;
        public Notice(IServiceLocator locator)
        {
            //svc = locator.GetMessageingService();
            svc = (IMessageingService)locator.GetService(typeof(IMessageingService));
            svc = locator.GetService<IMessageingService>();
        }

        public void Intersting()
        {
            svc.SendMessage();
        }
    }

    public class DINotice
    {
        //依赖注入
        private IMessageingService svc;
        public DINotice(IMessageingService service)
        {
            svc = service;
        }

        public void Intersting()
        {
            svc.SendMessage();
        }
    }
}
