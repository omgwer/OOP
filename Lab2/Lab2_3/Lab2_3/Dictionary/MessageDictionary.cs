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
        INITIALIZE_DICTIONARY_REQUEST =
            "Input file name for open file, or input empty string for create a new dictionary",
        CREATE_NEW_DICTIONARY_ALERT = "File name has hot been input! Dictionary create in program memory",
        PARSE_FILE_ERROR_ONE_WORD_IN_LINE = "Word is dont have a translated word",
        CLOSE_PROGRAM_WITH_SAVE_MESSAGE = "Save file success. Library is closed",
        CLOSE_PROGRAM_WITHOUT_SAVE_MESSAGE = "Library is not saved. Library is closed",
        WORD_IS_EXIST_FOR_DICTIONARY_MESSAGE = "The Word is exits for this dictionary";

    private static readonly string
        REPLACE = "REPLACE",
        TRANSLATED_WORD_NOT_FOUND_ALERT =
            "Translate for this word - REPLACE not found. Input translated word for add to dictionary or empty string for cancel",
        IGNORE_TRANSLATE_WORD_ALERT = "Word REPLACE ignored",
        ADD_TO_LIBRARY_ALERT = "Word - REPLACE added for a dictionary",
        ERROR_ADD_TRANSLATE_FOR_RUSSIAN_WORD = "Error add translate to russian word! Word - REPLACE can`t been russian word.",
        ERROR_ADD_TRANSLATE_FOR_ENGLISH_WORD = "Error add translate to english word! Word - REPLACE can`t been russian word.";

    public static string GetAddTranslateForRussianWordErrorMessage(string word)
    {
        return ERROR_ADD_TRANSLATE_FOR_RUSSIAN_WORD.Replace(REPLACE, word);
    }

    public static string GetAddTranslateForEnglishWordErrorMessage(string word)
    {
        return ERROR_ADD_TRANSLATE_FOR_ENGLISH_WORD.Replace(REPLACE, word);
    }

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