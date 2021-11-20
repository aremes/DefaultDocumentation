﻿using System.Linq;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class TitleSectionTest : ASectionTest<TitleSection>
    {
        protected override GeneratedPages GetGeneratedPages() =>
            GeneratedPages.Assembly
            | GeneratedPages.Namespaces
            | GeneratedPages.Types
            | GeneratedPages.Members;

        [Fact]
        public void Name_should_be_Title() => Check.That(Name).IsEqualTo("Title");

        [Fact]
        public void Write_should_not_write_When_unknown_DocItem() => Test(
            string.Empty);

        [Fact]
        public void Write_should_write_When_AssemblyDocItem() => Test(
            AssemblyInfo.AssemblyDocItem,
            "## Test Assembly");

        [Fact]
        public void Write_should_write_When_NamespaceDocItem() => Test(
            AssemblyInfo.NamespaceDocItem,
            "## DefaultDocumentation Namespace");

        [Fact]
        public void Write_should_write_When_TypeDocItem() => Test(
            AssemblyInfo.ClassDocItem,
            "## AssemblyInfo Class");

        [Fact]
        public void Write_should_write_When_ConstructorDocItem() => Test(
            AssemblyInfo.ConstructorDocItem,
            "## AssemblyInfo() Constructor");

        [Fact]
        public void Write_should_write_When_EventDocItem() => Test(
            AssemblyInfo.EventDocItem,
            "## AssemblyInfo.Event Event");

        [Fact]
        public void Write_should_write_When_FieldDocItem() => Test(
            AssemblyInfo.FieldDocItem,
            "## AssemblyInfo._field Field");

        [Fact]
        public void Write_should_write_When_MethodDocItem() => Test(
            AssemblyInfo.MethodWithParameterDocItem,
            "## AssemblyInfo.MethodWithParameter(int) Method");

        [Fact]
        public void Write_should_write_When_OperatorDocItem() => Test(
            AssemblyInfo.OperatorDocItem,
            "## AssemblyInfo.operator +(AssemblyInfo, int) Operator");

        [Fact]
        public void Write_should_write_When_PropertyDocItem() => Test(
            AssemblyInfo.PropertyDocItem,
            "## AssemblyInfo.Property Property");

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem_and_event() => Test(
            AssemblyInfo.ExplicitEventDocItem,
            "## AssemblyInfo.DefaultDocumentation.AssemblyInfo.IInterface.Event Event");

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem_and_property() => Test(
            AssemblyInfo.ExplicitPropertyDocItem,
            "## AssemblyInfo.DefaultDocumentation.AssemblyInfo.IInterface.Property Property");

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem_and_method() => Test(
            AssemblyInfo.ExplicitMethodDocItem,
            "## AssemblyInfo.DefaultDocumentation.AssemblyInfo.IInterface.Method() Method");

        [Fact]
        public void Write_should_write_When_EnumFieldDocItem() => Test(
            AssemblyInfo.EnumFieldDocItem,
@"<a name='Value'></a>

`Value` 0");

        [Fact]
        public void Write_should_write_When_EnumFieldDocItem_and_constant_value() => Test(
            AssemblyInfo.EnumFieldWithConstantDocItem,
@"<a name='ValueWithConstant'></a>

`ValueWithConstant` 42");

        [Fact]
        public void Write_should_write_When_ParameterDocItem() => Test(
            AssemblyInfo.MethodWithParameterDocItem.Parameters.Single(),
@"<a name='parameter'></a>

`parameter` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')");

        [Fact]
        public void Write_should_write_When_TypeParameterDocItem() => Test(
            AssemblyInfo.ClassWithTypeParameterDocItem.TypeParameters.Single(),
@"<a name='T'></a>

`T`");
    }
}
