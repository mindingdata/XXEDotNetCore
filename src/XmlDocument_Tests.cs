using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace XXEExamples.Tests
{
    [TestFixture]
    public class XmlDocument_Tests
    {
        [Test]
        public void XmlDocument_WithDefaults_Safe()
        {
            AssertXXE.IsXMLParserSafe((string xml) =>
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xml);
                return xmlDocument.InnerText;
            }, true);
        }

        [Test]
        public void XMLDocument_WithXMLResolver_NotSafe()
        {
            AssertXXE.IsXMLParserSafe((string xml) =>
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.XmlResolver = new XmlUrlResolver();
                xmlDocument.LoadXml(xml);
                return xmlDocument.InnerText;
            }, false);
        }
    }
}
