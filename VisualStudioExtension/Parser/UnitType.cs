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
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class UnitType : MeasureType
    {
        #region Properties
        public SenseExpr Sense { get; set; }
        public int Family { get; set; }
        public NumExpr Factor { get; set; }
        public string Format { get; set; }
        public List<string> Tags { get; private set; }
        // Binary operations, returning values of another (outer) type
        public List<BinaryOperation> OuterOperations { get; private set; }
        #endregion

        #region Constructor(s)
        public UnitType(string name) :
            base(MeasureType.DefaultNamespace, name)
        {
            Tags = new List<string>();
            OuterOperations = new List<BinaryOperation>();
            Family = s_family++;    // Initially, assign to the next family
        }
        #endregion

        #region Methods
        public void AddRelative(UnitType relative)
        {
            base.AddRelative(relative);
            relative.Family = this.Family;
        }
        public void AddOuterOperation(AbstractType ret, string op, AbstractType lhs, AbstractType rhs)
        {
            OuterOperations.Add(new BinaryOperation(ret, op, lhs, rhs));
        }
        #endregion

        #region Statics
        private static int s_family = 0;
        public static void ResetFamilyID()
        {
            s_family = 0;
        }
        #endregion
    }
}
