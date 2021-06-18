using UnityEngine;
using System.ComponentModel;

public static class UnityLogger {
    public static void LogObject(object obj) {
        var output = "";
        foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj)) {
            var name = descriptor.Name;
            var value = descriptor.GetValue(obj);
            output += $"{name}={value}\n";
        }
        Debug.Log(output);
    }
}