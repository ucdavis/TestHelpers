using System;
using System.Collections.Generic;
using System.Text;
using SampleTests.Models;
using Shouldly;
using TestHelpers.Helpers;
using Xunit;

namespace SampleTests
{
    [Trait("Category", "Model")]
    public class ModelTest
    {
        [Fact]
        public void ExampleModelFieldsHaveExpectedAttributesPass()
        {
            //List Alphabetically 
            var expectedFields = new List<NameAndType>();
            expectedFields.Add(new NameAndType("AttributeExanple", "System.String", new List<string>{
                "[System.ObsoleteAttribute()]"
            }));
            expectedFields.Add(new NameAndType("Counter", "System.Int32", new List<string>()));
            expectedFields.Add(new NameAndType("Name", "System.String", new List<string>()));


            AttributeAndFieldValidation.ValidateFieldsAndAttributes(expectedFields, typeof(ExampleModel));
        }
        [Fact]
        public void ExampleModelFieldsHaveExpectedAttributesFailMissingField()
        {
            var expectedFields = new List<NameAndType>();
            expectedFields.Add(new NameAndType("AttributeExanple", "System.String", new List<string>{
                "[System.ObsoleteAttribute()]"
            }));
            expectedFields.Add(new NameAndType("Counter", "System.Int32", new List<string>()));
            //expectedFields.Add(new NameAndType("Name", "System.String", new List<string>()));

            Should.Throw<ShouldAssertException>(() =>
            {
                AttributeAndFieldValidation.ValidateFieldsAndAttributes(expectedFields, typeof(ExampleModel));
            })
                .Message.ShouldStartWith("propertyInfos.Count()\n    should be\n2\n    but was\r\n3");
        }

        [Fact]
        public void ExampleModelFieldsHaveExpectedAttributesFailExtraField()
        {
            var expectedFields = new List<NameAndType>();
            expectedFields.Add(new NameAndType("AttributeExanple", "System.String", new List<string>
            {
                "[System.ObsoleteAttribute()]"
            }));
            expectedFields.Add(new NameAndType("Counter", "System.Int32", new List<string>()));
            expectedFields.Add(new NameAndType("Name", "System.String", new List<string>()));
            expectedFields.Add(new NameAndType("Name2", "System.String", new List<string>()));

            Should.Throw<ShouldAssertException>(() =>
                {
                    AttributeAndFieldValidation.ValidateFieldsAndAttributes(expectedFields, typeof(ExampleModel));
                })
                .Message.ShouldStartWith("propertyInfos.Count()\n    should be\n4\n    but was\r\n3");
        }

        [Fact]
        public void ExampleModelFieldsHaveExpectedAttributesFailMissingAttribute()
        {
            var expectedFields = new List<NameAndType>();
            expectedFields.Add(new NameAndType("AttributeExanple", "System.String", new List<string>()));
            expectedFields.Add(new NameAndType("Counter", "System.Int32", new List<string>()));
            expectedFields.Add(new NameAndType("Name", "System.String", new List<string>()));


            Should.Throw<ShouldAssertException>(() =>
                {
                    AttributeAndFieldValidation.ValidateFieldsAndAttributes(expectedFields, typeof(ExampleModel));
                })
                .Message.ShouldStartWith("foundAttributes.Count()\n    should be\n0\n    but was\r\n1");
        }

        [Fact]
        public void ExampleModelFieldsHaveExpectedAttributesFailAttributeWrong()
        {
            var expectedFields = new List<NameAndType>();
            expectedFields.Add(new NameAndType("AttributeExanple", "System.String", new List<string>{
                "Not right"
            }));
            expectedFields.Add(new NameAndType("Counter", "System.Int32", new List<string>()));
            expectedFields.Add(new NameAndType("Name", "System.String", new List<string>()));


            Should.Throw<ShouldAssertException>(() =>
                {
                    AttributeAndFieldValidation.ValidateFieldsAndAttributes(expectedFields, typeof(ExampleModel));
                })
                .Message.ShouldContain("should be\n\"Not right\"\n    but was");
        }

        [Fact]
        public void ExampleModelFieldsHaveExpectedAttributesFailExtraAttribute()
        {
            var expectedFields = new List<NameAndType>();
            expectedFields.Add(new NameAndType("AttributeExanple", "System.String", new List<string>
            {
                "[System.ObsoleteAttribute()]",
                "[System.AAA()]"
            }));
            expectedFields.Add(new NameAndType("Counter", "System.Int32", new List<string>()));
            expectedFields.Add(new NameAndType("Name", "System.String", new List<string>()));

            Should.Throw<ShouldAssertException>(() =>
                {
                    AttributeAndFieldValidation.ValidateFieldsAndAttributes(expectedFields, typeof(ExampleModel));
                })
                .Message.ShouldStartWith("foundAttributes.Count()\n    should be\n2\n    but was\r\n1");
        }

    }
}
