/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct PLN : IQuantity<decimal>, IEquatable<PLN>, IComparable<PLN>, IFormattable
    {
        #region Fields
        private readonly decimal m_value;
        #endregion

        #region Properties
        public decimal Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public PLN(decimal value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator PLN(decimal q) { return new PLN(q); }
        public static explicit operator PLN(GBP q) { return new PLN((PLN.Factor / GBP.Factor) * q.Value); }
        public static explicit operator PLN(USD q) { return new PLN((PLN.Factor / USD.Factor) * q.Value); }
        public static explicit operator PLN(EUR q) { return new PLN((PLN.Factor / EUR.Factor) * q.Value); }
        public static PLN From(IQuantity<decimal> q)
        {
            Unit<decimal> source = new Unit<decimal>(q);
            if (source.Family != PLN.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"PLN\"", q.GetType().Name));
            return new PLN((PLN.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<PLN>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is PLN) && Equals((PLN)obj); }
        public bool /* IEquatable<PLN> */ Equals(PLN other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<PLN>
        public static bool operator ==(PLN lhs, PLN rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(PLN lhs, PLN rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(PLN lhs, PLN rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(PLN lhs, PLN rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(PLN lhs, PLN rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(PLN lhs, PLN rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<PLN> */ CompareTo(PLN other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static PLN operator +(PLN lhs, PLN rhs) { return new PLN(lhs.Value + rhs.Value); }
        public static PLN operator -(PLN lhs, PLN rhs) { return new PLN(lhs.Value - rhs.Value); }
        public static PLN operator ++(PLN q) { return new PLN(q.Value + decimal.One); }
        public static PLN operator --(PLN q) { return new PLN(q.Value - decimal.One); }
        public static PLN operator -(PLN q) { return new PLN(-q.Value); }
        public static PLN operator *(decimal lhs, PLN rhs) { return new PLN(lhs * rhs.Value); }
        public static PLN operator *(PLN lhs, decimal rhs) { return new PLN(lhs.Value * rhs); }
        public static PLN operator /(PLN lhs, decimal rhs) { return new PLN(lhs.Value / rhs); }
        public static decimal operator /(PLN lhs, PLN rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(PLN.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(PLN.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? PLN.Format, Value, PLN.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = EUR.Sense;
        private static readonly int s_family = EUR.Family;
        private static decimal s_factor = 4.1437m * EUR.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("PLN");

        private static readonly PLN s_one = new PLN(decimal.One);
        private static readonly PLN s_zero = new PLN(decimal.Zero);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static decimal Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static PLN One { get { return s_one; } }
        public static PLN Zero { get { return s_zero; } }
        #endregion
    }
}
