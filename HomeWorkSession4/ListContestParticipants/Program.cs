using ListContestParticipants;

List<Participants> participantList = new List<Participants>();

participantList.Add(new Participants { ParticipantName = "Adrian", ParticipantNumber = 1, ParticipantScore = 8 });
participantList.Add(new Participants { ParticipantName = "John", ParticipantNumber = 3, ParticipantScore = 7 });
participantList.Add(new Participants { ParticipantName = "Andrew", ParticipantNumber = 5, ParticipantScore = 6 });
participantList.Add(new Participants { ParticipantName = "Mikw", ParticipantNumber = 7, ParticipantScore = 7 });
participantList.Add(new Participants { ParticipantName = "Anakin", ParticipantNumber = 9, ParticipantScore = 9 });
participantList.Add(new Participants { ParticipantName = "Lambert", ParticipantNumber = 10, ParticipantScore = 10 });

//1. Add a new participant with score to the end of the list.

participantList.Insert(participantList.Count, new Participants { ParticipantName = "George", ParticipantNumber = 4, ParticipantScore = 9 });

//2.Add a new participant with score to a position given in the list.

participantList.Insert(0, new Participants { ParticipantName = "Gambit", ParticipantNumber = 6, ParticipantScore = 5 });

//3. Delete a participant from a given position.

participantList.RemoveAt(0);

//4. Modify the score of a participant by identification number.

foreach (Participants participant in participantList)
{
    if (participant.ParticipantNumber == 1)
    {
        participant.ParticipantScore = 10;
    }

    Console.WriteLine("Participant: {0}, {1}, {2}", participant.ParticipantName, participant.ParticipantNumber, participant.ParticipantScore);
}

//5. Print all participants that have a score less that a given score.

Console.WriteLine("============Score less than 8============");

foreach (Participants participant in participantList)
{
    if (participant.ParticipantScore < 8)
    {
        Console.WriteLine("Participant: {0}, {1}, {2}", participant.ParticipantName, participant.ParticipantNumber, participant.ParticipantScore);
    }
}

//6. Print all the participants in ascending order by score.

Console.WriteLine("==========Score Sorting============");

participantList.Sort(delegate(Participants x, Participants y)
{
    return x.ParticipantScore.CompareTo(y.ParticipantScore);
});
foreach (Participants participant in participantList)
{
    Console.WriteLine(String.Join(Environment.NewLine, "Participant: ", participant.ParticipantName, participant.ParticipantScore));
}

// 7. Print all the participants with a score bigger than a given score in ascending order by score.

Console.WriteLine("============Score bigger than given score============");

List<Participants> participantsList = participantList.FindAll(participant => participant.ParticipantScore > 4);

foreach(Participants participant in participantsList)
{
    Console.WriteLine("Participant name: {0}, Participant Score: {1}", participant.ParticipantName, participant.ParticipantScore);
}

// 8. Calculate the arithmetic mean of the scores for a given interval( for example - the function receives 2 and 6, calculate the arithmetic mean of scores for participants from the list with the positions 2,3,4,5 and 6).

Console.WriteLine("==========Arithmetic============");

int sum = 0;
int counter = 0;

for (int  i = 2; i < 6; i++)
{
    sum += participantsList[i].ParticipantScore;
    counter++;
}

double mean = (double) sum / counter;

Console.WriteLine("The Score's Sum: {0}, The Score's Counter: {1}, The Score's Mean: {2}", sum, counter, mean);
