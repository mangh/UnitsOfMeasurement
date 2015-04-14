﻿/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

using System.Collections;   // IEnumerable.GetEnumerator()
using System.Collections.Generic;

namespace Man.UnitsOfMeasurement
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ScaleType : MeasureType
    {
        #region Properties
        public UnitType Unit { get; private set; }
        public NumExpr Offset { get; set; }
        public string Format { get; set; }
        #endregion

        #region Constructor(s)
        public ScaleType(string name, UnitType unit) :
            base(MeasureType.DefaultNamespace, name)
        {
            Unit = unit;
        }
        #endregion
    }
}
