using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class Helper
{
    public static void GetFiles(out string folderPath,
                          out IEnumerable<FileInfo> files,
                          string folderToLookIn,
                          string endsWith,
                          string dataFolder,
                          string dataFolderFolder = "")
    {
        string path = Path.Combine(dataFolder, dataFolderFolder);
        folderPath = Path.Combine(path, folderToLookIn);
        files = new DirectoryInfo(folderPath).GetFiles().Where(x => x.Name.EndsWith(endsWith));
    }
}