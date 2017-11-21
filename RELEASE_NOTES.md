## New in 2.1.1
* adjusted the build script to publish only dated releases

## New in 2.1.0 (Released 2017/11/15)
* extended the has-any enumerable-assertion to support multiple assertions (#59)

## New in 2.0.0 (Released 2017/09/07)
* renamed the has-any and has-none with predicate assertions to has-any-predicate and has-none-predicate (#58)

## New in 1.0.0 (Released 2016/10/15)
* added datetime assertions: is-in-same-year, has-year (#39), has-month (#38), has-day (#37), has-hour (#40), has-minute (#41), has-second (#42)
* added enumerable assertions: starts-with (#46), ends-with (#47), is-subset-of (#48), contains-in-order (#49)

## New in 0.4.0 (Released 2016/05/12)
* added datetime assertions: is-after (#35), is-before (#36)
* added list is-equal assertion (#44)
* added enumerable assertions: has-any (#52), has-none (#53), is-equivalent-to (#45), doesnt-contain-nulls (#50), all-fulfil (#51)
* fixed bug when displaying multiline strings with over 2 lines (#55)

## New in 0.3.0 (Released 2016/04/19)
* renamed the is-bigger-than assertion to is-greater-than (#26)
* renamed the is-smaller-than assertion to is-less-than (#27)
* added comparable is-greater-or-equal-to assertion (#28)
* added comparable is-less-or-equal-to assertion (#29)

## New in 0.2.0 (Released 2016/04/01)
* added string assertions: contains, contains-not, starts-with, starts-not-with, ends-with, ends-not-with
* added some api extensions for static usings
* fixed multiline support for string-assertions #23
* added enumerable-assertions: contains(#24), contains-not(#25)

## New in 0.1.1 (Released 2016/03/01)
* added support for IReadOnlyCollection
* added comparable assertions: is-bigger-than, is-in-range
* added support for nullable integers and nullable booleans
* added enumerable assertion has-count
* added support for timespans
* added common asserton is-instance-of
* added string assertions: is-not-empty, has-length