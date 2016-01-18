# exas

means Extended Assertions.

Often when testing legacy code on an integration testing level, we deal with complex data contracts.
The assertion of the correctness of this complexer data it is often cumbersome when done with individual assert statements.

Extended Assertions might help in those cases.

## Syntax

The following statement is evaluated once.
```
ninja.ExAssert(n => n.Property(x => x.Age) .IsEqualTo(12)
                     .Property(x => x.Name).IsEqualTo("Naruto));
```

An invalid result returns the following statement:
```
ExAs.ExtendedAssertionException:
Ninja: (X)Age  = 26        (expected: 12)
       (X)Name = 'Kakashi' (expected: 'Naruto')
```

## Assertions

```
dojo.ExAssert(d => d.Property(x => x.Name)  .IsNotNull()
				   d.Property(x => x.Master).FullFills(n => n.Property(x => x.Name).IsNull()
														     .Property(x => x.Age) .IsEqualTo(109)));
```
The assertions `IsNotNull()`, `IsNull()` and `IsEqualTo(int)` are applicable to each reference type.

**Output**
```
Dojo: ( )Name   = 'Takahashis Dojo'			   (expected: not null)
	  (X)Master = Ninja: (X)Name = 'Takahashi' (expected: null)
						 (X)Age  = 26		   (expected: 109)
```
