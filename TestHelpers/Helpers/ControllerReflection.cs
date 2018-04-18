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
        public Type ControllerClass;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        /// <param name="controllerClass">typeof(SomeController)</param>
        public ControllerReflection(ITestOutputHelper output, Type controllerClass)
        {
            this.output = output;
            ControllerClass = controllerClass;
        }

        /// <summary>
        /// Through reflection, examines the attributes for a method
        /// </summary>
        /// <param name="methodName">"Edit</param>
        /// <param name="totalAttributeCount"></param>
        /// <param name="testMessage">If passed, shows on output</param>
        /// <param name="isSecondMethod">If you have an Edit Get and an Edit Post, and you are testing the post</param>
        /// <param name="showListOfAttributes"></param>
        /// <returns>So you can further examine the attribute. For Example ElementAt(0).Roles.ShouldBe("Admin");</returns>
        public IEnumerable<TAttribute> MethodExpectedAttribute<TAttribute>(string methodName, int totalAttributeCount, string testMessage = null, bool isSecondMethod = false, bool showListOfAttributes = true)
        {
            if (!string.IsNullOrWhiteSpace(testMessage))
            {
                output.WriteLine(testMessage);
            }
            var controllerMethod = ControllerClass.GetMethods().Where(a => a.Name == methodName);
            var element = controllerMethod.ElementAt(isSecondMethod ? 1 : 0);

            var allAttributes = element.GetCustomAttributes(true);
            var expectedAttribute = element.GetCustomAttributes(true).OfType<TAttribute>();
            if (showListOfAttributes)
            {
                foreach (var attribute in allAttributes)
                {
                    output.WriteLine(attribute.ToString());
                }
            }

            expectedAttribute.Count().ShouldBe(1, $"{typeof(TAttribute)} attribute not found (for) {testMessage}");
            allAttributes.Count().ShouldBe(totalAttributeCount, $"Total Attribute count wrong (for) {testMessage}");

            return expectedAttribute;
        }

        public void ControllerInherits(string expectedBaseName, string testMessage = null)
        {
            if (!string.IsNullOrWhiteSpace(testMessage))
            {
                output.WriteLine(testMessage);
            }
            var typeInfo = ControllerClass.GetTypeInfo();

            typeInfo.BaseType.ShouldNotBe(null);
            typeInfo.BaseType.Name.ShouldBe(expectedBaseName);
        }

        /// <summary>
        /// Through reflection, examines the attributes for a class
        /// </summary>
        /// <param name="totalAttributeCount"></param>
        /// <param name="testMessage"></param>
        /// <param name="showListOfAttributes"></param>
        /// <returns></returns>
        public IEnumerable<TAttribute> ClassExpectedAttribute<TAttribute>(int totalAttributeCount, string testMessage = null, bool showListOfAttributes = true)
        {
            if (!string.IsNullOrWhiteSpace(testMessage))
            {
                output.WriteLine(testMessage);
            }
            var typeInfo = ControllerClass.GetTypeInfo();
            var allAttributes = typeInfo.GetCustomAttributes(true);
            if (showListOfAttributes)
            {
                foreach (var o in allAttributes)
                {
                    output.WriteLine(o.ToString()); //Output shows 
                }
            }

            allAttributes.Count().ShouldBe(totalAttributeCount, $"Total Attribute count wrong (for) {testMessage}");
            var expectedAttribute = typeInfo.GetCustomAttributes(true).OfType<TAttribute>();
            expectedAttribute.Count().ShouldBeGreaterThanOrEqualTo(1, $"{typeof(TAttribute)} not found (for) {testMessage}");

            return expectedAttribute;
        }

    }
}
