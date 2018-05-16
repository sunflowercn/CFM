using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace win.Util
{   
    public static class Util_PinYin1
    {
        private static string[] FirstLetter = null;//存放国标一级汉字不同读音的起始区位码对应读音    
        private static String SecondSecTable = string.Empty;//存放所有国标二级汉字读音   
        private static int[] SecPosValue = null;//存放国标一级汉字不同读音的起始区位码   

        static Util_PinYin1()
        {
            SecPosValue = new int[23] { 1601, 1637, 1833, 2078, 2274, 2302, 2433, 2594, 2787, 3106, 3212, 3472, 3635, 3722, 3730, 3858, 4027, 4086, 4390, 4558, 4684, 4925, 5249 };
            FirstLetter = new string[23] { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "W", "X", "Y", "Z" };
            SecondSecTable = "CJWGNSPGCGNE[Y[BTYYZDXYKYGT[JNNJQMBSGZSCYJSYY[PGKBZGY[YWJKGKLJYWKPJQHY[W[DZLSGMRYPYWWCCKZNKYYGTTNJJNYKKZYTCJNMCYLQLYPYQFQRPZSLWBT"
                               + "GKJFYXJWZLTBNCXJJJJTXDTTSQZYCDXXHGCK[PHFFSS[YBGXLPPBYLL[HLXS[ZM[JHSOJNGHDZQYKLGJHSGQZHXQGKEZZWYSCSCJXYEYXADZPMDSSMZJZQJYZC[J[WQJB"
                               + "YZPXGZNZCPWHKXHQKMWFBPBYDTJZZKQHYLYGXFPTYJYYZPSZLFCHMQSHGMXXSXJ[[DCSBBQBEFSJYHXWGZKPYLQBGLDLCCTNMAYDDKSSNGYCSGXLYZAYBNPTSDKDYLHGY"
                               + "MYLCXPY[JNDQJWXQXFYYFJLEJPZRXCCQWQQSBNKYMGPLBMJRQCFLNYMYQMSQYRBCJTHZTQFRXQHXMJJCJLXQGJMSHZKBSWYEMYLTXFSYDSWLYCJQXSJNQBSCTYHBFTDCY"
                               + "ZDJWYGHQFRXWCKQKXEBPTLPXJZSRMEBWHJLBJSLYYSMDXLCLQKXLHXJRZJMFQHXHWYWSBHTRXXGLHQHFNM[YKLDYXZPYLGG[MTCFPAJJZYLJTYANJGBJPLQGDZYQYAXBK"
                               + "YSECJSZNSLYZHSXLZCGHPXZHZNYTDSBCJKDLZAYFMYDLEBBGQYZKXGLDNDNYSKJSHDLYXBCGHXYPKDJMMZNGMMCLGWZSZXZJFZNMLZZTHCSYDBDLLSCDDNLKJYKJSYCJL"
                               + "KWHQASDKNHCSGANHDAASHTCPLCPQYBSDMPJLPZJOQLCDHJJYSPRCHN[NNLHLYYQYHWZPTCZGWWMZFFJQQQQYXACLBHKDJXDGMMYDJXZLLSYGXGKJRYWZWYCLZMSSJZLDB"
                               + "YD[FCXYHLXCHYZJQ[[QAGMNYXPFRKSSBJLYXYSYGLNSCMHZWWMNZJJLXXHCHSY[[TTXRYCYXBYHCSMXJSZNPWGPXXTAYBGAJCXLY[DCCWZOCWKCCSBNHCPDYZNFCYYTYC"
                               + "KXKYBSQKKYTQQXFCWCHCYKELZQBSQYJQCCLMTHSYWHMKTLKJLYCXWHEQQHTQH[PQ[QSCFYMNDMGBWHWLGSLLYSDLMLXPTHMJHWLJZYHZJXHTXJLHXRSWLWZJCBXMHZQXS"
                               + "DZPMGFCSGLSXYMJSHXPJXWMYQKSMYPLRTHBXFTPMHYXLCHLHLZYLXGSSSSTCLSLDCLRPBHZHXYYFHB[GDMYCNQQWLQHJJ[YWJZYEJJDHPBLQXTQKWHLCHQXAGTLXLJXMS"
                               + "L[HTZKZJECXJCJNMFBY[SFYWYBJZGNYSDZSQYRSLJPCLPWXSDWEJBJCBCNAYTWGMPAPCLYQPCLZXSBNMSGGFNZJJBZSFZYNDXHPLQKZCZWALSBCCJX[YZGWKYPSGXFZFC"
                               + "DKHJGXDLQFSGDSLQWZKXTMHSBGZMJZRGLYJBPMLMSXLZJQQHZYJCZYDJWBMYKLDDPMJEGXYHYLXHLQYQHKYCWCJMYYXNATJHYCCXZPCQLBZWWYTWBQCMLPMYRJCCCXFPZ"
                               + "NZZLJPLXXYZTZLGDLDCKLYRZZGQTGJHHGJLJAXFGFJZSLCFDQZLCLGJDJCSNZLLJPJQDCCLCJXMYZFTSXGCGSBRZXJQQCTZHGYQTJQQLZXJYLYLBCYAMCSTYLPDJBYREG"
                               + "KLZYZHLYSZQLZNWCZCLLWJQJJJKDGJZOLBBZPPGLGHTGZXYGHZMYCNQSYCYHBHGXKAMTXYXNBSKYZZGJZLQJDFCJXDYGJQJJPMGWGJJJPKQSBGBMMCJSSCLPQPDXCDYYK"
                               + "Y[CJDDYYGYWRHJRTGZNYQLDKLJSZZGZQZJGDYKSHPZMTLCPWNJAFYZDJCNMWESCYGLBTZCGMSSLLYXQSXSBSJSBBSGGHFJLYPMZJNLYYWDQSHZXTYYWHMZYHYWDBXBTLM"
                               + "SYYYFSXJC[DXXLHJHF[SXZQHFZMZCZTQCXZXRTTDJHNNYZQQMNQDMMG[YDXMJGDHCDYZBFFALLZTDLTFXMXQZDNGWQDBDCZJDXBZGSQQDDJCMBKZFFXMKDMDSYYSZCMLJ"
                               + "DSYNSBRSKMKMPCKLGDBQTFZSWTFGGLYPLLJZHGJ[GYPZLTCSMCNBTJBQFKTHBYZGKPBBYMTDSSXTBNPDKLEYCJNYDDYKZDDHQHSDZSCTARLLTKZLGECLLKJLQJAQNBDKK"
                               + "GHPJTZQKSECSHALQFMMGJNLYJBBTMLYZXDCJPLDLPCQDHZYCBZSCZBZMSLJFLKRZJSNFRGJHXPDHYJYBZGDLQCSEZGXLBLGYXTWMABCHECMWYJYZLLJJYHLG[DJLSLYGK"
                               + "DZPZXJYYZLWCXSZFGWYYDLYHCLJSCMBJHBLYZLYCBLYDPDQYSXQZBYTDKYXJY[CNRJMPDJGKLCLJBCTBJDDBBLBLCZQRPPXJCJLZCSHLTOLJNMDDDLNGKAQHQHJGYKHEZ"
                               + "NMSHRP[QQJCHGMFPRXHJGDYCHGHLYRZQLCYQJNZSQTKQJYMSZSWLCFQQQXYFGGYPTQWLMCRNFKKFSYYLQBMQAMMMYXCTPSHCPTXXZZSMPHPSHMCLMLDQFYQXSZYYDYJZZ"
                               + "HQPDSZGLSTJBCKBXYQZJSGPSXQZQZRQTBDKYXZKHHGFLBCSMDLDGDZDBLZYYCXNNCSYBZBFGLZZXSWMSCCMQNJQSBDQSJTXXMBLTXZCLZSHZCXRQJGJYLXZFJPHYMZQQY"
                               + "DFQJJLZZNZJCDGZYGCTXMZYSCTLKPHTXHTLBJXJLXSCDQXCBBTJFQZFSLTJBTKQBXXJJLJCHCZDBZJDCZJDCPRNPQCJPFCZLCLZXZDMXMPHJSGZGSZZQLYLWTJPFSYASM"
                               + "CJBTZKYCWMYTCSJJLJCQLWZMALBXYFBPNLSFHTGJWEJJXXGLLJSTGSHJQLZFKCGNNNSZFDEQFHBSAQTGYLBXMMYGSZLDYDQMJJRGBJTKGDHGKBLQKBDMBYLXWCXYTTYBK"
                               + "MRTJZXQJBHLMHMJJZMQASLDCYXYQDLQCAFYWYXQHZ";
        }

        private static Int32 SectorCode(char chr)
        {
            Encoding ecode = Encoding.GetEncoding("GB18030");
            Byte[] codeBytes = ecode.GetBytes(chr.ToString());
            return (int)codeBytes[0];
        }

        private static Int32 PositionCode(char chr)
        {
            Encoding ecode = Encoding.GetEncoding("GB18030");
            Byte[] codeBytes = ecode.GetBytes(chr.ToString());
            return (int)codeBytes[1];
        }

        public static string GetFirstLetter(string str)
        {
            String Temp_ch = string.Empty;//临时单元
            String ReturnStr = string.Empty; //返回串  
            int li_SectorCode; //汉字区码  
            int li_PositionCode; //汉字位码   
            int li_SecPosCode; //汉字区位码   
            int li_offset; //二级字库偏移量   
            char[] chineseStr;
            chineseStr = str.ToCharArray();
            for (int i = 0; i < str.Length; i++) //依次处理str中每个字符  
            {
                if ((SectorCode(chineseStr[i]) >= 65 && SectorCode(chineseStr[i]) <= 90) || //大写字母
                        (SectorCode(chineseStr[i]) >= 97 && SectorCode(chineseStr[i]) <= 122)) //小写字母
                {
                    ReturnStr = ReturnStr + str[i].ToString().ToUpper();//统一转换为大写  
                }
                else if (SectorCode(str[i]) >= 128) //是汉字 
                {
                    li_SectorCode = SectorCode(str[i]) - 160;//区码   

                    li_PositionCode = PositionCode(str[i]) - 160;//位码   

                    li_SecPosCode = li_SectorCode * 100 + li_PositionCode; //区位码   

                    if (li_SecPosCode > 1600 && li_SecPosCode < 5590) //第一个字符
                    {
                        for (int j = 23; j >= 1; j--)//找声母   
                        {
                            if (li_SecPosCode >= SecPosValue[j - 1])
                            {
                                ReturnStr = ReturnStr + FirstLetter[j - 1];
                                break;
                            }
                        }
                    }
                    else
                    {
                        li_offset = (li_SectorCode - 56) * 94 + li_PositionCode - 1; //计算偏移量
                        if (li_offset >= 0 && li_offset <= 3007) //二区汉字
                        {
                            ReturnStr = ReturnStr + SecondSecTable.Substring(li_offset, 1); //取出此字声母   
                        }
                    }
                }
                else
                {
                    ReturnStr = ReturnStr + str[i].ToString();
                }
            }
            return ReturnStr; //返回声母串
        }
    }
}
