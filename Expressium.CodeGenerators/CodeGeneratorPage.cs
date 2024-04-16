﻿using Expressium.Configurations;
using Expressium.ObjectRepositories;
using System.Collections.Generic;

namespace Expressium.CodeGenerators
{
    internal abstract class CodeGeneratorPage : CodeGeneratorObject
    {
        internal CodeGeneratorPage(Configuration configuration, ObjectRepository objectRepository) : base(configuration, objectRepository)
        {
        }

        internal abstract string GetFilePath(ObjectRepositoryPage page);
        internal abstract List<string> GenerateSourceCode(ObjectRepositoryPage page);

        internal override void Generate(ObjectRepositoryPage page)
        {
            var filePath = GetFilePath(page);
            var sourceCode = GenerateSourceCode(page);
            var listOfLines = GetListOfLinesAsFormatted(sourceCode);
            SaveListOfLinesAsFile(filePath, listOfLines);
        }

        internal override string GenerateAsString(ObjectRepositoryPage page)
        {
            var sourceCode = GenerateSourceCode(page);
            var listOfLines = GetListOfLinesAsFormatted(sourceCode);
            return GetListOfLinesAsString(listOfLines);
        }
    }
}
