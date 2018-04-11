using System;
using System.Collections.Generic;
using System.Text;
using SampleTests.Models;
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


            AttributeAndFieldValidation.ValidateFieldsAndAttributes(expectedFields, typeof(ExampleModel));
        }

        [Fact]
        public void ExampleModelFieldsHaveExpectedAttributesFailExtraField()
        {
            var expectedFields = new List<NameAndType>();
            expectedFields.Add(new NameAndType("AttributeExanple", "System.String", new List<string>{
                "[System.ObsoleteAttribute()]"
            }));
            expectedFields.Add(new NameAndType("Counter", "System.Int32", new List<string>()));
            expectedFields.Add(new NameAndType("Name", "System.String", new List<string>()));
            expectedFields.Add(new NameAndType("Name2", "System.String", new List<string>()));

            AttributeAndFieldValidation.ValidateFieldsAndAttributes(expectedFields, typeof(ExampleModel));
        }

        [Fact]
        public void ExampleModelFieldsHaveExpectedAttributesFailMissingAttribute()
        {
            var expectedFields = new List<NameAndType>();
            expectedFields.Add(new NameAndType("AttributeExanple", "System.String", new List<string>()));
            expectedFields.Add(new NameAndType("Counter", "System.Int32", new List<string>()));
            expectedFields.Add(new NameAndType("Name", "System.String", new List<string>()));


            AttributeAndFieldValidation.ValidateFieldsAndAttributes(expectedFields, typeof(ExampleModel));
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


            AttributeAndFieldValidation.ValidateFieldsAndAttributes(expectedFields, typeof(ExampleModel));
        }
    }
}
