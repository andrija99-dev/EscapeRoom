using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    public static HintManager Instance { get; private set; }

    public Dictionary<int, List<string>> roomHints = new Dictionary<int, List<string>>();
    public Dictionary<int, List<bool>> roomProgress = new Dictionary<int, List<bool>>();

    public Dictionary<int, int> clueCountPerRoom = new Dictionary<int, int>();

    private Dictionary<int, int> postClueHintIndex = new Dictionary<int, int>();

    private int currentRoom;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeHintsAndProgress();
    }

    void InitializeHintsAndProgress()
    {
        roomHints[1] = new List<string>
        {
            "Look around the room, you might find something useful.",
            "Maybe there’s something else you haven’t found yet.",
            "Have you checked what the rule in the room is?",
            "Maybe there’s something else you haven’t found yet.",
            "Maybe there’s only one important color to listen to?",
            "Why is that color flashing in that particular order?",
            "Can you link the color light order to the brothers' story?",
            "Each brother, from the first to the fourth, has a number assigned to him, right?",
            "The code is 8239."
        };
        clueCountPerRoom[1] = 4;

        roomHints[2] = new List<string>
        {   "Look around the room, you might find something useful.",
            "Look around the room, you might find something useful.",
            "Look around the room, you might find something useful.",
            "Look around the room, you might find something useful.",
            "Look around the room, you might find something useful.",
            "The symbols you read on the walls—do they hide something if you look a little closer?",
            "What if you look at the bottom left corner of the symbol — do you see a number there?",
            "Why are symbols placed in wall corners, and do they match the paper’s numbers?",
            "Comparing the wall corner number and paper sequence, what code appears?",
            "The code is 4725.",
        };
        clueCountPerRoom[2] = 5;

        roomHints[3] = new List<string>
        {   "Look around the room, you might find something useful.",
            "Why did the door stay open?",
            "Is there a name that can be formed from the letters you found?",
            "What code results from the name’s number order following the room’s rule?",
            "The code is 7108.",

        };
        clueCountPerRoom[3] = 1;

        foreach (var room in roomHints.Keys)
        {
            roomProgress[room] = new List<bool>(new bool[roomHints[room].Count]);
            postClueHintIndex[room] = clueCountPerRoom[room]; 
        }
    }

    public void MarkClueFound(int room, int clueIndex)
    {
        if (!roomProgress.ContainsKey(room)) return;
        if (clueIndex < 0 || clueIndex >= roomProgress[room].Count) return;

        roomProgress[room][clueIndex] = true;
    }

    public string GetCurrentHint()
    {
        currentRoom = InteractionManager.CurrentRoom;
        if(currentRoom > 3)
        {
            return "";
        }

        if (!roomHints.ContainsKey(currentRoom)) return null;
        if (!roomProgress.ContainsKey(currentRoom)) return null;

        var hints = roomHints[currentRoom];
        var progress = roomProgress[currentRoom];
        int clueCount = clueCountPerRoom[currentRoom];

        
        for (int i = 0; i < clueCount; i++)
        {
            if (!progress[i])
                return hints[i];
        }

        
        int index = postClueHintIndex[currentRoom];
        if (index < hints.Count - 1)
        {
            
            string hint = hints[index];
            postClueHintIndex[currentRoom] = Mathf.Min(index + 1, hints.Count - 1);
            return hint;
        }
        else
        {
            
            return hints[hints.Count - 1];
        }
    }

}