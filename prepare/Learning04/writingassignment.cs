using System;

public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // _studentName is accessible here because it's "protected" in
        // Assignment, not "private" — that's the whole reason this
        // assignment asks you to make that choice.
        return $"{_title} by {_studentName}";
    }
}