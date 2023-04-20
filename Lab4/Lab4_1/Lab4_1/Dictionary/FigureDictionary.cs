namespace Lab4_1.Dictionary;

public static class FigureDictionary
{
    public static readonly uint
        //TODO: разделить на default_line_color & default_fill_color
        DEFAULT_COLOR = 0,
        BLACK_COLOR = 0,
        WHITE_COLOR = 16777215,
        DEFAULT_FILL_COLOR = 16777215,
        COLOR_TRANSPARENT = 0;

    public static readonly string
        LINE = "line",
        CIRCLE = "circle",
        TRIANGLE = "triangle",
        RECTANGLE = "rectangle";

    public static readonly string
        REPLACE = "REPLACE",
        INVALID_ARGUMENT_COUNT_ALERT = "Error! invalid argument count.",
        ERROR_TO_CONVERT_STRING_TO_DOUBLE = "Error convert string to double value!",
        ERROR_TO_CONVERT_STRING_TO_FIGURE_TYPE = "Value is not valid to convert to figure type",
        ERROR_TO_CONVERT_STRING_TO_COLOR = "Value is not valid to convert to figure color",
        FIGURE_WITH_MIN_PERIMETER = "Figure with minimal perimeter : ",
        FIGURE_WITH_MAX_AREA = "Figure with max area : ";
}