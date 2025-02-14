﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace TunnelVisionLabs.LanguageTypes.SourceGenerator.UnitTests
{
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Testing;
    using Xunit;
    using VerifyCS = TunnelVisionLabs.LanguageTypes.SourceGenerator.UnitTests.Verifiers.CSharpSourceGeneratorVerifier<
        TunnelVisionLabs.LanguageTypes.SourceGenerator.NullableSourceGenerator>;

    public class NullableSourceGeneratorTests
    {
        [Fact]
        public async Task TestTypesGenerated()
        {
            await new VerifyCS.Test
            {
                TestState =
                {
                    ReferenceAssemblies = ReferenceAssemblies.NetStandard.NetStandard20,
                    Sources =
                    {
                    },
                    GeneratedSources =
                    {
                        (typeof(NullableSourceGenerator), "AllowNullAttribute.g.cs", @"// <auto-generated/>

#nullable enable

namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>Specifies that null is allowed as an input even if the corresponding type disallows it.</summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, Inherited = false)]
    internal sealed class AllowNullAttribute : Attribute
    {
    }
}
".ReplaceLineEndings("\r\n")),
                        (typeof(NullableSourceGenerator), "DisallowNullAttribute.g.cs", @"// <auto-generated/>

#nullable enable

namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>Specifies that null is disallowed as an input even if the corresponding type allows it.</summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, Inherited = false)]
    internal sealed class DisallowNullAttribute : Attribute
    {
    }
}
".ReplaceLineEndings("\r\n")),
                        (typeof(NullableSourceGenerator), "MaybeNullAttribute.g.cs", @"// <auto-generated/>

#nullable enable

namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>Specifies that an output may be null even if the corresponding type disallows it.</summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue, Inherited = false)]
    internal sealed class MaybeNullAttribute : Attribute
    {
    }
}
".ReplaceLineEndings("\r\n")),
                        (typeof(NullableSourceGenerator), "NotNullAttribute.g.cs", @"// <auto-generated/>

#nullable enable

namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>Specifies that an output will not be null even if the corresponding type allows it.</summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue, Inherited = false)]
    internal sealed class NotNullAttribute : Attribute
    {
    }
}
".ReplaceLineEndings("\r\n")),
                        (typeof(NullableSourceGenerator), "MaybeNullWhenAttribute.g.cs", @"// <auto-generated/>

#nullable enable

namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>Specifies that when a method returns <see cref=""ReturnValue""/>, the parameter may be null even if the corresponding type disallows it.</summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    internal sealed class MaybeNullWhenAttribute : Attribute
    {
        /// <summary>Initializes the attribute with the specified return value condition.</summary>
        /// <param name=""returnValue"">
        /// The return value condition. If the method returns this value, the associated parameter may be null.
        /// </param>
        public MaybeNullWhenAttribute(bool returnValue) => ReturnValue = returnValue;

        /// <summary>Gets the return value condition.</summary>
        public bool ReturnValue { get; }
    }
}
".ReplaceLineEndings("\r\n")),
                        (typeof(NullableSourceGenerator), "NotNullWhenAttribute.g.cs", @"// <auto-generated/>

#nullable enable

namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>Specifies that when a method returns <see cref=""ReturnValue""/>, the parameter will not be null even if the corresponding type allows it.</summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    internal sealed class NotNullWhenAttribute : Attribute
    {
        /// <summary>Initializes the attribute with the specified return value condition.</summary>
        /// <param name=""returnValue"">
        /// The return value condition. If the method returns this value, the associated parameter will not be null.
        /// </param>
        public NotNullWhenAttribute(bool returnValue) => ReturnValue = returnValue;

        /// <summary>Gets the return value condition.</summary>
        public bool ReturnValue { get; }
    }
}
".ReplaceLineEndings("\r\n")),
                        (typeof(NullableSourceGenerator), "NotNullIfNotNullAttribute.g.cs", @"// <auto-generated/>

#nullable enable

namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>Specifies that the output will be non-null if the named parameter is non-null.</summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue, AllowMultiple = true, Inherited = false)]
    internal sealed class NotNullIfNotNullAttribute : Attribute
    {
        /// <summary>Initializes the attribute with the associated parameter name.</summary>
        /// <param name=""parameterName"">
        /// The associated parameter name.  The output will be non-null if the argument to the parameter specified is non-null.
        /// </param>
        public NotNullIfNotNullAttribute(string parameterName) => ParameterName = parameterName;

        /// <summary>Gets the associated parameter name.</summary>
        public string ParameterName { get; }
    }
}
".ReplaceLineEndings("\r\n")),
                        (typeof(NullableSourceGenerator), "DoesNotReturnAttribute.g.cs", @"// <auto-generated/>

#nullable enable

namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>Applied to a method that will never return under any circumstance.</summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    internal sealed class DoesNotReturnAttribute : Attribute
    {
    }
}
".ReplaceLineEndings("\r\n")),
                        (typeof(NullableSourceGenerator), "DoesNotReturnIfAttribute.g.cs", @"// <auto-generated/>

#nullable enable

namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>Specifies that the method will not return if the associated Boolean parameter is passed the specified value.</summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    internal sealed class DoesNotReturnIfAttribute : Attribute
    {
        /// <summary>Initializes the attribute with the specified parameter value.</summary>
        /// <param name=""parameterValue"">
        /// The condition parameter value. Code after the method will be considered unreachable by diagnostics if the argument to
        /// the associated parameter matches this value.
        /// </param>
        public DoesNotReturnIfAttribute(bool parameterValue) => ParameterValue = parameterValue;

        /// <summary>Gets the condition parameter value.</summary>
        public bool ParameterValue { get; }
    }
}
".ReplaceLineEndings("\r\n")),
                        (typeof(NullableSourceGenerator), "MemberNotNullAttribute.g.cs", @"// <auto-generated/>

#nullable enable

namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>Specifies that the method or property will ensure that the listed field and property members have not-null values.</summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    internal sealed class MemberNotNullAttribute : Attribute
    {
        /// <summary>Initializes the attribute with a field or property member.</summary>
        /// <param name=""member"">
        /// The field or property member that is promised to be not-null.
        /// </param>
        public MemberNotNullAttribute(string member) => Members = new[] { member };

        /// <summary>Initializes the attribute with the list of field and property members.</summary>
        /// <param name=""members"">
        /// The list of field and property members that are promised to be not-null.
        /// </param>
        public MemberNotNullAttribute(params string[] members) => Members = members;

        /// <summary>Gets field or property member names.</summary>
        public string[] Members { get; }
    }
}
".ReplaceLineEndings("\r\n")),
                        (typeof(NullableSourceGenerator), "MemberNotNullWhenAttribute.g.cs", @"// <auto-generated/>

#nullable enable

namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>Specifies that the method or property will ensure that the listed field and property members have not-null values when returning with the specified return value condition.</summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    internal sealed class MemberNotNullWhenAttribute : Attribute
    {
        /// <summary>Initializes the attribute with the specified return value condition and a field or property member.</summary>
        /// <param name=""returnValue"">
        /// The return value condition. If the method returns this value, the associated parameter will not be null.
        /// </param>
        /// <param name=""member"">
        /// The field or property member that is promised to be not-null.
        /// </param>
        public MemberNotNullWhenAttribute(bool returnValue, string member)
        {
            ReturnValue = returnValue;
            Members = new[] { member };
        }

        /// <summary>Initializes the attribute with the specified return value condition and list of field and property members.</summary>
        /// <param name=""returnValue"">
        /// The return value condition. If the method returns this value, the associated parameter will not be null.
        /// </param>
        /// <param name=""members"">
        /// The list of field and property members that are promised to be not-null.
        /// </param>
        public MemberNotNullWhenAttribute(bool returnValue, params string[] members)
        {
            ReturnValue = returnValue;
            Members = members;
        }

        /// <summary>Gets the return value condition.</summary>
        public bool ReturnValue { get; }

        /// <summary>Gets field or property member names.</summary>
        public string[] Members { get; }
    }
}
".ReplaceLineEndings("\r\n")),
                    },
                },
                LanguageVersion = LanguageVersion.CSharp10,
            }.RunAsync();
        }

        [Fact]
        public async Task TestTypesPartiallyGenerated()
        {
            await new VerifyCS.Test
            {
                TestState =
                {
                    ReferenceAssemblies = ReferenceAssemblies.NetStandard.NetStandard21,
                    Sources =
                    {
                    },
                    GeneratedSources =
                    {
                        (typeof(NullableSourceGenerator), "MemberNotNullAttribute.g.cs", @"// <auto-generated/>

#nullable enable

namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>Specifies that the method or property will ensure that the listed field and property members have not-null values.</summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    internal sealed class MemberNotNullAttribute : Attribute
    {
        /// <summary>Initializes the attribute with a field or property member.</summary>
        /// <param name=""member"">
        /// The field or property member that is promised to be not-null.
        /// </param>
        public MemberNotNullAttribute(string member) => Members = new[] { member };

        /// <summary>Initializes the attribute with the list of field and property members.</summary>
        /// <param name=""members"">
        /// The list of field and property members that are promised to be not-null.
        /// </param>
        public MemberNotNullAttribute(params string[] members) => Members = members;

        /// <summary>Gets field or property member names.</summary>
        public string[] Members { get; }
    }
}
".ReplaceLineEndings("\r\n")),
                        (typeof(NullableSourceGenerator), "MemberNotNullWhenAttribute.g.cs", @"// <auto-generated/>

#nullable enable

namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>Specifies that the method or property will ensure that the listed field and property members have not-null values when returning with the specified return value condition.</summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    internal sealed class MemberNotNullWhenAttribute : Attribute
    {
        /// <summary>Initializes the attribute with the specified return value condition and a field or property member.</summary>
        /// <param name=""returnValue"">
        /// The return value condition. If the method returns this value, the associated parameter will not be null.
        /// </param>
        /// <param name=""member"">
        /// The field or property member that is promised to be not-null.
        /// </param>
        public MemberNotNullWhenAttribute(bool returnValue, string member)
        {
            ReturnValue = returnValue;
            Members = new[] { member };
        }

        /// <summary>Initializes the attribute with the specified return value condition and list of field and property members.</summary>
        /// <param name=""returnValue"">
        /// The return value condition. If the method returns this value, the associated parameter will not be null.
        /// </param>
        /// <param name=""members"">
        /// The list of field and property members that are promised to be not-null.
        /// </param>
        public MemberNotNullWhenAttribute(bool returnValue, params string[] members)
        {
            ReturnValue = returnValue;
            Members = members;
        }

        /// <summary>Gets the return value condition.</summary>
        public bool ReturnValue { get; }

        /// <summary>Gets field or property member names.</summary>
        public string[] Members { get; }
    }
}
".ReplaceLineEndings("\r\n")),
                        (typeof(NullableSourceGenerator), "NullableForwarders.g.cs", @"// <auto-generated/>

#nullable enable

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly: TypeForwardedTo(typeof(AllowNullAttribute))]
[assembly: TypeForwardedTo(typeof(DisallowNullAttribute))]
[assembly: TypeForwardedTo(typeof(MaybeNullAttribute))]
[assembly: TypeForwardedTo(typeof(NotNullAttribute))]
[assembly: TypeForwardedTo(typeof(MaybeNullWhenAttribute))]
[assembly: TypeForwardedTo(typeof(NotNullWhenAttribute))]
[assembly: TypeForwardedTo(typeof(NotNullIfNotNullAttribute))]
[assembly: TypeForwardedTo(typeof(DoesNotReturnAttribute))]
[assembly: TypeForwardedTo(typeof(DoesNotReturnIfAttribute))]
".ReplaceLineEndings("\r\n")),
                    },
                },
                LanguageVersion = LanguageVersion.CSharp10,
            }.RunAsync();
        }

        [Fact]
        public async Task TestTypesForwarded()
        {
            await new VerifyCS.Test
            {
                TestState =
                {
                    ReferenceAssemblies = ReferenceAssemblies.Net.Net50,
                    Sources =
                    {
                    },
                    GeneratedSources =
                    {
                        (typeof(NullableSourceGenerator), "NullableForwarders.g.cs", @"// <auto-generated/>

#nullable enable

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly: TypeForwardedTo(typeof(AllowNullAttribute))]
[assembly: TypeForwardedTo(typeof(DisallowNullAttribute))]
[assembly: TypeForwardedTo(typeof(MaybeNullAttribute))]
[assembly: TypeForwardedTo(typeof(NotNullAttribute))]
[assembly: TypeForwardedTo(typeof(MaybeNullWhenAttribute))]
[assembly: TypeForwardedTo(typeof(NotNullWhenAttribute))]
[assembly: TypeForwardedTo(typeof(NotNullIfNotNullAttribute))]
[assembly: TypeForwardedTo(typeof(DoesNotReturnAttribute))]
[assembly: TypeForwardedTo(typeof(DoesNotReturnIfAttribute))]
[assembly: TypeForwardedTo(typeof(MemberNotNullAttribute))]
[assembly: TypeForwardedTo(typeof(MemberNotNullWhenAttribute))]
".ReplaceLineEndings("\r\n")),
                    },
                },
                LanguageVersion = LanguageVersion.CSharp10,
            }.RunAsync();
        }
    }
}
