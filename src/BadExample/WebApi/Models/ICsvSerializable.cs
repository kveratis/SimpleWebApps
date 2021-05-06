﻿using System.Reflection;

namespace WebApi.Models {
    public interface ICsvSerializable {
        string[] GetCsvPropertyNames();
        string ToCsv();
    }
}