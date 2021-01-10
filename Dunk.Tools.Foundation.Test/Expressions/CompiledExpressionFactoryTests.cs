using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Dunk.Tools.Foundation.Expressions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Expressions
{
    [TestFixture]
    public class CompiledExpressionFactoryTests
    {
        [Test]
        public void ExpressionFactoryGeneratesGetterFromPropertyName()
        {
            var getterFunc = CompiledExpressionFactory.CreatePropertyGetter<CompiledExpTestEntity, int>("Id");

            Assert.IsNotNull(getterFunc);
        }

        [Test]
        public void ExpressionFactoryGetterFromPropertyNameGetPropertyValue()
        {
            var item = new CompiledExpTestEntity
            {
                Id = 1,
                Name = "foo"
            };

            var getterFunc = CompiledExpressionFactory.CreatePropertyGetter<CompiledExpTestEntity, int>("Id");

            Assert.AreEqual(1, getterFunc(item));
        }

        [Test]
        public void ExpressionFactoryGeneratesGetterFromPropertyInfo()
        {
            PropertyInfo property = typeof(CompiledExpTestEntity).GetProperty("Id");

            var getterFunc = CompiledExpressionFactory.CreatePropertyGetter<CompiledExpTestEntity, int>(property);

            Assert.IsNotNull(getterFunc);
        }

        [Test]
        public void ExpressionFactoryGetterFromPropertyInfoGetPropertyValue()
        {
            var item = new CompiledExpTestEntity
            {
                Id = 1,
                Name = "foo"
            };

            PropertyInfo property = typeof(CompiledExpTestEntity).GetProperty("Id");

            var getterFunc = CompiledExpressionFactory.CreatePropertyGetter<CompiledExpTestEntity, int>(property);

            Assert.AreEqual(1, getterFunc(item));
        }

        [Test]
        public void ExpressionFactoryGetterFromPropertySupportsCasting()
        {
            var item = new CompiledExpTestEntity
            {
                Id = 1,
                Name = "foo"
            };

            var getterFunc = CompiledExpressionFactory.CreatePropertyGetterWithCast<CompiledExpTestEntity, double>("Id");

            Assert.AreEqual(1.0, getterFunc(item));
        }

        [Test]
        public void ExpressionFactoryGetterFromPropertyInfoSupportsCasting()
        {
            var item = new CompiledExpTestEntity
            {
                Id = 1,
                Name = "foo"
            };

            PropertyInfo property = typeof(CompiledExpTestEntity).GetProperty("Id");

            var getterFunc = CompiledExpressionFactory.CreatePropertyGetterWithCast<CompiledExpTestEntity, double>(property);

            Assert.AreEqual(1.0, getterFunc(item));
        }

        [Test]
        public void ExpressionFactoryGeneratesSetterFromPropertyName()
        {
            var setterFunc = CompiledExpressionFactory.CreatePropertySetter<CompiledExpTestEntity, int>("Id");

            Assert.IsNotNull(setterFunc);
        }

        [Test]
        public void ExpressionFactorySetterFromPropertyNameSetsPropertyValue()
        {
            var item = new CompiledExpTestEntity
            {
                Id = 1,
                Name = "foo"
            };

            var setterFunc = CompiledExpressionFactory.CreatePropertySetter<CompiledExpTestEntity, int>("Id");

            setterFunc(item, 2);

            Assert.AreEqual(2, item.Id);
        }

        [Test]
        public void ExpressionFactoryGeneratesSetterFromPropertyInfo()
        {
            PropertyInfo property = typeof(CompiledExpTestEntity).GetProperty("Id");

            var setterFunc = CompiledExpressionFactory.CreatePropertySetter<CompiledExpTestEntity, int>(property);

            Assert.IsNotNull(setterFunc);
        }

        [Test]
        public void ExpressionFactorySetterFromPropertyInfoSetsPropertyValue()
        {
            var item = new CompiledExpTestEntity
            {
                Id = 1,
                Name = "foo"
            };

            PropertyInfo property = typeof(CompiledExpTestEntity).GetProperty("Id");

            var setterFunc = CompiledExpressionFactory.CreatePropertySetter<CompiledExpTestEntity, int>(property);

            setterFunc(item, 2);

            Assert.AreEqual(2, item.Id);
        }

        [Test]
        public void ExpressionFactoryGeneratesSetterWithCastFromPropertyName()
        {
            var setterWithCastFunc =
                CompiledExpressionFactory.CreatePropertySetterCast<CompiledExpTestEntity, object>("Name");

            Assert.IsNotNull(setterWithCastFunc);

        }

        [Test]
        public void ExpressionFactorySetterFromPropertyNameWithCastSetsPropertyValue()
        {
            var item = new CompiledExpTestEntity
            {
                Id = 1,
                Name = "foo"
            };

            var setterWithCastFunc =
                CompiledExpressionFactory.CreatePropertySetterCast<CompiledExpTestEntity, object>("Name");

            object o = "bar";

            setterWithCastFunc(item, o);

            Assert.AreEqual("bar", item.Name);
        }

        [Test]
        public void ExpressionFactoryGeneratesSetterWithCastFromPropertyInfo()
        {
            PropertyInfo property = typeof(CompiledExpTestEntity).GetProperty("Name");

            var setterWithCastFunc =
                CompiledExpressionFactory.CreatePropertySetterCast<CompiledExpTestEntity, object>(property);

            Assert.IsNotNull(setterWithCastFunc);
        }

        [Test]
        public void ExpressionFactorySetterFromPropertyInfoWithCastSetsPropertyValue()
        {
            var item = new CompiledExpTestEntity
            {
                Id = 1,
                Name = "foo"
            };

            PropertyInfo property = typeof(CompiledExpTestEntity).GetProperty("Name");

            var setterWithCastFunc =
                CompiledExpressionFactory.CreatePropertySetterCast<CompiledExpTestEntity, object>(property);

            object o = "bar";

            setterWithCastFunc(item, o);

            Assert.AreEqual("bar", item.Name);
        }

        private class CompiledExpTestEntity
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
