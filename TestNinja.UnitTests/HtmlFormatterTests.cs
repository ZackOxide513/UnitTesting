﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        private HtmlFormatter _htmlFormatter;

        [SetUp]
        public void SetUp()
        {
            _htmlFormatter = new HtmlFormatter();
        }

        [Test]
        public void FormatAsBold_WhenCalled_EncloseStringWithStrongElement()
        {
            var result = _htmlFormatter.FormatAsBold("abc");

            // Specific
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

            // More General
            //Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            //Assert.That(result, Does.EndWith("</strong>").IgnoreCase);
            //Assert.That(result, Does.Contain("abc").IgnoreCase);

        }
    }
}
