using System.Text.RegularExpressions;
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

            Assert.Matches(@"propertyInfos.Count\(\)\s+should be\s+2\s+but was\s+3", 
                Should.Throw<ShouldAssertException>(() =>
                {
                    AttributeAndFieldValidation.ValidateFieldsAndAttributes(expectedFields, typeof(ExampleModel));
                }).Message);
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

            Assert.Matches(@"propertyInfos.Count\(\)\s+should be\s+4\s+but was\s+3", 
                Should.Throw<ShouldAssertException>(() =>
                {
                    AttributeAndFieldValidation.ValidateFieldsAndAttributes(expectedFields, typeof(ExampleModel));
                }).Message);
        }

        [Fact]
        public void ExampleModelFieldsHaveExpectedAttributesFailMissingAttribute()
        {
            var expectedFields = new List<NameAndType>();
            expectedFields.Add(new NameAndType("AttributeExanple", "System.String", new List<string>()));
            expectedFields.Add(new NameAndType("Counter", "System.Int32", new List<string>()));
            expectedFields.Add(new NameAndType("Name", "System.String", new List<string>()));

            Assert.Matches(@"foundAttributes.Count\(\)\s+should be\s+0\s+but was\s+1", 
                Should.Throw<ShouldAssertException>(() =>
                {
                    AttributeAndFieldValidation.ValidateFieldsAndAttributes(expectedFields, typeof(ExampleModel));
                }).Message);
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

            Assert.Matches(@"should be\s+\""Not right\""\s+but was",
                Should.Throw<ShouldAssertException>(() =>
                {
                    AttributeAndFieldValidation.ValidateFieldsAndAttributes(expectedFields, typeof(ExampleModel));
                }).Message);
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

            Assert.Matches(@"foundAttributes.Count\(\)\s+should be\s+2\s+but was\s+1.*",
                Should.Throw<ShouldAssertException>(() =>
                {
                    AttributeAndFieldValidation.ValidateFieldsAndAttributes(expectedFields, typeof(ExampleModel));
                }).Message);
        }

    }
}
