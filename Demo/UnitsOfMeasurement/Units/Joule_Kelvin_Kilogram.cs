/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Joule_Kelvin_Kilogram : IQuantity<double>, IEquatable<Joule_Kelvin_Kilogram>, IComparable<Joule_Kelvin_Kilogram>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Joule_Kelvin_Kilogram(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Joule_Kelvin_Kilogram(double q) { return new Joule_Kelvin_Kilogram(q); }
        public static Joule_Kelvin_Kilogram From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Joule_Kelvin_Kilogram.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Joule_Kelvin_Kilogram\"", q.GetType().Name));
            return new Joule_Kelvin_Kilogram((Joule_Kelvin_Kilogram.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Joule_Kelvin_Kilogram>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Joule_Kelvin_Kilogram) && Equals((Joule_Kelvin_Kilogram)obj); }
        public bool /* IEquatable<Joule_Kelvin_Kilogram> */ Equals(Joule_Kelvin_Kilogram other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Joule_Kelvin_Kilogram>
        public static bool operator ==(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Joule_Kelvin_Kilogram> */ CompareTo(Joule_Kelvin_Kilogram other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Joule_Kelvin_Kilogram operator +(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return new Joule_Kelvin_Kilogram(lhs.Value + rhs.Value); }
        public static Joule_Kelvin_Kilogram operator -(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return new Joule_Kelvin_Kilogram(lhs.Value - rhs.Value); }
        public static Joule_Kelvin_Kilogram operator ++(Joule_Kelvin_Kilogram q) { return new Joule_Kelvin_Kilogram(q.Value + 1d); }
        public static Joule_Kelvin_Kilogram operator --(Joule_Kelvin_Kilogram q) { return new Joule_Kelvin_Kilogram(q.Value - 1d); }
        public static Joule_Kelvin_Kilogram operator -(Joule_Kelvin_Kilogram q) { return new Joule_Kelvin_Kilogram(-q.Value); }
        public static Joule_Kelvin_Kilogram operator *(double lhs, Joule_Kelvin_Kilogram rhs) { return new Joule_Kelvin_Kilogram(lhs * rhs.Value); }
        public static Joule_Kelvin_Kilogram operator *(Joule_Kelvin_Kilogram lhs, double rhs) { return new Joule_Kelvin_Kilogram(lhs.Value * rhs); }
        public static Joule_Kelvin_Kilogram operator /(Joule_Kelvin_Kilogram lhs, double rhs) { return new Joule_Kelvin_Kilogram(lhs.Value / rhs); }
        public static double operator /(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Joule_Kelvin operator *(Joule_Kelvin_Kilogram lhs, Kilogram rhs) { return new Joule_Kelvin(lhs.Value * rhs.Value); }
        public static Joule_Kelvin operator *(Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return new Joule_Kelvin(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Joule_Kelvin_Kilogram.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Joule_Kelvin_Kilogram.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Joule_Kelvin_Kilogram.Format, Value, Joule_Kelvin_Kilogram.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Joule_Kelvin.Sense / Kilogram.Sense;
        private static readonly int s_family = 20;
        private static double s_factor = Joule_Kelvin.Factor / Kilogram.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("J/kg/K");

        private static readonly Joule_Kelvin_Kilogram s_one = new Joule_Kelvin_Kilogram(1d);
        private static readonly Joule_Kelvin_Kilogram s_zero = new Joule_Kelvin_Kilogram(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Joule_Kelvin_Kilogram One { get { return s_one; } }
        public static Joule_Kelvin_Kilogram Zero { get { return s_zero; } }
        #endregion
    }
}
