using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class DefineDebugSymbolEditor
{
    private const string Symbol = "DEBUG_MODE_ON";

    [MenuItem("Tools / Add Debug Mode")]
    static void AddDebugSymbol()
    {

    }
    [MenuItem("Tools / Remove Debug Mode")]
    static void RemoveDebugSymbol()
    {
        ModifyDebugSymbol(Symbol, false);
    }
    //make function to add script define symbols

    static void ModifyDebugSymbol(string symbol, bool isEnabled)
    {
        BuildTargetGroup buildTargetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
        string currentDefines = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);

        string[] symbols = currentDefines.Split(';');

        if (isEnabled)
        {
            if (!symbols.Contains(symbol))
            {
                //string newDefines = string.Join(";", symbols.Where(s => !string.IsNullOrEmpty(s)).Append);
                //PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, newDefines);
                UnityEngine.Debug.Log($"Added Debug Symbols: {symbol}");
            }
            else
            {
                UnityEngine.Debug.Log($"{symbol} already exists");
            }
        }
        else {
            if (symbols.Contains(symbol))
            {
                string newDefines = string.Join(";", symbols.Where(s => s != symbol));
                PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, newDefines);
                UnityEngine.Debug.Log($"Added Debug Symbols: {symbol}");
            }
            else
            {
                UnityEngine.Debug.Log($"{symbol} already exists");
            }
        }
    }
}
