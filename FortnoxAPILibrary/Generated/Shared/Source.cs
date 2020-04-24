using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum Source
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "manual")]
        Manual,
        ///<summary> No property description </summary>
        [EnumMember(Value = "direct")]
        Direct,
    }
}