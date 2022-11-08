using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect:MethodInterception
    {
        int _interval;
        Stopwatch _stopwatch;
        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }
        protected override void OnAfter(IInvocation invocation)
        {
            _stopwatch.Stop();
            if (_stopwatch.Elapsed.TotalSeconds>_interval)
            {
                Debug.WriteLine($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}
