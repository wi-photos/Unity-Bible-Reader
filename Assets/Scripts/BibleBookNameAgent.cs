using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Globalization;
// This is a class file which can convert the Bible book abbreviations back and forth.
public class BibleBookNameAgent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		// some examples of how this would be used.
        // Debug.Log(AbbreviationToBookName("PSA 1:1")); 
	    //Debug.Log(BookNameToAbbreviation("Genesis 3:16"));
    }

    // Update is called once per frame
    void Update()
    {
    }
	public string BookNameToAbbreviation(string InputText) 
	{
	    string inputinitial = InputText;
	    //string input = @" " + inputinitial;
		string num1 = inputinitial.Replace("1 ", "1_");
		string num2 = num1.Replace("2 ", "2_");
		string num3 = num2.Replace("3 ", "3_");
		string num4 = num3.Replace("4 ", "4_");
		// big hack. replace some chars in books that have spaces.
		string num5 = num4.Replace("g o", "g_o");
		string num6 = num5.Replace("f S", "f_S");
		string num7 = num6.Replace("m o", "m_o");
		string num8 = num7.Replace("f S", "f_S");
		string num9 = num8.Replace("k E", "k_E");
		string num10 = num9.Replace("r o", "r_o");
		string num11 = num10.Replace("f M", "f_M");
		string num12 = num11.Replace("alm 15", "alm_15");
		string num13 = num12.Replace("l (", "l_(");
		string input = @" " + num13;
	    var args = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
		args.Add("Genesis","GEN ");
		args.Add("Exodus","EXO ");
		args.Add("Leviticus","LEV ");
		args.Add("Numbers","NUM ");
		args.Add("Deuteronomy","DEU ");
		args.Add("Joshua","JOS ");
		args.Add("Judges","JDG ");
		args.Add("Ruth","RUT ");
		args.Add("1_Samuel","1SA ");
		args.Add("2_Samuel","2SA ");
		args.Add("1_Kings","1KI ");
		args.Add("2_Kings","2KI ");
		args.Add("1_Chronicles","1CH ");
		args.Add("2_Chronicles","2CH ");
		args.Add("Ezra","EZR ");
		args.Add("Nehemiah","NEH ");
		args.Add("Esther","EST ");
		args.Add("Job","JOB ");
		args.Add("Psalm","PSA ");
		args.Add("Proverbs","PRO ");
		args.Add("Ecclesiastes","ECC ");
		args.Add("Song_of_Songs","SOL ");
		args.Add("Isaiah","ISA ");
		args.Add("Jeremiah","JER ");
		args.Add("Lamentations","LAM ");
		args.Add("Ezekiel","EZE ");
		args.Add("Daniel","DAN ");
		args.Add("Hosea","HOS ");
		args.Add("Joel","JOE ");
		args.Add("Amos","AMO ");
		args.Add("Obadiah","OBA ");
		args.Add("Jonah","JON ");
		args.Add("Micah","MIC ");
		args.Add("Nahum","NAH ");
		args.Add("Habakkuk","HAB ");
		args.Add("Zephaniah","ZEP ");
		args.Add("Haggai","HAG ");
		args.Add("Zechariah","ZEC ");
		args.Add("Malachi","MAL ");
		args.Add("Tobit","TOB ");
		args.Add("Judith","JDT ");
		args.Add("Greek_Esther","ESG ");
		args.Add("Wisdom_of_Solomon","WIS ");
		args.Add("Wisdom_of_Sirach","SIR ");
		args.Add("Baruch","BAR ");
		args.Add("1_Maccabees","1MA ");
		args.Add("2_Maccabees","2MA ");
		args.Add("1_Esdras","1ES ");
		args.Add("Prayer_of_Manasseh","PRM ");
		args.Add("Psalm_151","PSX ");
		args.Add("3_Maccabees","3MA ");
		args.Add("4_Esdras","4ES ");
		args.Add("4_Maccabees","4MA ");
		args.Add("Daniel_(Greek)","DNG ");
		args.Add("Matthew","MAT ");
		args.Add("Mark","MAR ");
		args.Add("Luke","LUK ");
		args.Add("John","JOH ");
		args.Add("Acts","ACT ");
		args.Add("Romans","ROM ");
		args.Add("1_Corinthians","1CO ");
		args.Add("2_Corinthians","2CO ");
		args.Add("Galatians","GAL ");
		args.Add("Ephesus","EPH ");
		args.Add("Philippians","PHI ");
		args.Add("Colossians","COL ");
		args.Add("1_Thessalonians","1TH ");
		args.Add("2_Thessalonians","2TH ");
		args.Add("1_Timothy","1TI ");
		args.Add("2_Timothy ","2TI ");
		args.Add("Titus","TIT ");
		args.Add("Philemon","PHM ");
		args.Add("Hebrews","HEB ");
		args.Add("James","JAM ");
		args.Add("1_Peter","1PE ");
		args.Add("2_Peter","2PE ");
		args.Add("1_John","1JO ");
		args.Add("2_John","2JO ");
		args.Add("3_John","2JO ");
		args.Add("Jude","JUD ");
		args.Add("Revelation","REV ");
	    Regex re = new Regex(@"\ (\w+)\ ", RegexOptions.Compiled);
	    string output = re.replaceTokens(input, args);
		return output;		
	}
	
	public string AbbreviationToBookName(string InputText) 
	{
	    string inputinitial = InputText;
	    string input = @" " + inputinitial;
	    var args = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
		args.Add("GEN","Genesis ");
		args.Add("EXO","Exodus ");
		args.Add("LEV","Leviticus ");
		args.Add("NUM","Numbers ");
		args.Add("DEU","Deuteronomy ");
		args.Add("JOS","Joshua ");
		args.Add("JDG","Judges ");
		args.Add("RUT","Ruth ");
		args.Add("1SA","1 Samuel ");
		args.Add("2SA","2 Samuel ");
		args.Add("1KI","1 Kings ");
		args.Add("2KI","2 Kings ");
		args.Add("1CH","1 Chronicles ");
		args.Add("2CH","2 Chronicles ");
		args.Add("EZR","Ezra ");
		args.Add("NEH","Nehemiah ");
		args.Add("EST","Esther ");
		args.Add("JOB","Job ");
		args.Add("PSA","Psalm ");
		args.Add("PRO","Proverbs ");
		args.Add("ECC","Ecclesiastes ");
		args.Add("SOL","Song of Songs ");
		args.Add("ISA","Isaiah ");
		args.Add("JER","Jeremiah ");
		args.Add("LAM","Lamentations ");
		args.Add("EZE","Ezekiel ");
		args.Add("DAN","Daniel ");
		args.Add("HOS","Hosea ");
		args.Add("JOE","Joel ");
		args.Add("AMO","Amos ");
		args.Add("OBA","Obadiah ");
		args.Add("JON","Jonah ");
		args.Add("MIC","Micah ");
		args.Add("NAH","Nahum ");
		args.Add("HAB","Habakkuk ");
		args.Add("ZEP","Zephaniah ");
		args.Add("HAG","Haggai ");
		args.Add("ZEC","Zechariah ");
		args.Add("MAL","Malachi ");
		args.Add("TOB","Tobit ");
		args.Add("JDT","Judith ");
		args.Add("ESG","Greek Esther ");
		args.Add("WIS","Wisdom of Solomon ");
		args.Add("SIR","Wisdom of Sirach ");
		args.Add("BAR","Baruch ");
		args.Add("1MA","1 Maccabees ");
		args.Add("2MA","2 Maccabees ");
		args.Add("1ES","1 Esdras ");
		args.Add("PRM","Prayer of Manasseh ");
		args.Add("PSX","Psalm 151 ");
		args.Add("3MA","3 Maccabees ");
		args.Add("4ES","4 Esdras ");
		args.Add("4MA","4 Maccabees ");
		args.Add("DNG","Daniel (Greek) ");
		args.Add("MAT","Matthew ");
		args.Add("MAR","Mark ");
		args.Add("LUK","Luke ");
		args.Add("JOH","John ");
		args.Add("ACT","Acts ");
		args.Add("ROM","Romans ");
		args.Add("1CO","1 Corinthians ");
		args.Add("2CO","2 Corinthians ");
		args.Add("GAL","Galatians ");
		args.Add("EPH","Ephesus ");
		args.Add("PHI","Philippians ");
		args.Add("COL","Colossians ");
		args.Add("1TH","1 Thessalonians ");
		args.Add("2TH","2 Thessalonians ");
		args.Add("1TI","1 Timothy ");
		args.Add("2TI","2 Timothy ");
		args.Add("TIT","Titus ");
		args.Add("PHM","Philemon ");
		args.Add("HEB","Hebrews ");
		args.Add("JAM","James ");
		args.Add("1PE","1 Peter ");
		args.Add("2PE","2 Peter ");
		args.Add("1JO","1 John ");
		args.Add("2JO","2 John ");
		args.Add("3JO","3 John ");
		args.Add("JUD","Jude ");
		args.Add("REV","Revelation ");
	    Regex re = new Regex(@"\ (\w+)\ ", RegexOptions.Compiled);
	    string output = re.replaceTokens(input, args);
		return output;
	}
}
public static class ReplaceTokensUsingDictionary
{
    public static string replaceTokens(this Regex re, string input, IDictionary<string, string> args)
    {
        return re.Replace(input, match => args[match.Groups[1].Value]);
    }
}