﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Day8.Specs
{
    [TestFixture]
    public class RegistersFunSpecs
    {
        RegistersFun ClassUnderTest;

        [TestFixtureSetUp]
        public void Setup()
        {
            ClassUnderTest = new RegistersFun();
            ClassUnderTest.Instructions = new List<string[]>();
            ClassUnderTest.RegisterValues = new Dictionary<string,int>();
        }

        [Test]
        public void when_parsing_an_insruction_primitive_and_instruction_is_null_or_empty()
        {
            var instructionPrimitive = string.Empty;
            var instruction = ClassUnderTest.ParseInstruction(instructionPrimitive);
            Assert.AreEqual(new string[] { }, instruction);
        }

        [Test]
        public void when_parsing_an_insruction_primitive()
        {
            var instructionPrimitive = "b inc 5 if a > 1";
            var instruction = ClassUnderTest.ParseInstruction(instructionPrimitive);
            Assert.AreEqual(new[] { "b", "inc", "5", "if", "a", ">", "1" }, instruction);
        }

        [Test]
        public void when_populating_the_register_instructions_and_the_input_is_empty()
        {
            var instructionPrimitives = "";
            ClassUnderTest.PopulateInstructions(instructionPrimitives);
            Assert.AreEqual(0, ClassUnderTest.Instructions.Count);
        }

        [Test]
        public void when_populating_the_register_instructions_and_there_are_three_instructions()
        {
            var instructionPrimitives = "b inc 5 if a > 1\na inc 4 if b > 1\nc dec 2 if a < 1";
            ClassUnderTest.PopulateInstructions(instructionPrimitives);
            Assert.AreEqual(3, ClassUnderTest.Instructions.Count);
            Assert.AreEqual("a", ClassUnderTest.Instructions[1][0]);
        }

        [Test]
        public void when_executing_instructions_and_there_are_no_instructions()
        {
            var instructionPrimitives = string.Empty;
            ClassUnderTest.ExecuteInstructions(instructionPrimitives);
            Assert.AreEqual(new Dictionary<string, string[]>(), ClassUnderTest.Instructions);
        }

        [Test]
        public void when_executing_instructions_and_there_are_two_instructions()
        {
            var instructionPrimitives = "b inc 5 if a > 1\na inc 4 if b < 1";
            ClassUnderTest.ExecuteInstructions(instructionPrimitives);
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("b", 0);
            dictionary.Add("a", 4);
            Assert.AreEqual(dictionary, ClassUnderTest.RegisterValues);
        }

        [Test]
        public void when_getting_largest_register_for_example()
        {
            var instructionPrimitives = "b inc 5 if a > 1\na inc 1 if b < 5\nc dec -10 if a >= 1\nc inc -20 if c == 10";
            Assert.AreEqual(1, ClassUnderTest.GetLargestRegister(instructionPrimitives));
        }

        [Test]
        public void when_getting_largest_register_puzzle_input()
        {
            var instructionPrimitives = "uz inc 134 if hx > -10 \n" +
                                        "qin dec -300 if h <= 1 \n" +
                                        "ubi inc 720 if qin <= 306 \n" +
                                        "si inc -108 if he <= 1 \n" +
                                        "hx inc 278 if hx <= -10\n" +
                                        "nfi inc 955 if f <= 5\n" +
                                        "h dec 786 if a == 0 \n" +
                                        "qin dec -965 if f >= -6\n" +
                                        "hx dec -463 if hx != -6\n" +
                                        "t dec -631 if ty <= 3\n" +
                                        "yf dec -365 if ke >= -1\n" +
                                        "z inc 270 if ke == 0\n" +
                                        "z inc -391 if nfi < 964\n" +
                                        "nfi inc -424 if sy >= 10\n" +
                                        "uz inc 152 if yu > -9\n" +
                                        "yu dec 137 if wg < 6\n" +
                                        "ke dec -562 if hx == 463\n" +
                                        "ke dec 944 if h != -794\n" +
                                        "ty dec -993 if qin < 1261 \n" +
                                        "a inc 456 if wg <= 8\n" +
                                        "zwx inc 585 if ty != 2 \n" +
                                        "z dec 744 if zwq <= 5\n" +
                                        "zwq inc -316 if he > -8\n" +
                                        "xf inc -614 if hx != 462\n" +
                                        "hx dec -589 if ke >= -391 \n" +
                                        "xp inc 551 if f != 0\n" +
                                        "yu inc 640 if a < 464\n" +
                                        "uz inc -299 if t != 636\n" +
                                        "t dec -93 if a != 461\n" +
                                        "yu inc -202 if qin <= 1270\n" +
                                        "hx dec 552 if zwq < -312\n" +
                                        "ubi dec -562 if jke <= 4\n" +
                                        "nfi inc -531 if sy == 0\n" +
                                        "xf inc -620 if h < -791\n" +
                                        "ubi dec 164 if jke <= 2\n" +
                                        "xf inc 715 if xf == -614\n" +
                                        "si inc 832 if w < 4 \n" +
                                        "xp inc 37 if t >= 721\n" +
                                        "yu inc -49 if u != 3\n" +
                                        "wg inc -500 if o > -3\n" +
                                        "he dec -740 if xp <= 46\n" +
                                        "ubi dec -946 if u != 0 \n" +
                                        "fkh dec 973 if nfi < 434\n" +
                                        "zwx inc 796 if si >= 719\n" +
                                        "hx inc 443 if ty < -2\n" +
                                        "w inc -515 if wg != -490\n" +
                                        "xf inc -394 if xf != 109\n" +
                                        "u inc 176 if sy <= 7\n" +
                                        "sy inc 170 if w < -513 \n" +
                                        "si dec -699 if fkh == -973\n" +
                                        "nfi dec 321 if w != -519\n" +
                                        "yu inc -846 if wg < -496\n" +
                                        "hx inc 953 if qin < 1270\n" +
                                        "w dec -394 if u < 183\n" +
                                        "xf dec -601 if he == 731\n" +
                                        "zwx inc 267 if h >= -777\n" +
                                        "zwq inc 781 if f > -3\n" +
                                        "jke inc 278 if jke >= -3\n" +
                                        "u inc -7 if u <= 184\n" +
                                        "zwq inc 449 if wg >= -503 \n" +
                                        "si dec 368 if hx != 1446\n" +
                                        "h dec -24 if jke >= 282\n" +
                                        "ke dec -284 if yu < -587\n" +
                                        "si dec 17 if a > 458\n" +
                                        "o dec 177 if yu != -594\n" +
                                        "he inc -925 if ubi >= 1116\n" +
                                        "ubi inc 544 if zwq <= 915 \n" +
                                        "hx dec -56 if yf < 373 \n" +
                                        "wg dec -613 if z > -866\n" +
                                        "wg inc -580 if z >= -868\n" +
                                        "xp dec -445 if ty > 3\n" +
                                        "yu dec -419 if h < -776\n" +
                                        "ty dec -75 if xp <= 35 \n" +
                                        "u dec 30 if xf < -283\n" +
                                        "o inc 69 if uz != -13\n" +
                                        "f dec 910 if t >= 716\n" +
                                        "he inc 100 if xf < -296\n" +
                                        "jke dec 125 if nfi >= 98\n" +
                                        "yu dec 526 if xp <= 45 \n" +
                                        "fkh dec 708 if zwq >= 918 \n" +
                                        "u dec -397 if w > -131 \n" +
                                        "si dec 417 if u != 533 \n" +
                                        "wg dec 247 if wg == -467\n" +
                                        "t inc 45 if yu < -700\n" +
                                        "ty dec 805 if o <= 8\n" +
                                        "he dec 734 if f < -909 \n" +
                                        "z inc 812 if f > -907\n" +
                                        "w dec -508 if xf > -300\n" +
                                        "a inc -375 if uz == -13\n" +
                                        "zwx inc 160 if w >= 378\n" +
                                        "o inc -905 if qin < 1264\n" +
                                        "jke dec -594 if fkh != -971\n" +
                                        "fkh dec -392 if xp >= 32\n" +
                                        "t dec 512 if jke != 754\n" +
                                        "a dec -949 if ke == -98\n" +
                                        "f inc -70 if a > 1022\n" +
                                        "f dec -844 if qin > 1261\n" +
                                        "u dec 212 if sy <= 176 \n" +
                                        "xf dec -779 if w == 396\n" +
                                        "uz inc -455 if zwx >= 1548\n" +
                                        "o dec 502 if wg > -723 \n" +
                                        "sy inc 77 if u > 326\n" +
                                        "uz inc -996 if xp >= 32\n" +
                                        "nfi dec -355 if hx >= 1502\n" +
                                        "hx dec 855 if hx <= 1503\n" +
                                        "qin inc 376 if xf > -296\n" +
                                        "sy dec -519 if zwq != 916 \n" +
                                        "a dec 459 if a > 1023\n" +
                                        "ty inc -289 if zwq > 905\n" +
                                        "he dec -722 if zwx >= 1532\n" +
                                        "jke inc 656 if sy < 691\n" +
                                        "u dec -989 if nfi < 466\n" +
                                        "a inc -377 if zwx >= 1545 \n" +
                                        "sy dec -256 if yf == 365\n" +
                                        "ubi dec 597 if fkh > -591 \n" +
                                        "xf inc 403 if ty == -1094 \n" +
                                        "z dec 335 if o <= -498 \n" +
                                        "yf dec -707 if zwq < 907\n" +
                                        "zwq inc 420 if h == -780\n" +
                                        "h dec -612 if uz >= -1010 \n" +
                                        "hx dec 941 if w != 390 \n" +
                                        "xp dec 345 if u != 1306\n" +
                                        "xp dec -409 if si <= 641\n" +
                                        "uz dec 877 if hx <= 574\n" +
                                        "t dec 615 if f > -142\n" +
                                        "wg dec 505 if hx >= 566\n" +
                                        "ubi inc 413 if o >= -506\n" +
                                        "uz dec -263 if h < -167\n" +
                                        "f dec 537 if xf != 110 \n" +
                                        "wg dec -762 if sy > 935\n" +
                                        "o inc 458 if fkh == -591\n" +
                                        "ubi dec -914 if ubi != 1488\n" +
                                        "wg inc 203 if sy >= 952\n" +
                                        "zwq dec -879 if ty == -1094\n" +
                                        "h inc -676 if xp <= 103\n" +
                                        "he inc 544 if zwq <= 1795 \n" +
                                        "jke inc 178 if si < 648\n" +
                                        "xf dec 262 if xp >= 96 \n" +
                                        "sy dec -214 if w >= 383\n" +
                                        "u inc 88 if uz != -1633\n" +
                                        "yu dec 375 if t <= -358\n" +
                                        "wg dec 526 if hx == 568\n" +
                                        "yf dec 731 if si > 631 \n" +
                                        "he inc -980 if zwq == 1793\n" +
                                        "ty dec 94 if t > -368\n" +
                                        "yf dec -849 if yu > -1077 \n" +
                                        "ty dec 889 if f != -139\n" +
                                        "w dec 37 if f > -137\n" +
                                        "wg inc 552 if si > 631 \n" +
                                        "he inc -989 if nfi > 457\n" +
                                        "f dec -500 if zwq > 1785\n" +
                                        "ubi inc -394 if jke >= 1578\n" +
                                        "yu dec -370 if o == -498\n" +
                                        "nfi dec 879 if hx >= 559\n" +
                                        "nfi inc -280 if h > -853\n" +
                                        "a inc -746 if wg != -431\n" +
                                        "h inc -362 if a >= 569 \n" +
                                        "jke dec 740 if si > 631\n" +
                                        "zwx inc -152 if yf < 489\n" +
                                        "z inc -442 if wg == -431\n" +
                                        "t inc -404 if xp != 101\n" +
                                        "t inc 668 if ty != -2081\n" +
                                        "f dec 846 if yu >= -1084\n" +
                                        "xf inc -342 if z < -1638\n" +
                                        "xf inc 692 if ubi > 2003\n" +
                                        "qin inc 874 if sy == 1159 \n" +
                                        "t inc -792 if jke < 850\n" +
                                        "jke dec 263 if ubi < 1997 \n" +
                                        "xf dec -645 if w != 343\n" +
                                        "u inc -291 if yf < 485 \n" +
                                        "wg inc 948 if fkh != -574 \n" +
                                        "u inc 773 if zwx <= 1392\n" +
                                        "fkh dec -56 if jke != 836 \n" +
                                        "w dec 436 if qin <= 2521\n" +
                                        "o inc 769 if ty >= -2079\n" +
                                        "o dec 457 if zwx < 1392\n" +
                                        "a dec -422 if fkh != -531 \n" +
                                        "z dec -170 if qin <= 2518 \n" +
                                        "qin inc -569 if ty >= -2077\n" +
                                        "uz inc -789 if zwq >= 1803\n" +
                                        "f dec 322 if xp < 103\n" +
                                        "xf inc -752 if xp <= 108\n" +
                                        "xp dec -46 if z == -1472\n" +
                                        "hx dec 378 if zwx <= 1390 \n" +
                                        "ubi dec -746 if ubi < 2008\n" +
                                        "xf dec -22 if si > 635 \n" +
                                        "h dec -274 if zwq <= 1794 \n" +
                                        "u dec -980 if yf < 485 \n" +
                                        "ty dec -41 if ty <= -2071 \n" +
                                        "t dec -818 if ty != -2043 \n" +
                                        "u dec -764 if nfi < -704\n" +
                                        "uz inc 233 if sy >= 1152\n" +
                                        "t dec 552 if xp > 145\n" +
                                        "h dec 689 if zwq >= 1789\n" +
                                        "h dec -219 if yf <= 485\n" +
                                        "uz inc 890 if uz == -1390 \n" +
                                        "zwx dec -399 if z == -1472\n" +
                                        "jke inc 792 if w <= -85\n" +
                                        "si dec -991 if nfi == -701\n" +
                                        "f inc -355 if ke <= -91\n" +
                                        "ke dec -575 if wg > 516\n" +
                                        "hx dec -38 if ke <= 482\n" +
                                        "si inc 478 if he > -1623\n" +
                                        "ubi dec 18 if o < -185 \n" +
                                        "fkh dec 394 if wg > 521\n" +
                                        "wg inc 988 if zwx != 1790 \n" +
                                        "hx inc -777 if qin >= 1949\n" +
                                        "ubi inc 680 if he >= -1618\n" +
                                        "fkh inc -479 if qin > 1945\n" +
                                        "zwx dec 704 if jke != 1640\n" +
                                        "fkh dec -167 if t == -216 \n" +
                                        "yu dec 881 if ubi >= 2724 \n" +
                                        "wg dec -93 if qin >= 1940 \n" +
                                        "nfi dec -763 if o <= -182 \n" +
                                        "t dec -937 if t != -215\n" +
                                        "u inc 114 if t != 721\n" +
                                        "ubi dec 547 if uz < -507\n" +
                                        "qin dec 827 if sy == 1159 \n" +
                                        "w inc -588 if t >= 721 \n" +
                                        "zwx dec 548 if a > 997 \n" +
                                        "a inc 929 if f < -1164 \n" +
                                        "zwq inc -260 if zwx == 1084\n" +
                                        "ty dec -814 if si > 2100\n" +
                                        "yf dec 745 if w >= -665\n" +
                                        "t inc -257 if ke <= 486\n" +
                                        "u dec 522 if t < 471\n" +
                                        "hx inc 376 if z == -1472\n" +
                                        "t dec 996 if si != 2098\n" +
                                        "uz dec 375 if u >= 2337\n" +
                                        "fkh dec 823 if xp >= 149\n" +
                                        "z dec 497 if ty != -1212\n" +
                                        "t dec 0 if sy >= 1156\n" +
                                        "xp inc 742 if a != 993 \n" +
                                        "xp dec -160 if f < -1149\n" +
                                        "zwx dec -988 if z < -1972 \n" +
                                        "he dec -586 if w < -677\n" +
                                        "yu inc 646 if wg > 1594\n" +
                                        "jke dec -686 if he < -1616\n" +
                                        "a dec 375 if jke <= 2323\n" +
                                        "h dec -719 if ty < -1223\n" +
                                        "xp dec -169 if uz < -868\n" +
                                        "o inc 961 if f < -1155 \n" +
                                        "si inc 462 if yu == -1321 \n" +
                                        "hx inc 647 if ke != 487\n" +
                                        "jke inc 372 if xf == -579 \n" +
                                        "xf inc 188 if f == -1159\n" +
                                        "a dec 78 if xp < 479\n" +
                                        "wg inc -818 if f >= -1166 \n" +
                                        "yf inc 994 if h > -1418\n" +
                                        "fkh inc -812 if xf > -396 \n" +
                                        "qin dec -321 if si == 2116\n" +
                                        "f inc 830 if nfi >= 58 \n" +
                                        "u inc 24 if h >= -1399 \n" +
                                        "uz inc 881 if jke != 2693 \n" +
                                        "w dec 719 if ke != 479 \n" +
                                        "jke inc 694 if nfi > 61\n" +
                                        "hx dec 84 if ty > -1224\n" +
                                        "ty dec -221 if zwq <= 1536\n" +
                                        "yu dec 236 if zwq == 1540 \n" +
                                        "yu dec -763 if f != -339\n" +
                                        "a dec 892 if w <= -1391\n" +
                                        "jke dec -275 if ubi < 2733\n" +
                                        "nfi inc -121 if zwx < 1086\n" +
                                        "a inc 809 if t < -526\n" +
                                        "si inc -997 if jke != 3664\n" +
                                        "xf dec 787 if hx <= 1158\n" +
                                        "ty dec -599 if z > -1975\n" +
                                        "yu inc -534 if a <= 456\n" +
                                        "ty inc 573 if nfi < -49\n" +
                                        "sy dec -53 if sy < 1162\n" +
                                        "wg inc -751 if w == -1393 \n" +
                                        "xf inc 704 if ubi > 2723\n" +
                                        "si inc 314 if wg != 27 \n" +
                                        "wg inc 607 if h == -1408\n" +
                                        "zwx dec -263 if a >= 450\n" +
                                        "qin inc -390 if ke <= 482 \n" +
                                        "ke inc 866 if f <= -330\n" +
                                        "f inc 79 if uz <= 9 \n" +
                                        "hx dec 683 if z > -1975\n" +
                                        "si dec 678 if wg > 634 \n" +
                                        "si inc -853 if zwx != 1338\n" +
                                        "z inc -586 if jke == 3665 \n" +
                                        "he inc 810 if jke != 3656 \n" +
                                        "uz inc -248 if o != 762\n" +
                                        "fkh dec 334 if xp != 474\n" +
                                        "w dec 368 if zwq == 1533\n" +
                                        "t dec -502 if f <= -259\n" +
                                        "yf inc -523 if u > 2344\n" +
                                        "yu inc -10 if ke != 477\n" +
                                        "u dec -918 if u < 2345 \n" +
                                        "uz inc 580 if fkh <= -1979\n" +
                                        "t inc 144 if ke >= 485 \n" +
                                        "xp dec -366 if zwx == 1338\n" +
                                        "ubi inc -26 if t < -524\n" +
                                        "xp inc -776 if he != -813 \n" +
                                        "ubi inc 136 if a != 450\n" +
                                        "qin inc 13 if xf >= 306\n" +
                                        "yf dec 536 if uz != 333\n" +
                                        "hx dec -213 if z > -1978\n" +
                                        "f inc -224 if zwq >= 1542 \n" +
                                        "wg dec -507 if f <= -246\n" +
                                        "yu inc -668 if w != -1761 \n" +
                                        "ke inc -680 if t != -533\n" +
                                        "jke dec -283 if wg == 1143\n" +
                                        "f dec 870 if o >= 767\n" +
                                        "jke inc -124 if fkh <= -1976 \n" +
                                        "u dec -567 if w < -1763\n" +
                                        "o dec 457 if xf <= 312 \n" +
                                        "ty dec 576 if zwx > 1345\n" +
                                        "qin inc 142 if yu <= -555 \n" +
                                        "ke dec 749 if hx != 702\n" +
                                        "wg dec 851 if w == -1763\n" +
                                        "a dec 686 if yf == 933 \n" +
                                        "wg dec -701 if z > -1964\n" +
                                        "ty inc -877 if zwq < 1541 \n" +
                                        "xf dec -990 if fkh == -1983\n" +
                                        "ubi inc 0 if ty == -1282\n" +
                                        "h inc -21 if h != -1400\n" +
                                        "sy dec -519 if xf != 1303 \n" +
                                        "jke inc 603 if he > -818\n" +
                                        "ty dec -4 if hx > 699\n" +
                                        "xp inc 21 if wg > 1138 \n" +
                                        "xp dec 745 if t <= -527\n" +
                                        "yu dec -614 if hx > 691\n" +
                                        "a inc -490 if xp != -1018 \n" +
                                        "h dec -723 if jke != 4428 \n" +
                                        "sy inc -594 if yf != 947\n" +
                                        "hx dec 851 if o <= 761 \n" +
                                        "a dec -345 if t >= -532\n" +
                                        "ubi inc -359 if f < -1122 \n" +
                                        "jke dec 738 if wg == 1143 \n" +
                                        "ty dec 340 if xp != -1024 \n" +
                                        "nfi inc -786 if w >= -1767\n" +
                                        "zwq dec 428 if qin == 740 \n" +
                                        "zwq inc 503 if t < -527\n" +
                                        "zwq dec -98 if si != -113 \n" +
                                        "sy dec 297 if he > -815\n" +
                                        "u inc -886 if xf < 1313\n" +
                                        "z dec 105 if h <= -704 \n" +
                                        "yf dec -260 if f != -1127 \n" +
                                        "w dec 920 if w != -1756\n" +
                                        "a inc 744 if hx == 697 \n" +
                                        "sy inc 262 if t <= -528\n" +
                                        "si inc 347 if uz <= 347\n" +
                                        "si inc -188 if o <= 779\n" +
                                        "h dec 191 if he != -812\n" +
                                        "xp inc 1000 if sy >= 578\n" +
                                        "yf inc -563 if ke < -942\n" +
                                        "xf inc 547 if h > -710 \n" +
                                        "f inc -783 if yu < 73\n" +
                                        "z dec 394 if h < -705\n" +
                                        "hx dec 765 if xf != 1856\n" +
                                        "t inc -817 if wg >= 1140\n" +
                                        "yu dec -8 if t != -1343\n" +
                                        "w dec 152 if zwx >= 1338\n" +
                                        "ubi dec -134 if fkh <= -1978 \n" +
                                        "f dec 841 if jke >= 3679\n" +
                                        "uz dec -245 if t <= -1349 \n" +
                                        "o dec 151 if a >= 1066 \n" +
                                        "qin inc -219 if w <= -2840\n" +
                                        "yu inc -323 if yf != 637\n" +
                                        "sy dec -490 if xp == -24\n" +
                                        "xp dec -649 if qin != 735 \n" +
                                        "xf inc 39 if nfi != -855\n" +
                                        "wg inc 581 if sy < 1074\n" +
                                        "f inc -42 if uz == 583 \n" +
                                        "z inc 506 if he < -808 \n" +
                                        "he dec 568 if he < -804\n" +
                                        "wg dec 60 if he >= -1381\n" +
                                        "hx dec -835 if qin < 748\n" +
                                        "ty inc -593 if qin > 739\n" +
                                        "wg dec 613 if wg == 1664\n" +
                                        "h dec 107 if h <= -706 \n" +
                                        "yf dec -40 if a > 1058 \n" +
                                        "fkh inc 511 if ke >= -949 \n" +
                                        "wg dec -812 if yf == 638\n" +
                                        "xf dec -349 if zwx <= 1356\n" +
                                        "si dec -614 if ty <= -1868\n" +
                                        "z inc 28 if he <= -1376\n" +
                                        "he inc -666 if uz > 579\n" +
                                        "sy dec 584 if si == 666\n" +
                                        "sy inc 536 if o > 767\n" +
                                        "f dec 384 if t != -1342\n" +
                                        "jke dec 341 if xp != 625\n" +
                                        "w dec 894 if zwq <= 2139\n" +
                                        "si dec -871 if yu < -240\n" +
                                        "he inc 659 if nfi <= -838 \n" +
                                        "qin inc 32 if xf == 2238\n" +
                                        "nfi dec -165 if z > -1938 \n" +
                                        "h inc 473 if zwq == 2130\n" +
                                        "qin dec 666 if xf >= 2230 \n" +
                                        "qin inc 469 if si > 1543\n" +
                                        "t dec 348 if h == -813 \n" +
                                        "si inc 578 if jke != 3684 \n" +
                                        "ke inc 186 if a == 1056\n" +
                                        "jke inc -61 if xp >= 616\n" +
                                        "u inc -347 if fkh > -1987 \n" +
                                        "zwx dec -894 if ubi != 2968\n" +
                                        "h dec -204 if ke <= -768\n" +
                                        "yu dec -501 if sy != 1024 \n" +
                                        "f dec 393 if wg > 1866 \n" +
                                        "t inc 768 if hx != 766 \n" +
                                        "he dec 459 if fkh == -1980\n" +
                                        "qin dec -650 if z >= -1933\n" +
                                        "sy inc 333 if yf <= 642\n" +
                                        "nfi inc 93 if xf >= 2247\n" +
                                        "z inc 829 if xp == 620 \n" +
                                        "wg dec -396 if hx != 760\n" +
                                        "xp inc -71 if hx <= 765\n" +
                                        "w inc -837 if ty >= -1884 \n" +
                                        "ty dec 380 if z < -1925\n" +
                                        "h inc -162 if yf <= 642\n" +
                                        "hx inc 324 if yu > 258 \n" +
                                        "fkh dec -83 if ty > -2258 \n" +
                                        "uz inc 716 if jke <= 3631 \n" +
                                        "w inc -331 if nfi == -680 \n" +
                                        "ubi dec 638 if wg >= 2252 \n" +
                                        "wg inc 139 if ty < -2256\n" +
                                        "xp dec 21 if he >= -1387\n" +
                                        "fkh dec 723 if hx < 774\n" +
                                        "zwx dec -981 if f != -3170\n" +
                                        "f dec 650 if ty == -2263\n" +
                                        "f dec -247 if jke == 3623 \n" +
                                        "hx inc -250 if z >= -1938 \n" +
                                        "xp inc -236 if hx == 517\n" +
                                        "ke dec -408 if ubi == 2332\n" +
                                        "xp inc -266 if xp < 377\n" +
                                        "f inc -349 if hx > 509 \n" +
                                        "u inc 945 if jke > 3621\n" +
                                        "si inc -843 if yu < 252\n" +
                                        "t dec 747 if ty == -2262\n" +
                                        "uz inc -684 if xf <= 2228 \n" +
                                        "yu inc 73 if t <= -922 \n" +
                                        "jke dec 435 if xf <= 2238 \n" +
                                        "sy dec -495 if z < -1937\n" +
                                        "jke inc 293 if jke < 3198 \n" +
                                        "fkh dec -220 if xf <= 2236\n" +
                                        "z dec -905 if wg >= 2252\n" +
                                        "wg dec 544 if nfi <= -679 \n" +
                                        "ty inc 807 if a > 1050 \n" +
                                        "qin dec 337 if ty < -1447 \n" +
                                        "xf dec 178 if ty != -1455 \n" +
                                        "nfi dec 119 if a >= 1055\n" +
                                        "he inc -956 if fkh < -2624\n" +
                                        "jke dec 224 if t == -923\n" +
                                        "fkh inc 135 if o != 765\n" +
                                        "si dec 428 if qin == -229 \n" +
                                        "o inc -985 if si > 1114\n" +
                                        "he dec 100 if f != -3272\n" +
                                        "ty inc -707 if xp >= 94\n" +
                                        "jke dec 551 if w == -4895 \n" +
                                        "yu dec -308 if h <= -968\n" +
                                        "h inc -429 if wg <= 1718\n" +
                                        "wg dec 278 if uz == 1299\n" +
                                        "uz inc -416 if fkh >= -2494\n" +
                                        "ty dec -876 if qin == -229\n" +
                                        "sy inc 213 if o >= 774 \n" +
                                        "qin dec 664 if wg > 1434\n" +
                                        "h inc 273 if uz != 879 \n" +
                                        "zwx inc -611 if ubi != 2334\n" +
                                        "hx dec 384 if wg >= 1429\n" +
                                        "he inc -84 if uz == 883\n" +
                                        "hx inc 23 if yu > 626\n" +
                                        "si dec 319 if wg == 1433\n" +
                                        "h dec 343 if ubi <= 2332\n" +
                                        "yf dec 941 if w == -4895\n" +
                                        "w inc -450 if u >= 2981\n" +
                                        "hx inc 435 if xf <= 2065\n" +
                                        "si dec -198 if xp <= 107\n" +
                                        "si inc -322 if he < -1467 \n" +
                                        "o dec 21 if xf != 2055 \n" +
                                        "zwx dec 251 if ty > -1284 \n" +
                                        "ke dec 399 if yf > -309\n" +
                                        "f inc 965 if xf <= 2063\n" +
                                        "ke dec 488 if o != 749 \n" +
                                        "a dec 163 if a != 1061 \n" +
                                        "hx inc 2 if w != -4887 \n" +
                                        "zwq inc -736 if uz < 888\n" +
                                        "qin inc 155 if a <= 884\n" +
                                        "zwx dec 798 if xf == 2060 \n" +
                                        "o dec -566 if jke < 2933\n" +
                                        "yf inc 536 if u != 2965\n" +
                                        "f dec -782 if zwx != 575\n" +
                                        "nfi dec 603 if z <= -1024 \n" +
                                        "f dec -409 if t == -929\n" +
                                        "zwx inc 140 if hx < 597\n" +
                                        "hx dec 778 if f > -1120\n" +
                                        "h dec -327 if wg > 1435\n" +
                                        "ke inc 146 if zwq <= 1406 \n" +
                                        "sy dec -718 if xf != 2060 \n" +
                                        "yf dec 125 if h < -1140\n" +
                                        "xf dec -154 if ubi == 2326\n" +
                                        "a dec 744 if xp > 93\n" +
                                        "yf inc 837 if si > 982 \n" +
                                        "jke inc 526 if o < 1320\n" +
                                        "jke inc 919 if he <= -1470\n" +
                                        "xp dec -626 if xp != 102\n" +
                                        "h inc 18 if uz != 885\n" +
                                        "uz dec 39 if h >= -1133\n" +
                                        "o dec -642 if ubi > 2324\n" +
                                        "wg inc -500 if uz >= 842\n" +
                                        "zwx inc -530 if o <= 1956 \n" +
                                        "u dec -334 if ke != -1100 \n" +
                                        "yf dec -231 if o <= 1966\n" +
                                        "zwx dec 470 if fkh == -2488\n" +
                                        "zwq inc 345 if xp == 97\n" +
                                        "ubi dec -357 if fkh >= -2496 \n" +
                                        "nfi dec 923 if ke >= -1100\n" +
                                        "ke inc 764 if si < 980 \n" +
                                        "t inc 165 if fkh >= -2488 \n" +
                                        "he inc -579 if yu > 626\n" +
                                        "xp dec 337 if w != -4897\n" +
                                        "o dec -573 if ubi < 2690\n" +
                                        "nfi inc -512 if jke != 4384\n" +
                                        "yf inc 85 if ubi != 2689\n" +
                                        "u dec 401 if zwq <= 1399\n" +
                                        "ty inc -528 if uz == 844\n" +
                                        "xf dec 254 if fkh == -2488\n" +
                                        "f dec 713 if z >= -1033\n" +
                                        "xf dec -632 if zwq > 1392 \n" +
                                        "uz inc 166 if f >= -1823\n" +
                                        "zwq inc -492 if he >= -2051\n" +
                                        "hx inc 287 if uz != 851\n" +
                                        "ty inc -935 if wg != 929\n" +
                                        "h dec 74 if jke <= 4384\n" +
                                        "zwx inc 43 if hx == 102\n" +
                                        "jke inc 151 if z < -1025\n" +
                                        "w dec 839 if t == -764 \n" +
                                        "wg dec -753 if fkh > -2492\n" +
                                        "o dec -751 if t != -764\n" +
                                        "ty inc -359 if yu > 635\n" +
                                        "yu inc -344 if z > -1024\n" +
                                        "uz dec -356 if xf >= 2440 \n" +
                                        "u dec 797 if yu <= 634 \n" +
                                        "zwq inc 141 if he != -2060\n" +
                                        "wg dec 365 if a < 156\n" +
                                        "t dec 382 if u < 2112\n" +
                                        "f inc 374 if wg == 1325\n" +
                                        "he dec -912 if qin >= -896\n" +
                                        "o dec 325 if o >= 2524 \n" +
                                        "ty inc 276 if a > 143\n" +
                                        "ty inc 507 if zwx > 297\n" +
                                        "f dec -837 if yu > 627 \n" +
                                        "wg inc 221 if ke != -1100 \n" +
                                        "z dec 423 if si >= 977 \n" +
                                        "o dec 551 if zwq < 1039\n" +
                                        "f inc 956 if si >= 978 \n" +
                                        "fkh inc -236 if fkh >= -2496 \n" +
                                        "he inc 206 if hx > 99\n" +
                                        "zwx dec -239 if he < -927 \n" +
                                        "hx inc -246 if wg >= 1545 \n" +
                                        "fkh inc 652 if he > -935\n" +
                                        "qin inc -429 if yf <= 1184\n" +
                                        "yu dec -3 if nfi == -2830 \n" +
                                        "zwq dec -582 if sy <= 1359\n" +
                                        "ubi inc 728 if t >= -1138 \n" +
                                        "fkh inc 327 if xp <= -231 \n" +
                                        "w inc 85 if xp >= -227 \n" +
                                        "t dec 983 if zwq < 1630\n" +
                                        "xf dec -568 if he >= -939 \n" +
                                        "yu inc -193 if f >= 342\n" +
                                        "ty inc 210 if he < -925\n" +
                                        "f inc -345 if uz < 852 \n" +
                                        "nfi dec -444 if h > -1206 \n" +
                                        "xp inc -160 if nfi < -2389\n" +
                                        "f dec -919 if u > 2107 \n" +
                                        "zwq inc 788 if ke > -1107 \n" +
                                        "ty inc -628 if o != 2201\n" +
                                        "a inc 506 if jke > 4525\n" +
                                        "t inc 413 if t > -2130 \n" +
                                        "nfi dec -131 if fkh == -1745 \n" +
                                        "ke inc -475 if wg < 1553\n" +
                                        "wg dec 955 if jke > 4525\n" +
                                        "xf dec -41 if hx < -148\n" +
                                        "ubi dec 105 if uz < 846\n" +
                                        "h inc -312 if ke < -1568\n" +
                                        "ubi inc -552 if o != 2201 \n" +
                                        "zwx dec -713 if w < -5732 \n" +
                                        "zwq dec 437 if jke != 4520\n" +
                                        "a dec -164 if ke >= -1565 \n" +
                                        "hx inc 189 if sy != 1356\n" +
                                        "o dec 856 if wg != 593 \n" +
                                        "xf inc -563 if h > -1518\n" +
                                        "wg inc 313 if yf < 1186\n" +
                                        "he inc -628 if u >= 2102\n" +
                                        "he dec -537 if xf < 2447\n" +
                                        "zwq dec -64 if o >= 1345\n" +
                                        "t inc -465 if wg <= 905\n" +
                                        "jke inc -495 if u == 2107 \n" +
                                        "qin dec -271 if zwq < 2046\n" +
                                        "zwx dec -18 if w == -5734 \n" +
                                        "yu inc -376 if h == -1508 \n" +
                                        "zwq dec 537 if zwq == 2044\n" +
                                        "nfi inc -751 if uz > 837\n" +
                                        "yf dec 135 if h < -1508\n" +
                                        "nfi inc 943 if u > 2106\n" +
                                        "si dec -835 if ty > -2889 \n" +
                                        "zwq dec 334 if zwq > 1502 \n" +
                                        "ubi inc 920 if jke != 4032\n" +
                                        "ke dec 939 if zwq > 1170\n" +
                                        "h dec -570 if jke != 4029 \n" +
                                        "yf dec -80 if yf == 1047\n" +
                                        "h inc 104 if w >= -5731\n" +
                                        "a inc -173 if sy <= 1355\n" +
                                        "ke inc 689 if hx > 51\n" +
                                        "ubi dec -953 if si <= 1829\n" +
                                        "nfi inc -927 if qin <= -1060 \n" +
                                        "qin inc 84 if qin < -1051 \n" +
                                        "zwx dec -466 if u <= 2103 \n" +
                                        "ubi dec -45 if xp <= -393 \n" +
                                        "w dec 23 if fkh == -1745\n" +
                                        "u inc 658 if fkh >= -1738 \n" +
                                        "wg dec -262 if uz == 844\n" +
                                        "f dec -46 if t <= -2176\n" +
                                        "si dec -622 if hx <= 46\n" +
                                        "qin dec -617 if uz > 837\n" +
                                        "uz dec 775 if sy <= 1361\n" +
                                        "ty inc 675 if t > -2191\n" +
                                        "xf inc -263 if nfi <= -2076\n" +
                                        "ke dec -502 if si <= 2436 \n" +
                                        "z inc -704 if jke == 4031 \n" +
                                        "nfi dec -154 if he > -1024\n" +
                                        "o inc 896 if he > -1027\n" +
                                        "hx dec 1 if qin != -440\n" +
                                        "sy inc -236 if h == -936\n" +
                                        "qin inc 38 if jke > 4021\n" +
                                        "wg inc 168 if ty == -2209 \n" +
                                        "zwx inc 252 if ty > -2215 \n" +
                                        "ty inc -296 if ty != -2215\n" +
                                        "a dec -346 if o > 2253 \n" +
                                        "f inc 76 if u >= 2098\n" +
                                        "xp dec 22 if wg > 1330 \n" +
                                        "xp dec 783 if w > -5754\n" +
                                        "sy dec -525 if yf >= 1037 \n" +
                                        "xf inc -434 if yf >= 1046 \n" +
                                        "u dec -160 if f < 117\n" +
                                        "nfi dec -498 if f > 124\n" +
                                        "fkh inc 654 if zwq >= 1164\n" +
                                        "yu dec 393 if sy != 1881\n" +
                                        "zwq dec 966 if qin > -404 \n" +
                                        "zwx dec 146 if jke < 4032 \n" +
                                        "nfi inc -531 if f > 108\n" +
                                        "si dec 607 if nfi < -2442 \n" +
                                        "w inc -519 if u <= 2274\n" +
                                        "ke inc -299 if ty < -2502 \n" +
                                        "zwx inc 1000 if nfi > -2456\n" +
                                        "o inc -746 if u >= 2269\n" +
                                        "ty inc -694 if ubi < 3941 \n" +
                                        "z inc 37 if uz <= 75\n" +
                                        "fkh dec 785 if h < -938\n" +
                                        "sy dec -790 if yu <= 243\n" +
                                        "nfi dec -952 if u >= 2275 \n" +
                                        "f inc -326 if ubi < 3957\n" +
                                        "u inc -716 if si >= 1826\n" +
                                        "xp inc -811 if z >= -2127 \n" +
                                        "xf dec -825 if sy >= 2671 \n" +
                                        "h dec -220 if jke >= 4023 \n" +
                                        "t inc 405 if yf < 1038 \n" +
                                        "qin inc 212 if t > -2188\n" +
                                        "h inc -738 if t < -2176\n" +
                                        "sy dec -659 if fkh > -1885\n" +
                                        "ke dec -94 if qin != -175 \n" +
                                        "a inc 407 if a >= 653\n" +
                                        "qin inc 628 if h < -1456\n" +
                                        "a dec 363 if jke < 4033\n" +
                                        "ty dec 582 if zwx < 2376\n" +
                                        "zwx inc 93 if ubi < 3952\n" +
                                        "nfi dec -728 if xf >= 3265\n" +
                                        "fkh dec -652 if u != 1541 \n" +
                                        "he dec -847 if fkh <= -1233\n" +
                                        "nfi inc 258 if t != -2185 \n" +
                                        "a inc -703 if f >= -214\n" +
                                        "w dec 811 if nfi >= -1464 \n" +
                                        "qin dec 41 if ty != -3082 \n" +
                                        "xp inc 308 if uz != 71 \n" +
                                        "zwx inc -688 if wg != 1328\n" +
                                        "zwq inc 319 if uz <= 61\n" +
                                        "he inc -906 if xf <= 3268 \n" +
                                        "w inc -941 if ke >= -2722 \n" +
                                        "h inc 74 if uz == 69\n" +
                                        "zwq inc 187 if uz <= 75\n" +
                                        "jke dec -909 if he <= -1921\n" +
                                        "z dec 820 if si < 1838 \n" +
                                        "h inc -463 if uz > 68\n" +
                                        "ubi inc -3 if hx >= 44 \n" +
                                        "w dec -250 if zwq == 394\n" +
                                        "t inc -910 if z > -2933\n" +
                                        "sy dec 917 if ty != -3087 \n" +
                                        "yf inc -88 if nfi >= -1458\n" +
                                        "wg dec -945 if w < -7770\n" +
                                        "a inc 700 if zwx < 1778\n" +
                                        "jke inc 544 if h < -1848\n" +
                                        "o inc -646 if h <= -1857\n" +
                                        "h dec -640 if sy > 3324\n" +
                                        "zwq inc -743 if jke < 5478\n" +
                                        "w inc 13 if w <= -7770 \n" +
                                        "u dec 806 if si < 1843 \n" +
                                        "w dec 499 if si != 1826\n" +
                                        "wg inc -535 if uz >= 61\n" +
                                        "ubi inc -110 if si >= 1845\n" +
                                        "xf inc -114 if qin > 397\n" +
                                        "ke inc -509 if wg < 1747\n" +
                                        "xf dec -591 if t != -2181 \n" +
                                        "ubi dec -5 if ubi < 3952\n" +
                                        "xf inc -123 if wg != 1744 \n" +
                                        "u inc -84 if nfi < -1452\n" +
                                        "qin dec 489 if zwq != 387 \n" +
                                        "z dec 399 if o == 2246 \n" +
                                        "yu dec -468 if xf > 3145\n" +
                                        "zwq inc -882 if si == 1835\n" +
                                        "h dec 771 if he >= -1937\n" +
                                        "wg inc 11 if ubi < 3961\n" +
                                        "a inc -500 if ty < -3081\n" +
                                        "uz inc 809 if zwx < 1780\n" +
                                        "yf inc 364 if xf == 3148\n" +
                                        "o inc 324 if si == 1835\n" +
                                        "ke dec -113 if f < -215\n" +
                                        "xf inc 921 if uz > 872 \n" +
                                        "zwx inc 143 if h <= -1974 \n" +
                                        "t dec 163 if o > 2565\n" +
                                        "o dec -177 if si <= 1838\n" +
                                        "ubi dec -200 if fkh <= -1219 \n" +
                                        "ke inc -62 if t <= -2340\n" +
                                        "f inc 546 if si >= 1830\n" +
                                        "t inc 467 if fkh >= -1226 \n" +
                                        "z inc -229 if he < -1935\n" +
                                        "hx inc -486 if ubi < 4159 \n" +
                                        "wg inc -290 if o < 2748\n" +
                                        "zwq dec 950 if ty < -3083 \n" +
                                        "ubi inc 78 if uz != 886\n" +
                                        "h inc -842 if z <= -3331\n" +
                                        "ke inc 562 if fkh != -1233\n" +
                                        "u inc -464 if qin != -94\n" +
                                        "he inc 960 if wg == 1465\n" +
                                        "o dec -705 if a < 189\n" +
                                        "qin dec -769 if wg <= 1467\n" +
                                        "qin inc -43 if si < 1844\n" +
                                        "he inc -571 if yf == 1041 \n" +
                                        "o inc 436 if t > -1883 \n" +
                                        "zwq dec 839 if jke == 5484\n" +
                                        "z dec -233 if u <= 202 \n" +
                                        "wg inc -313 if hx >= -451 \n" +
                                        "ty inc 552 if zwx < 1913\n" +
                                        "ke inc 204 if si > 1826\n" +
                                        "yf inc -924 if si < 1840\n" +
                                        "u dec -30 if a < 197\n" +
                                        "z dec -753 if ke == -2523 \n" +
                                        "qin dec -755 if uz <= 871 \n" +
                                        "ke inc -787 if z > -2357\n" +
                                        "si inc -676 if qin <= 643 \n" +
                                        "hx dec 301 if zwq != -2277\n" +
                                        "xp dec 617 if z <= -2346\n" +
                                        "ubi inc -445 if xp != -1529\n" +
                                        "h inc -784 if qin == 640\n" +
                                        "ty dec 524 if wg < 1143\n" +
                                        "t inc 313 if yu >= 701 \n" +
                                        "zwq dec -716 if zwq < -2279\n" +
                                        "ke inc 258 if sy == 3332\n" +
                                        "wg dec -495 if w >= -8269 \n" +
                                        "nfi inc -327 if uz >= 877 \n" +
                                        "f inc -940 if zwx != 1923 \n" +
                                        "jke inc -886 if uz <= 868 \n" +
                                        "yu inc -619 if f >= -595\n" +
                                        "he inc -738 if h != -3613 \n" +
                                        "fkh dec 354 if jke != 5486\n" +
                                        "h inc -6 if nfi != -1783\n" +
                                        "jke inc -691 if zwx < 1919\n" +
                                        "uz inc 142 if nfi == -1788\n" +
                                        "wg dec -303 if a > 186 \n" +
                                        "jke dec -797 if yf >= 115 \n" +
                                        "a dec -4 if xf <= 4075 \n" +
                                        "xp dec -517 if zwx < 1919 \n" +
                                        "xp inc -983 if ke >= -3050\n" +
                                        "f dec -83 if si != 1159\n" +
                                        "uz dec 110 if nfi >= -1793\n" +
                                        "si inc 219 if fkh != -1581\n" +
                                        "wg dec 946 if w < -8263\n" +
                                        "zwx dec -809 if nfi >= -1791 \n" +
                                        "uz inc 664 if ty >= -3089 \n" +
                                        "xp dec -210 if zwq != -2272\n" +
                                        "z inc -359 if ke > -3045\n" +
                                        "ke dec 863 if o == 3183\n" +
                                        "ty inc -748 if yu == 708\n" +
                                        "ty dec 539 if uz >= 1571\n" +
                                        "xp dec 666 if zwq < -2271 \n" +
                                        "z dec 282 if h == -3615\n" +
                                        "u inc -702 if hx < -437\n" +
                                        "o dec -741 if yf > 114 \n" +
                                        "h dec -238 if o > 3917 \n" +
                                        "jke inc -344 if yf <= 118 \n" +
                                        "qin dec -774 if qin < 648 \n" +
                                        "xf dec -228 if uz < 1580\n" +
                                        "ubi inc 428 if f <= -602\n" +
                                        "yu inc -964 if xp < -1479 \n" +
                                        "wg dec -725 if he <= -2273\n" +
                                        "sy inc 913 if ty <= -4378 \n" +
                                        "xf inc 936 if nfi < -1796 \n" +
                                        "yf inc 100 if xp > -1481\n" +
                                        "jke dec 876 if zwq == -2277\n" +
                                        "yu dec 373 if w > -8269\n" +
                                        "hx dec -542 if fkh >= -1572\n" +
                                        "xf inc 41 if yf >= 215 \n" +
                                        "w inc -491 if qin < 1422\n" +
                                        "jke inc 643 if a == 200\n" +
                                        "si inc -74 if he == -2278 \n" +
                                        "qin dec 842 if jke >= 5004\n" +
                                        "hx inc -797 if jke != 5009\n" +
                                        "sy dec 444 if uz != 1577\n" +
                                        "jke inc -606 if hx != -1244\n" +
                                        "qin inc -381 if sy > 2886 \n" +
                                        "yf dec -922 if qin >= 184 \n" +
                                        "ke inc 689 if ke > -3920\n" +
                                        "yf dec 850 if yf <= 1141\n" +
                                        "yu inc -120 if w >= -8750 \n" +
                                        "ke inc 613 if uz != 1582\n" +
                                        "hx inc 620 if xf <= 4351\n" +
                                        "sy inc -631 if hx > -627\n" +
                                        "xp dec -781 if fkh <= -1569\n" +
                                        "nfi dec 196 if sy >= 2266 \n" +
                                        "f dec -69 if yu >= 330 \n" +
                                        "o inc 492 if ke > -2616\n" +
                                        "sy dec -837 if sy <= 2262 \n" +
                                        "xf dec 862 if a != 203 \n" +
                                        "yf inc -182 if zwq < -2272\n" +
                                        "wg inc -534 if o != 4406\n" +
                                        "si dec 788 if h > -3381\n" +
                                        "ty inc -85 if zwx == 2727 \n" +
                                        "w inc 942 if hx == -619\n" +
                                        "o inc -880 if a >= 200 \n" +
                                        "uz inc 654 if zwx <= 2732 \n" +
                                        "u dec -710 if he != -2278 \n" +
                                        "zwq dec -920 if f < -530\n" +
                                        "jke dec 21 if z > -2644\n" +
                                        "qin dec 529 if f != -537\n" +
                                        "jke inc -901 if u <= -470 \n" +
                                        "w inc 900 if nfi <= -1783 \n" +
                                        "ke inc 624 if o == 3536\n" +
                                        "wg dec 784 if qin == -338 \n" +
                                        "yf dec 682 if w <= -6921\n" +
                                        "a dec 593 if sy <= 3097\n" +
                                        "xf dec 442 if hx != -616\n" +
                                        "nfi inc 852 if z == -2634 \n" +
                                        "yf dec -338 if zwx < 2732 \n" +
                                        "qin dec 511 if ty > -4451 \n" +
                                        "xf dec -512 if si >= 508\n" +
                                        "u dec 172 if xf <= 3558\n" +
                                        "w dec -255 if jke >= 3476 \n" +
                                        "zwq inc -879 if wg >= 408 \n" +
                                        "zwx inc -498 if si < 518\n" +
                                        "xp dec -405 if f == -536\n" +
                                        "qin inc -76 if a != -391\n" +
                                        "nfi inc -734 if a >= -397 \n" +
                                        "h dec -940 if o < 3541 \n" +
                                        "o dec -41 if qin != -412\n" +
                                        "f dec -736 if h < -2436\n" +
                                        "fkh inc -180 if yu > 327\n" +
                                        "u inc 73 if ke < -1981 \n" +
                                        "xf inc 932 if he > -2288\n" +
                                        "wg inc 103 if fkh < -1754 \n" +
                                        "fkh inc 872 if fkh < -1757\n" +
                                        "xp dec 679 if si != 526\n" +
                                        "z inc 486 if w > -6661 \n" +
                                        "jke inc -909 if f == 200\n" +
                                        "qin dec 443 if uz < 2223\n" +
                                        "f dec -653 if hx > -626\n" +
                                        "qin dec -106 if nfi >= -1675 \n" +
                                        "uz inc 969 if uz == 2228\n" +
                                        "t inc -474 if w > -6660\n" +
                                        "xf inc -898 if f <= 854\n" +
                                        "zwq inc -246 if a <= -398 \n" +
                                        "yf dec -931 if nfi <= -1665\n" +
                                        "h inc 770 if ty > -4461\n" +
                                        "u inc -20 if z == -2148\n" +
                                        "wg inc -317 if z == -2138 \n" +
                                        "t inc -73 if a >= -384 \n" +
                                        "xp dec -372 if fkh > -885 \n" +
                                        "hx dec -592 if yu < 342\n" +
                                        "a inc 357 if uz == 3197\n" +
                                        "zwq dec 13 if si <= 520\n" +
                                        "h inc 97 if f <= 847\n" +
                                        "qin inc 133 if yu < 341\n" +
                                        "ty inc -437 if ke > -1988 \n" +
                                        "ty dec -281 if yf <= 1374 \n" +
                                        "uz inc 0 if xf < 3595\n" +
                                        "o inc -303 if fkh < -876\n" +
                                        "h inc -594 if yu == 335\n" +
                                        "zwq dec 422 if qin <= -173\n" +
                                        "xf dec 44 if u == -594 \n" +
                                        "hx dec -264 if sy != 3087 \n" +
                                        "si inc 539 if qin == -181 \n" +
                                        "ke dec -667 if si < 523\n" +
                                        "uz dec 309 if he < -2269\n" +
                                        "yf inc -394 if zwx <= 2238\n" +
                                        "o inc -572 if w <= -6664\n" +
                                        "z inc 241 if t <= -2045\n" +
                                        "qin dec 285 if a < -27 \n" +
                                        "xp dec 413 if zwq < -2667 \n" +
                                        "ubi inc 317 if t >= -2033 \n" +
                                        "yu inc -173 if sy <= 3094 \n" +
                                        "nfi inc -262 if zwq <= -2669 \n" +
                                        "a inc 98 if uz > 2878\n" +
                                        "sy inc 513 if wg == 514\n" +
                                        "yu inc -841 if ke != -1331\n" +
                                        "ke inc -426 if ubi != 4220\n" +
                                        "he dec 187 if he != -2277 \n" +
                                        "fkh dec 717 if zwq >= -2661\n" +
                                        "f dec -191 if uz <= 2893\n" +
                                        "zwx dec -661 if yf != 972 \n" +
                                        "fkh dec -112 if ubi <= 4220\n" +
                                        "ty dec 800 if fkh >= -775 \n" +
                                        "sy inc 981 if xp > -1389\n" +
                                        "xp inc 893 if wg <= 510\n" +
                                        "nfi inc 944 if qin != -458\n" +
                                        "zwq inc -250 if qin != -454\n" +
                                        "uz inc -398 if jke != 2577\n" +
                                        "w dec -486 if hx >= 230\n" +
                                        "z dec -205 if xf < 3551\n" +
                                        "f dec 777 if xf == 3542\n" +
                                        "wg inc 667 if zwx != 2880 \n" +
                                        "z dec -851 if ty != -5258 \n" +
                                        "w dec 653 if t < -2036 \n" +
                                        "he inc 459 if z > -1091\n" +
                                        "yf dec 331 if si != 516\n" +
                                        "zwx dec 327 if qin < -452 \n" +
                                        "xf dec -293 if wg == 1181 \n" +
                                        "fkh inc -469 if yu >= -679\n" +
                                        "a dec 440 if f >= 261\n" +
                                        "he dec -292 if xf >= 3833 \n" +
                                        "xf inc 405 if uz == 2490\n" +
                                        "si inc 825 if sy <= 4588\n" +
                                        "ubi dec 306 if z != -1085 \n" +
                                        "fkh dec -949 if jke < 2577\n" +
                                        "zwx dec 703 if o <= 3280\n" +
                                        "hx inc 951 if o >= 3268\n" +
                                        "ke inc 134 if z != -1088\n" +
                                        "w inc -621 if o <= 3274\n" +
                                        "sy inc 883 if he == -2177 \n" +
                                        "w dec -900 if jke >= 2586 \n" +
                                        "sy inc -56 if xf >= 4232\n" +
                                        "si dec -994 if zwx == 1860\n" +
                                        "u inc 726 if yu <= -675\n" +
                                        "si inc 989 if u <= 140 \n" +
                                        "yf dec 609 if si > 3324\n" +
                                        "jke inc -872 if si < 3323 \n" +
                                        "hx dec 873 if ubi < 3917\n" +
                                        "xp dec -284 if o <= 3280\n" +
                                        "zwq dec -69 if o <= 3280\n" +
                                        "yf inc 921 if he < -2169\n" +
                                        "wg dec -859 if h >= -2257 \n" +
                                        "nfi inc -605 if u != 132\n" +
                                        "fkh inc -567 if yu > -682 \n" +
                                        "w dec 260 if ty < -5262\n" +
                                        "si dec -809 if h != -2258 \n" +
                                        "f dec 604 if qin > -460\n" +
                                        "nfi dec 603 if ke < -1609 \n" +
                                        "jke inc -568 if nfi == -1583 \n" +
                                        "ke dec 694 if a <= -378\n" +
                                        "t inc -188 if yu != -681\n" +
                                        "fkh dec 328 if w >= -7445 \n" +
                                        "fkh inc 27 if si >= 4126\n" +
                                        "o dec -358 if f >= 267 \n" +
                                        "xf inc -895 if ubi < 3913 \n" +
                                        "fkh dec 829 if ke < -2315 \n" +
                                        "qin dec 41 if uz == 2490\n" +
                                        "sy inc 649 if f != 259 \n" +
                                        "wg inc 807 if t < -2224\n" +
                                        "ubi inc 580 if w == -7446 \n" +
                                        "jke dec -195 if zwx == 1860\n" +
                                        "f inc -722 if si < 4131\n" +
                                        "xp inc -694 if xp > -1097 \n" +
                                        "yu inc 810 if h == -2261\n" +
                                        "f inc -521 if uz == 2499\n" +
                                        "sy inc -534 if xp >= -1107\n" +
                                        "zwq dec 330 if nfi <= -1582\n" +
                                        "ke dec -846 if xp == -1098\n" +
                                        "h inc -585 if o != 3639\n" +
                                        "nfi inc 135 if yu <= 137\n" +
                                        "jke inc -779 if u != 138\n" +
                                        "a inc 509 if f > 265\n" +
                                        "uz inc -421 if h != -2848 \n" +
                                        "he inc -36 if h != -2840\n" +
                                        "o inc 458 if wg == 1988\n" +
                                        "h dec -88 if wg > 1987 \n" +
                                        "yf dec 98 if a == 131\n" +
                                        "h inc 729 if si != 4134\n" +
                                        "xp inc -973 if xf == 3345 \n" +
                                        "zwx dec -483 if z < -1089 \n" +
                                        "hx inc -171 if o > 4089\n" +
                                        "fkh dec -256 if nfi > -1462\n" +
                                        "xp inc 578 if h >= -2028\n" +
                                        "xp dec -194 if uz < 2062\n" +
                                        "ubi inc -933 if xf == 3347\n" +
                                        "h dec 944 if zwq == -3182 \n" +
                                        "u dec -139 if ubi >= 4481 \n" +
                                        "qin dec 581 if jke != 1998\n" +
                                        "ke dec 532 if yf >= 1805\n" +
                                        "sy inc -101 if fkh > -574 \n" +
                                        "w dec -934 if ubi < 4491\n" +
                                        "t dec 799 if sy <= 4638\n" +
                                        "he inc -446 if xp > -2075";
            Assert.AreEqual(4647, ClassUnderTest.GetLargestRegister(instructionPrimitives));
            Assert.AreEqual(5590, ClassUnderTest.HighestValue);
        }
    }
}
