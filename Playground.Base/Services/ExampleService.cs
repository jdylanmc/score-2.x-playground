namespace Playground.Base.Services
{
    using System;

    public class ExampleService : IExampleService
    {
        public string GetMessage()
        {
            return string.Format("Hello. The time is currently {0}", DateTime.Now.TimeOfDay);
        }
    }
}