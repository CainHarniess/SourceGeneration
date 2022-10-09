//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Microsoft.CodeAnalysis.Text;
//using SourceGen.Generators.AutoBuilder.Inspection;
//using SourceGen.Generators.AutoBuilder.Writers;
//using System.Diagnostics;
//using System.Text;

//namespace SourceGen.Generators.AutoBuilder
//{
//    [Generator]
//    public class AutoBuilderGenerator : ISourceGenerator
//    {
//        private ToolInfo _toolInfo = new ToolInfo("ModelBuilderGenerator", "0.0.1");

//        public void Execute(GeneratorExecutionContext context)
//        {
//            SyntaxTree[] syntaxTrees = context.GetAllSyntaxTrees();

//            for (int i = 0; i < syntaxTrees.Length; i++)
//            {
//                TypeDeclarationSyntax[] buildables = syntaxTrees[i].GetDescendantAutoBuilderTypeNodes();
//                if (buildables.Length == 0)
//                {
//                    continue;
//                }

//                foreach (TypeDeclarationSyntax buildable in buildables)
//                {
//                    SourceGenerationResult result = GenerateBuilderClassFile(context, buildable);
//                    context.AddSource(result.FileName, result.SourceText);
//                }
//            }
//        }

//        public void Initialize(GeneratorInitializationContext context)
//        {
//#if DEBUG
//            //if (!Debugger.IsAttached)
//            //{
//            //    Debugger.Launch();
//            //}
//#endif
//        }

//        private SourceGenerationResult GenerateBuilderClassFile(GeneratorExecutionContext context, TypeDeclarationSyntax buildable)
//        {
//            ModelBuilderTypeSyntaxInspector typeSyntaxInspector = GetTypeSyntaxInspector();
//            ModelBuilderInfo builderTypeInfo = typeSyntaxInspector.Inspect(buildable);

//            StringBuilder sb = new();
//            AppendUsingStatements(sb);

//            ModelBuilderClassWriter classWriter = GetClassWriter(sb);
//            classWriter.Append(builderTypeInfo);

//            string fileName = $"{buildable.Identifier}Builder.g.cs";
//            string source = sb.ToString();
//            return new SourceGenerationResult(fileName, source);
//        }

//        private ModelBuilderTypeSyntaxInspector GetTypeSyntaxInspector()
//        {
//            ModelBuilderPropertySyntaxInspector propertySyntaxInspector = new();
//            return new ModelBuilderTypeSyntaxInspector(propertySyntaxInspector);
//        }

//        private ModelBuilderClassWriter GetClassWriter(StringBuilder sb)
//        {
//            MemberDeclarationWriter memberWriter = new(sb);
//            WithMethodWriter withMethodWriter = new(sb);
//            BuildMethodWriter buildMethodWriter = new(sb);
//            return new ModelBuilderClassWriter(sb, memberWriter, withMethodWriter, buildMethodWriter, _toolInfo);
//        }

//        private void AppendUsingStatements(StringBuilder sb)
//        {
//            sb.AppendLine("using System.CodeDom.Compiler;");
//            sb.AppendLine("using SourceGen.Core;\r\n");
//        }
//    }
//}

