namespace Lab2_3.Dictionary;

public static class MessageDictionary
{
    public static readonly string
        CLOSE_COMMAND = "...",
        ACCEPT_SAVE_DICTIONARY_CHAR = "Y",
        ACCEPT_SAVE_DICTIONARY_CHAR_LOWER = "y",
        FILE_NOT_FOUND_ALERT = "File not found!",
        SAVE_FILE_REQUEST = "Dictionary has been changed , input 'Y' or 'y' for save changes",
        SAVE_NEW_FILE_REQUEST = "File name is not entered, please input file name",
        INITIALIZE_DICTIONARY_REQUEST = "Input file name for open file, or input empty string for create a new dictionary",
        CREATE_NEW_DICTIONARY_ALERT = "File name has hot been input! Dictionary create in program memory";

    private static readonly string
        REPLACE = "REPLACE",
        TRANSLATED_WORD_NOT_FOUND_ALERT =
            "Translate for this word - REPLACE not found. Input translated word for add to dictionary or empty string for cancel",
        IGNORE_TRANSLATE_WORD_ALERT = "Word REPLACE ignored",
        ADD_TO_LIBRARY_ALERT = "Word - REPLACE added for a dictionary";
        

    public static string GetTranslateNotFoundMessage(string word)
    {
        return ReplaceTemplateWord(TRANSLATED_WORD_NOT_FOUND_ALERT, word);
    }

    public static string GetDeclineToAddWordToDictionaryMessage(string word)
    {
        return ReplaceTemplateWord(IGNORE_TRANSLATE_WORD_ALERT, word);
    }

    public static string GetWordAddToLibraryMessage(string word)
    {
        return ReplaceTemplateWord(ADD_TO_LIBRARY_ALERT, word);
    }

    private static string ReplaceTemplateWord(string message, string wordToReplace)
    {
        return message.Replace(REPLACE, wordToReplace);
    }
}