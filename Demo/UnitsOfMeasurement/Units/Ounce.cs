/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Ounce : IQuantity<double>, IEquatable<Ounce>, IComparable<Ounce>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Ounce(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Ounce(double q) { return new Ounce(q); }
        public static explicit operator Ounce(Tonne q) { return new Ounce((Ounce.Factor / Tonne.Factor) * q.Value); }
        public static explicit operator Ounce(Gram q) { return new Ounce((Ounce.Factor / Gram.Factor) * q.Value); }
        public static explicit operator Ounce(Kilogram q) { return new Ounce((Ounce.Factor / Kilogram.Factor) * q.Value); }
        public static explicit operator Ounce(Pound q) { return new Ounce((Ounce.Factor / Pound.Factor) * q.Value); }
        public static Ounce From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Ounce.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Ounce\"", q.GetType().Name));
            return new Ounce((Ounce.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Ounce>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Ounce) && Equals((Ounce)obj); }
        public bool /* IEquatable<Ounce> */ Equals(Ounce other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Ounce>
        public static bool operator ==(Ounce lhs, Ounce rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Ounce lhs, Ounce rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Ounce lhs, Ounce rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Ounce lhs, Ounce rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Ounce lhs, Ounce rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Ounce lhs, Ounce rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Ounce> */ CompareTo(Ounce other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Ounce operator +(Ounce lhs, Ounce rhs) { return new Ounce(lhs.Value + rhs.Value); }
        public static Ounce operator -(Ounce lhs, Ounce rhs) { return new Ounce(lhs.Value - rhs.Value); }
        public static Ounce operator ++(Ounce q) { return new Ounce(q.Value + 1d); }
        public static Ounce operator --(Ounce q) { return new Ounce(q.Value - 1d); }
        public static Ounce operator -(Ounce q) { return new Ounce(-q.Value); }
        public static Ounce operator *(double lhs, Ounce rhs) { return new Ounce(lhs * rhs.Value); }
        public static Ounce operator *(Ounce lhs, double rhs) { return new Ounce(lhs.Value * rhs); }
        public static Ounce operator /(Ounce lhs, double rhs) { return new Ounce(lhs.Value / rhs); }
        public static double operator /(Ounce lhs, Ounce rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Ounce.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Ounce.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Ounce.Format, Value, Ounce.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Pound.Sense;
        private static readonly int s_family = Kilogram.Family;
        private static double s_factor = Pound.Factor * 16d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("ou");

        private static readonly Ounce s_one = new Ounce(1d);
        private static readonly Ounce s_zero = new Ounce(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Ounce One { get { return s_one; } }
        public static Ounce Zero { get { return s_zero; } }
        #endregion
    }
}
