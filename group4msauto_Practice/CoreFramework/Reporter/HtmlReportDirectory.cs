using CoreFramework.Utilities;

namespace CoreFramework.Reporter;
public class HtmlReportDirectory
{
    public static string REPORT_ROOT { get; set;}
    public static string REPORT_FOLDER_PATH { get; set; }
    public static string REPORT_FILE_PATH { get; set; }
    public static string SCREENSHOT_PATH { get; set; }

    public static string ACTUAL_SCREENSHOT_PATH { get; set; }
    public static string DIFFERENCE_SCREENSHOT_PATH { get; set; }
    public static string BASELINE_SCREENSHOT_PATH { get; set; }

    public static void InitReportDirection()
    {
        string projectPath = FilePaths.GetCurrentDirectoryPath();
        REPORT_ROOT = projectPath + "\\reports";
        REPORT_FOLDER_PATH = REPORT_ROOT + "\\latest reports";
        REPORT_FILE_PATH = REPORT_FOLDER_PATH + "\\report.html";
        SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\screenshot";
        ACTUAL_SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\actual";
        DIFFERENCE_SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\difference";
        BASELINE_SCREENSHOT_PATH = FilePaths.GetCurrentDirectoryPath() + "\\resource\\baseline";

        FilePaths.CreateIfNotExists(REPORT_ROOT);
        CheckExistReportAndRename(REPORT_FOLDER_PATH); // Check if latest report exists
        FilePaths.CreateIfNotExists(REPORT_FOLDER_PATH);
        FilePaths.CreateIfNotExists(SCREENSHOT_PATH);
        FilePaths.CreateIfNotExists(ACTUAL_SCREENSHOT_PATH);
        FilePaths.CreateIfNotExists(DIFFERENCE_SCREENSHOT_PATH);
        FilePaths.CreateIfNotExists(BASELINE_SCREENSHOT_PATH);
    }
    private static void CheckExistReportAndRename(string reportFolder)
    {
        if (Directory.Exists(reportFolder))
        {
            DirectoryInfo dirInfo = new DirectoryInfo(reportFolder);
            var newPath = REPORT_ROOT + "\\report_" + dirInfo.CreationTime.
                ToString().Replace(":", ".").Replace("/", "-");
            Directory.Move(reportFolder, newPath);
        }
    }
}

