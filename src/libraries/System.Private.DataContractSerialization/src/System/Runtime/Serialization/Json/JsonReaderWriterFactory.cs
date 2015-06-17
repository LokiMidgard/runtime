// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.CompilerServices;

#if NET_NATIVE || MERGE_DCJS
namespace System.Runtime.Serialization.Json
{
    internal static class JsonReaderWriterFactory
    {
        private const string DefaultIndentChars = "  ";

        public static XmlDictionaryReader CreateJsonReader(Stream stream, XmlDictionaryReaderQuotas quotas)
        {
            return CreateJsonReader(stream, null, quotas, null);
        }

        public static XmlDictionaryReader CreateJsonReader(byte[] buffer, XmlDictionaryReaderQuotas quotas)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            return CreateJsonReader(buffer, 0, buffer.Length, null, quotas, null);
        }

        public static XmlDictionaryReader CreateJsonReader(Stream stream, Encoding encoding, XmlDictionaryReaderQuotas quotas, OnXmlDictionaryReaderClose onClose)
        {
            XmlJsonReader reader = new XmlJsonReader();
            reader.SetInput(stream, encoding, quotas, onClose);
            return reader;
        }

        public static XmlDictionaryReader CreateJsonReader(byte[] buffer, int offset, int count, XmlDictionaryReaderQuotas quotas)
        {
            return CreateJsonReader(buffer, offset, count, null, quotas, null);
        }

        public static XmlDictionaryReader CreateJsonReader(byte[] buffer, int offset, int count, Encoding encoding, XmlDictionaryReaderQuotas quotas, OnXmlDictionaryReaderClose onClose)
        {
            XmlJsonReader reader = new XmlJsonReader();
            reader.SetInput(buffer, offset, count, encoding, quotas, onClose);
            return reader;
        }

        public static XmlDictionaryWriter CreateJsonWriter(Stream stream)
        {
            return CreateJsonWriter(stream, Encoding.UTF8, true);
        }

        public static XmlDictionaryWriter CreateJsonWriter(Stream stream, Encoding encoding)
        {
            return CreateJsonWriter(stream, encoding, true);
        }

        public static XmlDictionaryWriter CreateJsonWriter(Stream stream, Encoding encoding, bool ownsStream)
        {
            return CreateJsonWriter(stream, encoding, ownsStream, false);
        }

        public static XmlDictionaryWriter CreateJsonWriter(Stream stream, Encoding encoding, bool ownsStream, bool indent)
        {
            return CreateJsonWriter(stream, encoding, ownsStream, indent, JsonReaderWriterFactory.DefaultIndentChars);
        }

        public static XmlDictionaryWriter CreateJsonWriter(Stream stream, Encoding encoding, bool ownsStream, bool indent, string indentChars)
        {
            XmlJsonWriter writer = new XmlJsonWriter(indent, indentChars);
            writer.SetOutput(stream, encoding, ownsStream);
            return writer;
        }
    }
}
#endif
