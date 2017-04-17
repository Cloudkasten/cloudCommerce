using System;
using System.Linq;
using cloudCommerce.Core.Events;
using cloudCommerce.Core.Infrastructure;
using NUnit.Framework;
using cloudCommerce.Core.Data;

namespace cloudCommerce.Web.MVC.Tests.Events
{
    [TestFixture]
    public class EventsTests
    {
        private cloudCommerceEngine _engine;
        private IEventPublisher _eventPublisher;

        [TestFixtureSetUp]
        public void SetUp()
        {
			DataSettings.SetTestMode(true);
			_engine = new cloudCommerceEngine();
			_engine.Initialize();
            _eventPublisher = _engine.Resolve<IEventPublisher>();
        }

        [Test]
        public void Can_find_consumers()
        {
            var types = _engine.ResolveAll<IConsumer<DateTime>>().ToList();
            Assert.AreEqual(1, types.Count);
            Assert.IsInstanceOf<DateTimeConsumer>(types[0]);
        }

        //[Test]
        //public void Can_publish_event()
        //{
        //    var oldDateTime = DateTime.Now.Subtract(TimeSpan.FromDays(7));
        //    DateTimeConsumer.DateTime = oldDateTime;

        //    var newDateTime = DateTime.Now.Subtract(TimeSpan.FromDays(5));
        //    _eventPublisher.Publish(newDateTime);

        //    Assert.AreEqual(DateTimeConsumer.DateTime, newDateTime);
        //}
    }
}
