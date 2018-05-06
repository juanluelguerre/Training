
# Proposal C# 7.3
https://github.com/dotnet/csharplang/tree/master/proposals/csharp-7.3

- [auto-prop-field-attrs](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/auto-prop-field-attrs.md)
- [blittable](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/blittable.md)
- [expression-variables-in-initializers](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/expression-variables-in-initializers.md)
- [improved-overload-candidates](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/improved-overload-candidates.md)
- [indexing-movable-fixed-fields](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/indexing-movable-fixed-fields.md)
- [pattern-based-fixed](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/pattern-based-fixed.md)
- [ref-local-reassignment](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/ref-local-reassignment.md)
- [stackalloc-array-initializers](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/stackalloc-array-initializers.md)
- [tuple-equality](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/tuple-equality.md)


# C# 7.3 (Visual Studio 2017 version 15.7)
- `System.Enum`, `System.Delegate` and [`unmanaged`](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/blittable.md) constraints.
- [Ref local re-assignment](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/ref-local-reassignment.md): Ref locals and ref parameters can now be reassigned with the ref assignment operator (`= ref`).
- [Stackalloc initializers](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/stackalloc-array-initializers.md): Stack-allocated arrays can now be initialized, e.g. `Span<int> x = stackalloc[] { 1, 2, 3 };`.
- [Indexing movable fixed buffers](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/indexing-movable-fixed-fields.md): Fixed buffers can be indexed into without first being pinned.
- [Custom `fixed` statement](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/pattern-based-fixed.md): Types that implement a suitable `GetPinnableReference` can be used in a `fixed` statement.
- [Improved overload candidates](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/improved-overload-candidates.md): Some overload resolution candidates can be ruled out early, thus reducing ambiguities.
- [Expression variables in initializers and queries](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/expression-variables-in-initializers.md): Expression variables like `out var` and pattern variables are allowed in field initializers, constructor initializers and LINQ queries.
-	[Tuple comparison](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/tuple-equality.md): Tuples can now be compared with `==` and `!=`.
-	[Attributes on backing fields](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/auto-prop-field-attrs.md): Allows `[field: …]` attributes on an auto-implemented property to target its backing field.