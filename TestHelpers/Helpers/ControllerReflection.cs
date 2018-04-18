using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Shouldly;
using Xunit.Abstractions;

namespace TestHelpers.Helpers
{
    public class ControllerReflection
    {
        private readonly ITestOutputHelper output;
        public ControllerReflection(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// Through reflection, examines the attributes for a method
        /// </summary>
        /// <param name="controllerClass">typeof(SomeController);</param>
        /// <param name="methodName">"Edit</param>
        /// <param name="totalAttributeCount"></param>
        /// <param name="isSecondMethod">If you have an Edit Get and an Edit Post, and you are testing the post</param>
        /// <returns>So you can further examine the attribute. For Example ElementAt(0).Roles.ShouldBe("Admin");</returns>
        public IEnumerable<TAttribute> MethodExpectedAttribute<TAttribute>(Type controllerClass, 
            string methodName, 
            int totalAttributeCount,
            bool isSecondMethod = false)
        {
            var controllerMethod = controllerClass.GetMethods().Where(a => a.Name == methodName);
            var element = controllerMethod.ElementAt(isSecondMethod ? 1 : 0);

            var allAttributes = element.GetCustomAttributes(true);
            var expectedAttribute = element.GetCustomAttributes(true).OfType<TAttribute>();

            foreach (var attribute in allAttributes)
            {
                output.WriteLine(attribute.ToString());
            }

            expectedAttribute.Count().ShouldBe(1, $"{typeof(TAttribute)} not found");
            allAttributes.Count().ShouldBe(totalAttributeCount, "No Attributes");

            return expectedAttribute;
        }

        public void ControllerInherits(Type controllerClass, string expectedBaseName)
        {
            var typeInfo = controllerClass.GetTypeInfo();

            typeInfo.BaseType.ShouldNotBe(null);
            typeInfo.BaseType.Name.ShouldBe(expectedBaseName);
        }

        /// <summary>
        /// Through reflection, examines the attributes for a class
        /// </summary>
        /// <param name="controllerClass">typeof(SomeController);</param>
        /// <param name="totalAttributeCount"></param>
        /// <returns></returns>
        public IEnumerable<TAttribute> ClassExpectedAttribute<TAttribute>(Type controllerClass, int totalAttributeCount)
        {
            var typeInfo = controllerClass.GetTypeInfo();
            var allAttributes = typeInfo.GetCustomAttributes(true);
            
            foreach (var o in allAttributes)
            {
                output.WriteLine(o.ToString()); //Output shows 
            }
            allAttributes.Count().ShouldBe(totalAttributeCount, "Total Attribute count wrong");
            var expectedAttribute = typeInfo.GetCustomAttributes(true).OfType<TAttribute>();
            expectedAttribute.Count().ShouldBeGreaterThanOrEqualTo(1, $"{typeof(TAttribute)} not found");

            return expectedAttribute;
        }

    }
}
