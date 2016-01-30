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
		"I'm rooting for my home team the ",
		"I'm the man of the ",
		"I'm dancing with my ",
		"I fell in love with a ",
		"Keano scratched his hairy back with his ",
		"I kissed a ",
		"Never again shall I lick this crazy ", 
		"I just completed hugging my ",
		"Cleaning my ",
		"Ha! I won an internet argument against ",
		"My fursona is a ",
		"Just go this ",
		"Only 90's kids will remember ",
		"Like if you want to have sex with a ",
		"I just got kicked in the groin by a full-blown ",
		"Man, I wanna get shitfaced and hump ",
		"I could enjoy some ",
		"Just fuck my"

	};

	public string[] mySecondHalfPosts =
	{
		" it's so crazy",
		" this made me unconfortable",
		" for 12 hours",
		" what a disgrace",
		" I could never be happier",
		" I'm getting too old for this",
		" I feel enligthend",
		" I guess it's accepted in some cultures...",
		" I'm never drinking again",
		" and I liked it",
		" It's just not right",
		" I wish I could get a degree in this...",
		" thorough",
		" makes me feel euphoric",
		"kin",
		" I will write a book about this",
		" I wish my life was more exciting",
		" this is why i voet trump!",
		" for every like I will do it again",
		" I wish I could die already",
		" Linkin Park sang about this"


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
