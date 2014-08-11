namespace Converter.Logic.Test

open Converter.Logic
open Microsoft.VisualStudio.TestTools.UnitTesting

(* open FsUnit 
   should operator not work on Mono *)

[<TestClass>]
type ConverterTest() = 
    let testConv = new Converter()
    
    [<TestMethod>]
    member x.parseTest() = 
        let input = "一"
        let result = testConv.Convert input
        Assert.AreEqual("1", result)
    
    [<TestMethod>]
    member x.parseTest2char() = 
        let input = "五一"
        let result = testConv.Convert input
        Assert.AreEqual("51", result)
    
    [<TestMethod>]
    member x.parseTest2charWithDigit() = 
        let input = "三十七"
        let result = testConv.Convert input
        Assert.AreEqual("37", result)
    
    [<TestMethod>]
    member x.parseTest3char() = 
        let input = "千三十七"
        let result = testConv.Convert input
        Assert.AreEqual("1037", result)
    
    [<TestMethod>]
    member x.parseSingleValue() = 
        let input = "万"
        let result = testConv.Convert input
        Assert.AreEqual("10000", result)
    
    [<TestMethod>]
    member x.parseTest3char2() = 
        let input = "万三二十七"
        let result = testConv.Convert input
        Assert.AreEqual("10327", result)
    
    [<TestMethod>]
    member x.parseTest4() = 
        let input = "二百万千三二七"
        let result = testConv.Convert input
        Assert.AreEqual("2001327", result)
    
    [<TestMethod>]
    member x.parseTest4with() = 
        let input = "二〇一万千三二七"
        let result = testConv.Convert input
        Assert.AreEqual("2011327", result)
    
    [<TestMethod>]
    member x.parseTestRevenge() = 
        let input = "一二三千"
        let result = testConv.Convert input
        Assert.AreEqual("123000", result)
    
    [<TestMethod>]
    member x.parseTestErrorCase() = 
        let input = "万五四三二十七"
        let result = testConv.Convert input
        Assert.AreEqual("1000054327", result)
    
    [<TestMethod>]
    member x.parseTestErrorCase2() = 
        let input = "万億"
        let result = testConv.Convert input
        Assert.AreEqual("10000100000000", result)

    [<TestMethod>]
    member x.standard_test() =
        let s = testConv.ConvertWidth "一億"
        Assert.AreEqual("１００００００００", s)
    

    [<TestMethod>]
    member x.standard_test2() =
        let s = testConv.ConvertWidth "五億"
        Assert.AreEqual("５００００００００", s)
    

    [<TestMethod>]
    member x.all_low_number_1() =
        let s = testConv.ConvertWidth "二"
        Assert.AreEqual("２", s)
    

    [<TestMethod>]
    member x.all_low_number_2() =
        let s = testConv.ConvertWidth "十二"
        Assert.AreEqual("１２", s)
    

    [<TestMethod>]
    member x.all_low_number_2d() =
        let s = testConv.ConvertWidth "一二"
        Assert.AreEqual("１２", s)
    

    [<TestMethod>]
    member x.all_low_number_3() =
        let s = testConv.ConvertWidth "二百"
        Assert.AreEqual("２００", s)
    

    [<TestMethod>]
    member x.all_low_number_3_() =
        let s = testConv.ConvertWidth "二〇〇"
        Assert.AreEqual("２００", s)
    

    [<TestMethod>]
    member x.all_low_number_4() =
        let s = testConv.ConvertWidth "百二"
        Assert.AreEqual("１０２", s)
    

    [<TestMethod>]
    member x.all_low_number_4_() =
        let s = testConv.ConvertWidth "四〇二"
        Assert.AreEqual("４０２", s)
    

    [<TestMethod>]
    member x.all_low_number_4__() =
        let s = testConv.ConvertWidth "四千十"
        Assert.AreEqual("４０１０", s)
    

    [<TestMethod>]
    member x.all_low_number_4_1() =
        let s = testConv.ConvertWidth "四千百"
        Assert.AreEqual("４１００", s)
    

    [<TestMethod>]
    member x.all_low_number_4_2() =
        let s = testConv.ConvertWidth "四千百十"
        Assert.AreEqual("４１１０", s)
    

    [<TestMethod>]
    member x.all_low_number_4_3() =
        let s = testConv.ConvertWidth "四千百十一"
        Assert.AreEqual("４１１１", s)
    
    [<TestMethod>]
    member x.all_low_number_5() =
        let s = testConv.ConvertWidth "五百二"
        Assert.AreEqual("５０２", s)
    

    [<TestMethod>]
    member x.all_low_number_6() =
        let s = testConv.ConvertWidth "五百三十二"
        Assert.AreEqual("５３２", s)
    

    [<TestMethod>]
    member x.all_low_number_7() =
        let s = testConv.ConvertWidth "千五百三十二"
        Assert.AreEqual("１５３２", s)
    

    [<TestMethod>]
    member x.all_low_number_7_() =
        // Error Case
        let s = testConv.ConvertWidth "三五百三十二"
        // Assert.AreEqual("３５１３２", s)
        Assert.AreEqual("３５３２", s)
    

    [<TestMethod>]
    member x.all_low_number_8() =
        let s = testConv.ConvertWidth "四千五百三十二"
        Assert.AreEqual("４５３２", s)
    

    [<TestMethod>]
    member x.all_low_number_9() =
        let s = testConv.ConvertWidth "四五三二"
        Assert.AreEqual("４５３２", s)
    

    [<TestMethod>]
    member x.all_low_number_10() =
        let s = testConv.ConvertWidth "四千三二"
        Assert.AreEqual("４０３２", s)
    

    [<TestMethod>]
    member x.high_number_1() =
        let s = testConv.ConvertWidth "一万"
        Assert.AreEqual("１００００", s)
    

    [<TestMethod>]
    member x.high_number_2() =
        let s = testConv.ConvertWidth "二一万"
        Assert.AreEqual("２１００００", s)
    

    [<TestMethod>]
    member x.high_number_3() =
        let s = testConv.ConvertWidth "二百一万"
        Assert.AreEqual("２０１００００", s)
    

    [<TestMethod>]
    member x.high_number_4() =
        let s = testConv.ConvertWidth "四千二百一万"
        Assert.AreEqual("４２０１００００", s)
    

    [<TestMethod>]
    member x.high_number_5() =
        let s = testConv.ConvertWidth "二億四千二百一万"
        Assert.AreEqual("２４２０１００００", s)
    

    [<TestMethod>]
    member x.high_number_6() =
        let s = testConv.ConvertWidth "八兆三二〇億四千二百一万"
        Assert.AreEqual("８０３２０４２０１００００", s)
    

    [<TestMethod>]
    member x.high_number_7() =
        let s = testConv.ConvertWidth "八兆三百二十億四千二百一万"
        Assert.AreEqual("８０３２０４２０１００００", s)
    

    [<TestMethod>]
    member x.high_number_8() =
        let s = testConv.ConvertWidth "八一四兆三百二十億四千二百一万"
        Assert.AreEqual("８１４０３２０４２０１００００", s)

    [<TestMethod>]
    member x.high_number_9() =
        let s = testConv.ConvertWidth "八一四兆一四一八億四千二百一万"
        Assert.AreEqual("８１４１４１８４２０１００００", s)
    

    [<TestMethod>]
    member x.high_number_10() =
        let s = testConv.ConvertWidth "八一四兆一四一八億四千二百一万七三"
        Assert.AreEqual("８１４１４１８４２０１００７３", s)
    

    [<TestMethod>]
    member x.high_number_11() =
        let s = testConv.ConvertWidth "八一四兆一四一八億四千二百一万七百五十三"
        Assert.AreEqual("８１４１４１８４２０１０７５３", s)
    

    [<TestMethod>]
    member x.high_number_LongLimit() =
        let s = testConv.ConvertWidth "八千七〇〇兆三百二十億四千二百一万"
        Assert.AreEqual("８７０００３２０４２０１００００", s)
    

    [<TestMethod>]
    member x.usecase_test_1() =
        let s = testConv.ConvertWidth "一千万"
        Assert.AreEqual("１０００００００", s)
    

    [<TestMethod>]
    member x.usecase_test_2() =
        let s = testConv.ConvertWidth "二千万"
        Assert.AreEqual("２０００００００", s)
    

    [<TestMethod>]
    member x.usecase_test_3() =
        let s = testConv.ConvertWidth "五千万"
        Assert.AreEqual("５０００００００", s)
    

    [<TestMethod>]
    member x.Enable_Char1() =
        let s = testConv.ConvertWidth "一"
        Assert.AreEqual("１", s)
        s = testConv.ConvertWidth "壱"
        Assert.AreEqual("１", s)
    

    [<TestMethod>]
    member x.Enable_Char2() =
        let s = testConv.ConvertWidth "二"
        Assert.AreEqual("２", s)
        s = testConv.ConvertWidth "弐"
        Assert.AreEqual("２", s)
    

    [<TestMethod>]
    member x.Enable_Char3() =
        let s = testConv.ConvertWidth "三"
        Assert.AreEqual("３", s)
        s = testConv.ConvertWidth "参"
        Assert.AreEqual("３", s)
    

    [<TestMethod>]
    member x.Enable_Char4() =
        let s = testConv.ConvertWidth "四"
        Assert.AreEqual("４", s)
    

    [<TestMethod>]
    member x.Enable_Char5() =
        let s = testConv.ConvertWidth "五"
        Assert.AreEqual("５", s)
        s = testConv.ConvertWidth "伍"
        Assert.AreEqual("５", s)
    

    [<TestMethod>]
    member x.Enable_Char6() =
        let s = testConv.ConvertWidth "六"
        Assert.AreEqual("６", s)
    

    [<TestMethod>]
    member x.Enable_Char7() =
        let s = testConv.ConvertWidth "七"
        Assert.AreEqual("７", s)
    

    [<TestMethod>]
    member x.Enable_Char8() =
        let s = testConv.ConvertWidth "八"
        Assert.AreEqual("８", s)
    

    [<TestMethod>]
    member x.Enable_Char9() =
        let s = testConv.ConvertWidth "九"
        Assert.AreEqual("９", s)
    

    [<TestMethod>]
    member x.Enable_Char10() =
        let s = testConv.ConvertWidth "十"
        Assert.AreEqual("１０", s)  

    [<TestMethod>]
    member x.Enable_Char100() =
        let s = testConv.ConvertWidth "百"
        Assert.AreEqual("１００", s)
    

    [<TestMethod>]
    member x.Enable_Char1000() =
        let s = testConv.ConvertWidth "千"
        Assert.AreEqual("１０００", s)
    

    [<TestMethod>]
    member x.Enable_Char10000() =
        let s = testConv.ConvertWidth "万"
        Assert.AreEqual("１００００", s)    

    [<TestMethod>]
    member x.Enable_Char100000000() =
        let s = testConv.ConvertWidth "億"
        Assert.AreEqual("１００００００００", s)
    

    [<TestMethod>]
    member x.Enable_Char1000000000000() =
        let s = testConv.ConvertWidth "兆"
        Assert.AreEqual("１００００００００００００", s)
    

    [<TestMethod>]
    member x.Enable_Char0() =
        let s = testConv.ConvertWidth "〇"
        Assert.AreEqual("０", s)
    

    [<TestMethod>]
    member x.invalid_number_1() =
        let s = testConv.ConvertWidth "三十二百"
        Assert.AreEqual("３２１００", s)
    

    [<TestMethod>]
    member x.invalid_number_2() =
        let s = testConv.ConvertWidth "百万億"
        Assert.AreEqual("１００００００１００００００００", s)
    

    [<TestMethod>]
    member x.invalid_number_3() =
        let s = testConv.ConvertWidth "一億五万六千万"
        Assert.AreEqual("１０００５６０００１００００", s)
    

    [<TestMethod>]
    member x.invalid_number_4() =
        let s = testConv.ConvertWidth "一十"
        Assert.AreEqual("１０", s)
    

    [<TestMethod>]
    member x.invalid_number_5() =
        let s = testConv.ConvertWidth "十十"
        Assert.AreEqual("１０１０", s)
    

    [<TestMethod>]
    member x.invalid_number_6() =
        let s = testConv.ConvertWidth "一百"
        Assert.AreEqual("１００", s)
    

    [<TestMethod>]
    member x.invalid_number_7() =
        let s = testConv.ConvertWidth "十百"
        Assert.AreEqual("１０１００", s)
    

    [<TestMethod>]
    member x.invalid_number_8() =
        let s = testConv.ConvertWidth "百百"
        Assert.AreEqual("１００１００", s)
    

    [<TestMethod>]
    member x.invalid_number_9() =
        let s = testConv.ConvertWidth "一千"
        Assert.AreEqual("１０００", s)
    

    [<TestMethod>]
    member x.invalid_number_10() =
        let s = testConv.ConvertWidth "十千"
        Assert.AreEqual("１０１０００", s)
    

    [<TestMethod>]
    member x.invalid_number_11() =
        let s = testConv.ConvertWidth "百千"
        Assert.AreEqual("１００１０００", s)
    

    [<TestMethod>]
    member x.invalid_number_12() =
        let s = testConv.ConvertWidth "千千"
        Assert.AreEqual("１０００１０００", s)
    

    [<TestMethod>]
    member x.invalid_number_13() =
        let s = testConv.ConvertWidth "一十五"
        Assert.AreEqual("１５", s)
    

    [<TestMethod>]
    member x.invalid_number_14() =
        let s = testConv.ConvertWidth "十十五"
        Assert.AreEqual("１０１５", s)
    

    [<TestMethod>]
    member x.invalid_number_15() =
        let s = testConv.ConvertWidth "一百五"
        Assert.AreEqual("１０５", s)
    

    [<TestMethod>]
    member x.invalid_number_16() =
        let s = testConv.ConvertWidth "十百五"
        Assert.AreEqual("１０１０５", s)
    

    [<TestMethod>]
    member x.invalid_number_17() =
        let s = testConv.ConvertWidth "百百五"
        Assert.AreEqual("１００１０５", s)
    

    [<TestMethod>]
    member x.invalid_number_18() =
        let s = testConv.ConvertWidth "一千五"
        Assert.AreEqual("１００５", s)
    

    [<TestMethod>]
    member x.invalid_number_19() =
        let s = testConv.ConvertWidth "十千五"
        Assert.AreEqual("１０１００５", s)
    

    [<TestMethod>]
    member x.invalid_number_20() =
        let s = testConv.ConvertWidth "百千五"
        Assert.AreEqual("１００１００５", s)
    

    [<TestMethod>]
    member x.invalid_number_21() =
        let s = testConv.ConvertWidth "千千五"
        Assert.AreEqual("１０００１００５", s)
    

    [<TestMethod>]
    member x.invalid_number_22() =
        let s = testConv.ConvertWidth "一十万"
        Assert.AreEqual("１０００００", s)
    

    [<TestMethod>]
    member x.invalid_number_23() =
        let s = testConv.ConvertWidth "十十万"
        Assert.AreEqual("１０１０００００", s)
    

    [<TestMethod>]
    member x.invalid_number_24() =
        let s = testConv.ConvertWidth "一百万"
        Assert.AreEqual("１００００００", s)
    

    [<TestMethod>]
    member x.invalid_number_25() =
        let s = testConv.ConvertWidth "十百万"
        Assert.AreEqual("１０１００００００", s)
    

    [<TestMethod>]
    member x.invalid_number_26() =
        let s = testConv.ConvertWidth "百百万"
        Assert.AreEqual("１００１００００００", s)
    

    [<TestMethod>]
    member x.invalid_number_27() =
        let s = testConv.ConvertWidth "一千万"
        Assert.AreEqual("１０００００００", s)
    

    [<TestMethod>]
    member x.invalid_number_28() =
        let s = testConv.ConvertWidth "十千万"
        Assert.AreEqual("１０１０００００００", s)
    

    [<TestMethod>]
    member x.invalid_number_29() =
        let s = testConv.ConvertWidth "百千万"
        Assert.AreEqual("１００１０００００００", s)
    

    [<TestMethod>]
    member x.invalid_number_30() =
        let s = testConv.ConvertWidth "千千万"
        Assert.AreEqual("１０００１０００００００", s)
    

    [<TestMethod>]
    member x.invalid_number_31() =
        let s = testConv.ConvertWidth "一十万五"
        Assert.AreEqual("１００００５", s)
    

    [<TestMethod>]
    member x.invalid_number_32() =
        let s = testConv.ConvertWidth "十十万五"
        Assert.AreEqual("１０１００００５", s)
    

    [<TestMethod>]
    member x.invalid_number_33() =
        let s = testConv.ConvertWidth "一百万五"
        Assert.AreEqual("１０００００５", s)
    

    [<TestMethod>]
    member x.invalid_number_34() =
        let s = testConv.ConvertWidth "十百万五"
        Assert.AreEqual("１０１０００００５", s)
    

    [<TestMethod>]
    member x.invalid_number_35() =
        let s = testConv.ConvertWidth "百百万五"
        Assert.AreEqual("１００１０００００５", s)
    

    [<TestMethod>]
    member x.invalid_number_36() =
        let s = testConv.ConvertWidth "一千万五"
        Assert.AreEqual("１００００００５", s)
    

    [<TestMethod>]
    member x.invalid_number_37() =
        let s = testConv.ConvertWidth "十千万五"
        Assert.AreEqual("１０１００００００５", s)
    

    [<TestMethod>]
    member x.invalid_number_38() =
        let s = testConv.ConvertWidth "百千万五"
        Assert.AreEqual("１００１００００００５", s)
    

    [<TestMethod>]
    member x.invalid_number_39() =
        let s = testConv.ConvertWidth "千千万五"
        Assert.AreEqual("１０００１００００００５", s)
    

    [<TestMethod>]
    member x.invalid_number_40() =
        let s = testConv.ConvertWidth "一万万"
        Assert.AreEqual("１００００１００００", s)
    

    [<TestMethod>]
    member x.invalid_number_41() =
        let s = testConv.ConvertWidth "十万万"
        Assert.AreEqual("１０００００１００００", s)
    

    [<TestMethod>]
    member x.invalid_number_42() =
        let s = testConv.ConvertWidth "十五万万"
        Assert.AreEqual("１５００００１００００", s)
    

    [<TestMethod>]
    member x.invalid_number_43() =
        let s = testConv.ConvertWidth "千十五万万"
        Assert.AreEqual("１０１５００００１００００", s)
    

    [<TestMethod>]
    member x.invalid_number_44() =
        let s = testConv.ConvertWidth "千十五万一万"
        Assert.AreEqual("１０１５０００１１００００", s)
    

    [<TestMethod>]
    member x.invalid_number_45() =
        let s = testConv.ConvertWidth "千十五万十万"
        Assert.AreEqual("１０１５００１０１００００", s)
    

    [<TestMethod>]
    member x.invalid_number_46() =
        let s = testConv.ConvertWidth "千十五万二一万"
        Assert.AreEqual("１０１５００２１１００００", s)
    

    [<TestMethod>]
    member x.invalid_number_47() =
        let s = testConv.ConvertWidth "十万万五"
        Assert.AreEqual("１０００００１０００５", s)
    

    [<TestMethod>]
    member x.invalid_number_48() =
        let s = testConv.ConvertWidth "一十百万万五"
        Assert.AreEqual("１０１００００００１０００５", s)
    

    [<TestMethod>]
    member x.ex_test_1() =
        let s = testConv.ConvertWidth "一万一二三四"
        Assert.AreEqual("１１２３４", s)
    

    [<TestMethod>]
    member x.ex_test_2() =
        let s = testConv.ConvertWidth "一万一二三四五"
        Assert.AreEqual("１００００１２３４５", s)
    

    [<TestMethod>]
    member x.ex_test_3() =
        let s = testConv.ConvertWidth "１０万"
        Assert.AreEqual("１０００００", s)
    

    [<TestMethod>]
    member x.ex_test_4() =
        let s = testConv.ConvertWidth "１千万"
        Assert.AreEqual("１０００００００", s)
    

    [<TestMethod>]
    member x.ex_test_5() =
        let s = testConv.ConvertWidth "８千５６９４３"
        Assert.AreEqual("８５６９４３", s)
    

    [<TestMethod>]
    member x.ex_test_6() =
        let s = testConv.ConvertWidth "１万７５８"
        Assert.AreEqual("１０７５８", s)
    

    [<TestMethod>]
    member x.ex_test_7() =
        let s = testConv.ConvertWidth "３０１億１２４万７千５８"
        Assert.AreEqual("３０１０１２４７０５８", s)
    

    [<TestMethod>]
    member x.ex_test_7_err() =
        let s = testConv.ConvertWidth "３０１億１２４万７５千８"
        Assert.AreEqual("３０１０１２４００７５１００８", s)
    

    [<TestMethod>]
    member x.tel_no_test() =
        let s = testConv.ConvertWidth "〇八〇三五九五一二三四"
        Assert.AreEqual("０８０３５９５１２３４", s)
    

    [<TestMethod>]
    member x.tel_no_valid_test() =
        let s = testConv.ConvertWidth "０１２０３３４５５６７"
        Assert.AreEqual("０１２０３３４５５６７", s)
    

    [<TestMethod>]
    member x.tel_no_valid_test_2() =
        let s = testConv.ConvertWidth "〇一二〇三三四五五六八"
        Assert.AreEqual("０１２０３３４５５６８", s)
    

    [<TestMethod>]
    member x.exTest_1() =
        let s = testConv.ConvertWidth "十零"
        Assert.AreEqual("１００", s)
    
    [<TestMethod>]
    member x.exTest_2() =
        let s = testConv.ConvertWidth "十〇"
        Assert.AreEqual("１００", s)
    

    [<TestMethod>]
    member x.exTest_3() =
        let s = testConv.ConvertWidth "壱十"
        Assert.AreEqual("１０", s)
    

    [<TestMethod>]
    member x.exTest_4() =
        let s = testConv.ConvertWidth "壱拾"
        Assert.AreEqual("１０", s)
    

    [<TestMethod>]
    member x.exTest_5() =
        let s = testConv.ConvertWidth "壱百"
        Assert.AreEqual("１００", s)
    
    [<TestMethod>]
    member x.exTest_6() =
        let s = testConv.ConvertWidth "拾零"
        Assert.AreEqual("１００", s)

    [<TestMethod>]
    member x.exTest_6_2() =
        let s = testConv.ConvertWidth "拾〇"
        Assert.AreEqual("１００", s)
    

    [<TestMethod>]
    member x.exTest_十零() =
        let s = testConv.ConvertWidth "十零"
        Assert.AreEqual("１００", s)
    

    [<TestMethod>]
    member x.exTest_十〇() =
        let s = testConv.ConvertWidth "十〇"
        Assert.AreEqual("１００", s)
    

    [<TestMethod>]
    member x.exTest_壱十() =
        let s = testConv.ConvertWidth "壱十"
        Assert.AreEqual("１０", s)
    

    [<TestMethod>]
    member x.exTest_壱拾() =
        let s = testConv.ConvertWidth "壱拾"
        Assert.AreEqual("１０", s)
    

    [<TestMethod>]
    member x.exTest_壱百() =
        let s = testConv.ConvertWidth "壱百"
        Assert.AreEqual("１００", s)
    

    [<TestMethod>]
    member x.exTest_拾零() =
        let s = testConv.ConvertWidth "拾零"
        Assert.AreEqual("１００", s)
    

    [<TestMethod>]
    member x.exTest_拾〇() =
        let s = testConv.ConvertWidth "拾〇"
        Assert.AreEqual("１００", s)
    

    [<TestMethod>]
    member x.exTest_百萬() =
        let s = testConv.ConvertWidth "百萬"
        Assert.AreEqual("１００００００", s)
    

    [<TestMethod>]
    member x.exTest_百零() =
        let s = testConv.ConvertWidth "百零"
        Assert.AreEqual("１０００", s)
    

    [<TestMethod>]
    member x.exTest_百〇() =
        let s = testConv.ConvertWidth "百〇"
        Assert.AreEqual("１０００", s)
    

    [<TestMethod>]
    member x.exTest_千零() =
        let s = testConv.ConvertWidth "千零"
        Assert.AreEqual("１００００", s)
    

    [<TestMethod>]
    member x.exTest_千〇() =
        let s = testConv.ConvertWidth "千〇"
        Assert.AreEqual("１００００", s)
    

    [<TestMethod>]
    member x.exTest_万零() =
        let s = testConv.ConvertWidth "万零"
        Assert.AreEqual("１０００００", s)
    

    [<TestMethod>]
    member x.exTest_万〇() =
        let s = testConv.ConvertWidth "万〇"
        Assert.AreEqual("１０００００", s)
    

    [<TestMethod>]
    member x.exTest_萬零() =
        let s = testConv.ConvertWidth "萬零"
        Assert.AreEqual("１０００００", s)
    

    [<TestMethod>]
    member x.exTest_萬〇() =
        let s = testConv.ConvertWidth "萬〇"
        Assert.AreEqual("１０００００", s)
    

    [<TestMethod>]
    member x.exTest_億万() =
        let s = testConv.ConvertWidth "億万"
        Assert.AreEqual("１０００１００００", s)
    

    [<TestMethod>]
    member x.exTest_億萬() =
        let s = testConv.ConvertWidth "億萬"
        Assert.AreEqual("１０００１００００", s)
    

    [<TestMethod>]
    member x.exTest_億零() =
        let s = testConv.ConvertWidth "億零"
        Assert.AreEqual("１０００００００００", s)
    

    [<TestMethod>]
    member x.exTest_億〇() =
        let s = testConv.ConvertWidth "億〇"
        Assert.AreEqual("１０００００００００", s)
    

    [<TestMethod>]
    member x.exTest_兆万() =
        let s = testConv.ConvertWidth "兆万"
        Assert.AreEqual("１０００００００１００００", s)
    

    [<TestMethod>]
    member x.exTest_兆萬() =
        let s = testConv.ConvertWidth "兆萬"
        Assert.AreEqual("１０００００００１００００", s)
    

    [<TestMethod>]
    member x.exTest_兆億() =
        let s = testConv.ConvertWidth "兆億"
        Assert.AreEqual("１０００１００００００００", s)
    

    [<TestMethod>]
    member x.exTest_兆零() =
        let s = testConv.ConvertWidth "兆零"
        Assert.AreEqual("１０００００００００００００", s)
    

    [<TestMethod>]
    member x.exTest_兆〇() =
        let s = testConv.ConvertWidth "兆〇"
        Assert.AreEqual("１０００００００００００００", s)
    

    [<TestMethod>]
    member x.exTest_零十() =
        let s = testConv.ConvertWidth "零十"
        Assert.AreEqual("０１０", s)
    

    [<TestMethod>]
    member x.exTest_零拾() =
        let s = testConv.ConvertWidth "零拾"
        Assert.AreEqual("０１０", s)
    

    [<TestMethod>]
    member x.exTest_零百() =
        let s = testConv.ConvertWidth "零百"
        Assert.AreEqual("０１００", s)
    

    [<TestMethod>]
    member x.exTest_零千() =
        let s = testConv.ConvertWidth "零千"
        Assert.AreEqual("０１０００", s)
    

    [<TestMethod>]
    member x.exTest_零万() =
        let s = testConv.ConvertWidth "零万"
        Assert.AreEqual("０１００００", s)
    

    [<TestMethod>]
    member x.exTest_零萬() =
        let s = testConv.ConvertWidth "零萬"
        Assert.AreEqual("０１００００", s)
    

    [<TestMethod>]
    member x.exTest_零億() =
        let s = testConv.ConvertWidth "零億"
        Assert.AreEqual("０１００００００００", s)
    

    [<TestMethod>]
    member x.exTest_零兆() =
        let s = testConv.ConvertWidth "零兆"
        Assert.AreEqual("０１００００００００００００", s)
    

    [<TestMethod>]
    member x.exTest_〇十() =
        let s = testConv.ConvertWidth "〇十"
        Assert.AreEqual("０１０", s)
    

    [<TestMethod>]
    member x.exTest_〇拾() =
        let s = testConv.ConvertWidth "〇拾"
        Assert.AreEqual("０１０", s)
    

    [<TestMethod>]
    member x.exTest_〇百() =
        let s = testConv.ConvertWidth "〇百"
        Assert.AreEqual("０１００", s)
    

    [<TestMethod>]
    member x.exTest_〇千() =
        let s = testConv.ConvertWidth "〇千"
        Assert.AreEqual("０１０００", s)
    

    [<TestMethod>]
    member x.exTest_〇万() =
        let s = testConv.ConvertWidth "〇万"
        Assert.AreEqual("０１００００", s)
    

    [<TestMethod>]
    member x.exTest_〇萬() =
        let s = testConv.ConvertWidth "〇萬"
        Assert.AreEqual("０１００００", s)
    

    [<TestMethod>]
    member x.exTest_〇億() =
        let s = testConv.ConvertWidth "〇億"
        Assert.AreEqual("０１００００００００", s)
    

    [<TestMethod>]
    member x.exTest_〇兆() =
        let s = testConv.ConvertWidth "〇兆"
        Assert.AreEqual("０１００００００００００００", s)
    

    [<TestMethod>]
    member x.exTest_１十() =
        let s = testConv.ConvertWidth "１十"
        Assert.AreEqual("１０", s)
    

    [<TestMethod>]
    member x.exTest_１拾() =
        let s = testConv.ConvertWidth "１拾"
        Assert.AreEqual("１０", s)
    

    [<TestMethod>]
    member x.exTest_１百() =
        let s = testConv.ConvertWidth "１百"
        Assert.AreEqual("１００", s)
    

    [<TestMethod>]
    member x.exTest_０十() =
        let s = testConv.ConvertWidth "０十"
        Assert.AreEqual("０１０", s)
    

    [<TestMethod>]
    member x.exTest_０拾() =
        let s = testConv.ConvertWidth "０拾"
        Assert.AreEqual("０１０", s)
    

    [<TestMethod>]
    member x.exTest_０百() =
        let s = testConv.ConvertWidth "０百"
        Assert.AreEqual("０１００", s)
    

    [<TestMethod>]
    member x.exTest_０千() =
        let s = testConv.ConvertWidth "０千"
        Assert.AreEqual("０１０００", s)
    

    [<TestMethod>]
    member x.exTest_０万() =
        let s = testConv.ConvertWidth "０万"
        Assert.AreEqual("０１００００", s)
    

    [<TestMethod>]
    member x.exTest_０萬() =
        let s = testConv.ConvertWidth "０萬"
        Assert.AreEqual("０１００００", s)
    

    [<TestMethod>]
    member x.exTest_０億() =
        let s = testConv.ConvertWidth "０億"
        Assert.AreEqual("０１００００００００", s)
    

    [<TestMethod>]
    member x.exTest_０兆() =
        let s = testConv.ConvertWidth "０兆"
        Assert.AreEqual("０１００００００００００００", s)
    

    [<TestMethod>]
    member x.exTest_十０() =
        let s = testConv.ConvertWidth "十０"
        Assert.AreEqual("１００", s)
    

    [<TestMethod>]
    member x.exTest_拾０() =
        let s = testConv.ConvertWidth "拾０"
        Assert.AreEqual("１００", s)
    

    [<TestMethod>]
    member x.exTest_百０() =
        let s = testConv.ConvertWidth "百０"
        Assert.AreEqual("１０００", s)
    

    [<TestMethod>]
    member x.exTest_萬０() =
        let s = testConv.ConvertWidth "萬０"
        Assert.AreEqual("１０００００", s)
    

    [<TestMethod>]
    member x.exTest_億０() =
        let s = testConv.ConvertWidth "億０"
        Assert.AreEqual("１０００００００００", s)
    

    [<TestMethod>]
    member x.exTest_兆０() =
        let s = testConv.ConvertWidth "兆０"
        Assert.AreEqual("１０００００００００００００", s)
    

    [<TestMethod>]
    member x.exTst_error() =
        let s = testConv.ConvertWidth "壱弐参伍拾萬"
        // Assert.AreEqual("１２３５０１００００", s)
        Assert.AreEqual("１２３５０００００", s)
    