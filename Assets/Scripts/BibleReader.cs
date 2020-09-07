using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
// This file can be used one of two ways.  It can be used as an API to get text from the Bible, or as a Bible viewer. Using it as a Bible viewer requires the scene to be setup properly with the proper scroll views and buttons. It also would require the main text box to be linked in the editor.
public class BibleReader : MonoBehaviour {
	public Text Text;
    private BibleBookNameAgent biblebooknameagent;	
	private GameObject changer;
	private GameObject chapternum;
	private GameObject scroller;
	private string Book = "GEN";
	private int Chapter = 1;
	private string[] biblelines = {};
	// Use this for initialization
	void Start () {
		// Detects if we are in viewer mode. 
		if (Text)
		{
			scroller = GameObject.Find("ScrollView");
			scroller.GetComponent<ScrollRect>().verticalNormalizedPosition = 0.5f;
			regenthebible();	
		}
		//here  are some examples of how it could be used as an API.
		//Debug.Log(GetBibleChapterTextFromWholeBookName("John","1"));
		//Debug.Log(GetBibleChapterText("JOH","1"));
		//Debug.Log(GetBibleVerseText("John 3:16"));
		
	}
	// Update is called once per frame
	void Update () {
		// Detects if we are in viewer mode.
		if (Text)
		{
			updatebibleview();
		}

	}
	// This method uses the abbrivations in the text file
	public string GetBibleChapterText(String TheBook, String TheChapter){
  	 	var textFile = Resources.Load<TextAsset>("Text/eng-web_vpl");
   	 	biblelines = textFile.ToString().Split('\n'); 
		string bibleverseview = "";
		string allverses = "";
		foreach (string line in biblelines)
		{
		    if (line.Contains(TheBook + " " + TheChapter + ":"))
		    {
				bibleverseview = line.Replace(TheBook + " ", "");
				allverses = allverses + "\n" +bibleverseview;
		    }
		}
		return allverses;
		
	}
	// This method uses the full book names
	public string GetBibleChapterTextFromWholeBookName(String TheBook, String TheChapter){
  	 	var textFile = Resources.Load<TextAsset>("Text/eng-web_vpl");
   	 	biblelines = textFile.ToString().Split('\n'); 
		BibleBookNameAgent BookAgent = new BibleBookNameAgent();
		string sourcebook = BookAgent.BookNameToAbbreviation(TheBook + " ");	
		string sourcebook2 = sourcebook.Replace(" ", "");
		TheBook = sourcebook2;
		string bibleverseview = "";
		string allverses = "";
		foreach (string line in biblelines)
		{
		    if (line.Contains(TheBook + " " + TheChapter + ":"))
		    {
				bibleverseview = line.Replace(TheBook + " ", "");
				allverses = allverses + "\n" +bibleverseview;
		    }
		}
		return allverses;
		
	}
	public string GetBibleVerseText(String BookAndVerseNumber){
  	 	var textFile = Resources.Load<TextAsset>("Text/eng-web_vpl");
   	 	biblelines = textFile.ToString().Split('\n'); 
		// first, try to load a verse from an abbrivation.
		string source = BookAndVerseNumber;
		string bibleverse = "";
		foreach (string line in biblelines)
		{
			 if (line.Contains(source.ToUpper() + " "))
			 {
				 bibleverse = line.Replace(source.ToUpper(), "");
			 }
		}
		// if that did not work, try to load a verse from a full book name.
		if (bibleverse == "")
		{
	  	    try
	  	    {
				BibleBookNameAgent BookAgent = new BibleBookNameAgent();
				string sourceversed = BookAgent.BookNameToAbbreviation(source);	
				foreach (string line in biblelines)
				{
					 if (line.Contains(sourceversed.ToUpper() + " "))
					 {
						 bibleverse = line.Replace(sourceversed.ToUpper(), "");
					 }
				}
			 }
	  	    catch
	  	    {	
				bibleverse = "Verse not found";	  
	  	    }

		}
		return bibleverse;
		
	}
	// This is all code for the Bible viewer. It will not run if we are using this script as an API.
	private void updatebibleview() {
		changer = GameObject.Find("Changer");
		chapternum = GameObject.Find("ChapterNUM");
		scroller = GameObject.Find("ScrollView");
	    int menuIndex = changer.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData>menuOptions = changer.GetComponent<Dropdown>().options;
        string value = menuOptions[menuIndex].text; 
		if (value != Book)
		{
			Chapter=1;
			Book=value;
			regenthebible();
			scroller.GetComponent<ScrollRect>().verticalNormalizedPosition = 0.5f;
		}
		if (Chapter ==0)
		{
			Chapter=1;
			regenthebible();
		}
		if (scroller.GetComponent<ScrollRect>().verticalNormalizedPosition > 0.5)
		{
			scroller.GetComponent<ScrollRect>().verticalNormalizedPosition = 0.5f;
		}
        string chhapper = chapternum.GetComponent<Text>().text;
		chapternum.GetComponent<Text>().text=(Chapter.ToString());		
	}
	private void regenthebible() {
		Text.text = GetBibleChapterText(Book,Chapter.ToString());
		scroller = GameObject.Find("ScrollView");
		scroller.GetComponent<ScrollRect>().verticalNormalizedPosition = 0.5f;
		
	}
	private void upchapter () {
		Chapter=Chapter+1;	
		regenthebible();
	}
	private void dwnchapter () {
		Chapter=Chapter-1;	
		regenthebible();
	}
	
	
}
