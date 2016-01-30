using UnityEngine;
using System.Collections;

public class ThamsappPosts : MonoBehaviour {

	public int 		halfPostVar;
	public int		nounVar;
	public int 		secondHalfPostVar;
	public string	createdPost;

	public string[] myPosts =
	{ 
		"My", "just died",
		"I hate my boss, he is such a", 
		"MMM, I'm going to have", "for lunch",
		"Did anybody see my",
		"Frikking", "invading my country and stealing our",
		"I just bought a",
		"I painted my room in a", "colour",
		"This music sounds like", "music. I wished they played REAL music",
		"I tripped over a", "AGAIN! Stupid",
		"are the best",
		"I love my", "19-6-2010 never forget",
		"Wow check out this"
	};

	public string[] myHalfPosts =
	{
		"Wow check out this ",
		"I cannot believe ",
		"I watched ",
		"I'm walking my ",
		"Ugh, I have to make ",
		"Why stay ",
		"I need some ",
		"I hate it when ",
		"Why is there a ",
		"I'm rooting for my home team the "
	};

	public string[] mySecondHalfPosts =
	{
		" it's so crazy",
		" is cured",
		" for 12 hours",
		" what a disgrace",
		" I could never be happier",
		" I'm getting too old for this",
		" at this tailgate?",
	};


	void Start () {
		halfPostVar 		= myHalfPosts.Length;
		nounVar				= GetComponent<SubjectList>().mySubjects.Length;
		secondHalfPostVar 	= mySecondHalfPosts.Length;
		print(nounVar);
	}
	
	// Update is called once per frame
	void Update () {
		CreateSentence ();
	}

	void ChooseFromList (){
		halfPostVar 		= Random.Range(0, myHalfPosts.Length);
		nounVar				= Random.Range(0, GetComponent<SubjectList>().mySubjects.Length);
		secondHalfPostVar	= Random.Range(0, mySecondHalfPosts.Length);
	}

	void CreateSentence (){
		ChooseFromList ();
		createdPost = myHalfPosts[halfPostVar] + GetComponent<SubjectList>().mySubjects[nounVar] + mySecondHalfPosts[secondHalfPostVar];
	}

}
