using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThumbsPost : TouchReceiver {

    [HideInInspector]
    public int toHeight = -1200;

    bool lastTurnActiveState = false;

    //public string[] blabla = { "", "", "" };

    public string[] fname =
    {
        "Harold ",
        "Rarity ",
        "Betsy ",
        "Berdy ",
        "Bennie ",
        "Anton ",
        "Michael ",
        "Danial ",
        "Jordi ",
        "Stef ",
        "Jan ",
        "Mounim ",
        "Merry ",
        "Marijn ",
        "Jeroen ",
        "Martin ",
        "Hodor ",
        "Max ",
        "July ",
        "Gerda ",
        "Ingrid ",
        "Shaneequa ",
        "Uniqua ",
        "Shanaynay ",
        "Ledasha ",
        "Diamond ",
        "Ruby ",
        "Saphire ",
        "Mercedes "
    };

    
    public string[] lname =
    {
        "Abdul: ",
        "Ayylmao: ",
        "Pinky Pie: ",
        "Dildoking: ",
        "Assad: ",
        "Simpson: ",
        "Cunty: ",
        "Vaporwave: ",
        "Watson: ",
        "White: ",
        "Ketchum: ",
        "Dogson: ",
        "McKenzie: ",
        "Cupson: ",
        "Cuckold: ",
        "Flowerhoff: ",
        "de Vries: ",
        "de Koning: "
    };

    /*public string[] myPosts = new string[]
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
    };*/

    public string[] myHalfPosts = new string[]
    {
        "Wow check out this ",
        "I cannot believe ",
        "I watched a",
        "I'm walking my ",
        "Ugh, I have to make a",
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
        "Just fucked my "
    };

    public string[] mySecondHalfPosts = new string[]
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

    public string[] mySubjects = new string[]
    {
        "customer",
        "drama",
        "gender",
        "bleep",
        "rain",
        "stepson",
        "television",
        "toothbrush",
        "wasp",
        "activity",
        "aluminium",
        "bottle",
        "deodorant",
        "freeze",
        "South-America",
        "toy",
        "typhoon",
        "yodler",
        "white-supremacist",
        "hockysticks",
        "hammer",
        "white women",
        "crazy boy",
        "Keano",
        "lubed jellyjar",
        "coconut oil",
        "banana",
        "bradwurst",
        "microphone",
        "dildo",
        "Meatswipe",
        "Yodlbirdz",
        "banker",
        "Jeroen's baby",
        "South-African folk singers",
        "nature",
        "spikey apples",
        "My Little Pony hentai doushinji",
        "your moms buttabplog",
        "weird hentai written by O.J. Simpson",
        "Occulus Rift",
        "goats",
        "Pokemon",
        "Pickachu",
        "Global Game Jam 2016"
    };

    // Use this for initialization
    void Start () {
	
        GetComponentInChildren<Text>().text = fname[Random.Range(0, fname.Length)] + lname[Random.Range(0, lname.Length)] + myHalfPosts[Random.Range(0, myHalfPosts.Length)] + mySubjects[Random.Range(0, mySubjects.Length)] + mySecondHalfPosts[Random.Range(0, mySecondHalfPosts.Length)];

    }
    
    

    void checkForHit()
    {
        Ray ray = new Ray(new Vector3(fingerPlacement.x, fingerPlacement.y, 1), Vector3.back);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.gameObject == GetComponentInChildren<Collider>().gameObject)
                GetComponentInParent<ThumbsApp>().DeletePost(gameObject);
            
        }
        
    }

    void ChangeHeight()
    {
        GetComponent<RectTransform>().anchoredPosition = Vector3.Slerp(GetComponent<RectTransform>().anchoredPosition, Vector3.up * toHeight, 5 * Time.deltaTime);
    }



    new public void LateUpdate()
    {
        if (GetComponent<RectTransform>().position.y != toHeight)
            ChangeHeight();

        if (fingerActive && !lastTurnActiveState)
            checkForHit();

        lastTurnActiveState = fingerActive;


        base.LateUpdate();
    }
}
