﻿using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public class ExcelScriptableObjectClassGenerater : IExcelClassGenerater
{
    public void GenerateClass(string savePath, string className, ExcelGameData data)
    {
        if (!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);

        string fileName = className + ExcelExporterUtil.ClientClassExt;
        List<string> types = data.fieldTypeList;
        List<string> fields = data.fieldNameList;

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("using System;");
        sb.AppendLine("using System.Collections.Generic;");
        sb.AppendLine("using UnityEngine;");
        sb.AppendLine();

        sb.AppendLine("namespace Config.ScriptableConfig");
        sb.AppendLine("{");
        sb.AppendLine("\tpublic class " + className + ": ScriptableObject");
        sb.AppendLine("\t{");
        for (int i = 0; i < types.Count; i++)
        {
            if (Regex.IsMatch(types[i], @"^[a-zA-Z_0-9><,]*$") && Regex.IsMatch(fields[i], @"^[a-zA-Z_0-9]*$"))
                sb.AppendLine(string.Format("\t\tpublic {0} {1};", types[i], fields[i]));
        }
        sb.AppendLine("\t}");
        sb.AppendLine("}");

        //File.WriteAllText(savePath + fileName, sb.ToString());
    }
}