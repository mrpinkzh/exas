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

**Assert**
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

### Boolean assertions
```
naruto.ExAssert(n => n.Property(x => x.HasWeapon()).IsTrue()
		 			  .Property(x => x.IsFemale)   .IsFalse());
```
In addition to the built in `IsEqualTo(true)` and `IsEqualTo(false)` it is now possible to use the more specific
assertions `IsTrue()` and `IsFalse()`.
```
Ninja: ( )HasWeapon() = True  (expected: True)
       ( )IsFemale    = False (expected: False)
```

### Integer assertions
Beside the already covered `IsEqualTo(int)` assertion the following exist:
```
naruto.ExAssert(n => n.Property(x => x.Age).IsBiggerThan(25)
                      .Property(x => x.Age).IsSmallerThan(27)
                      .Property(x => x.Age).IsInRange(25, 27));
```
```
Output:
Ninja: ( )Age = 26 (expected: bigger than 25)
       ( )Age = 26 (expected: smaller than 27)
       ( )Age = 26 (expected: between 25 and 27)
```       
