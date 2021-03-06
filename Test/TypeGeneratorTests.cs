﻿using Csharp2json.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Should;
using Csharp2json.Core;

namespace Test
{
    public class TypeGeneratorTests
    {
        [Fact]
        public void Should_generate_type()
        {
            var result = MakeTypes.From(Source.VALID_CLASS1).First();
            result.Name.ShouldEqual("Test1");
            result.GetProperties().Count().ShouldEqual(2);
        }

        [Fact]
        public void Should_throw_exception_on_syntactical_errors()
        {
            new Action(() => MakeTypes.From(Source.INVALID_CLASS))
            .ShouldThrow<TypeGeneratorException>();
        }

        [Fact]
        public void Handles_multiple_types()
        {
            var result = MakeTypes.From(Source.VALID_CLASS1 + Source.VALID_CLASS2);
            var first = result.First();
            var second = result.Last();

            first.Name.ShouldEqual("Test1");
            second.Name.ShouldEqual("Test2");
        }
    }
}
