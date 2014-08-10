namespace Converter.Logic.Test

open Converter.Logic
open NUnit.Framework

(* open FsUnit 
   should operator not work on Mono *)

[<TestFixture>]
type ConverterTest() = 
    let testConv = new Converter()
    
    [<Test>]
    member x.parseTest() = 
        let input = "一"
        let result = testConv.Convert input
        Assert.AreEqual("1", result)
    
    [<Test>]
    member x.parseTest2char() = 
        let input = "五一"
        let result = testConv.Convert input
        Assert.AreEqual("51", result)
    
    [<Test>]
    member x.parseTest2charWithDigit() = 
        let input = "三十七"
        let result = testConv.Convert input
        Assert.AreEqual("37", result)
    
    [<Test>]
    member x.parseTest3char() = 
        let input = "千三十七"
        let result = testConv.Convert input
        Assert.AreEqual("1037", result)
    
    [<Test>]
    member x.parseSingleValue() = 
        let input = "万"
        let result = testConv.Convert input
        Assert.AreEqual("10000", result)
    
    [<Test>]
    member x.parseTest3char2() = 
        let input = "万三二十七"
        let result = testConv.Convert input
        Assert.AreEqual("10327", result)
    
    [<Test>]
    member x.parseTest4() = 
        let input = "二百万千三二七"
        let result = testConv.Convert input
        Assert.AreEqual("2001327", result)
    
    [<Test>]
    member x.parseTest4with() = 
        let input = "二〇一万千三二七"
        let result = testConv.Convert input
        Assert.AreEqual("2011327", result)
    
    [<Test>]
    member x.parseTestRevenge() = 
        let input = "一二三千"
        let result = testConv.Convert input
        Assert.AreEqual("123000", result)
    
    [<Test>]
    member x.parseTestErrorCase() = 
        let input = "万五四三二十七"
        let result = testConv.Convert input
        Assert.AreEqual("1000054327", result)
    
    [<Test>]
    member x.parseTestErrorCase2() = 
        let input = "万億"
        let result = testConv.Convert input
        Assert.AreEqual("10000100000000", result)