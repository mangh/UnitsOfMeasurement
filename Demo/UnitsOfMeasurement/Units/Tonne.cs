/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Tonne : IQuantity<double>, IEquatable<Tonne>, IComparable<Tonne>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Tonne(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Tonne(double q) { return new Tonne(q); }
        public static explicit operator Tonne(Gram q) { return new Tonne((Tonne.Factor / Gram.Factor) * q.Value); }
        public static explicit operator Tonne(Kilogram q) { return new Tonne((Tonne.Factor / Kilogram.Factor) * q.Value); }
        public static explicit operator Tonne(Pound q) { return new Tonne((Tonne.Factor / Pound.Factor) * q.Value); }
        public static explicit operator Tonne(Ounce q) { return new Tonne((Tonne.Factor / Ounce.Factor) * q.Value); }
        public static Tonne From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Tonne.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Tonne\"", q.GetType().Name));
            return new Tonne((Tonne.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Tonne>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Tonne) && Equals((Tonne)obj); }
        public bool /* IEquatable<Tonne> */ Equals(Tonne other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Tonne>
        public static bool operator ==(Tonne lhs, Tonne rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Tonne lhs, Tonne rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Tonne lhs, Tonne rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Tonne lhs, Tonne rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Tonne lhs, Tonne rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Tonne lhs, Tonne rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Tonne> */ CompareTo(Tonne other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Tonne operator +(Tonne lhs, Tonne rhs) { return new Tonne(lhs.Value + rhs.Value); }
        public static Tonne operator -(Tonne lhs, Tonne rhs) { return new Tonne(lhs.Value - rhs.Value); }
        public static Tonne operator ++(Tonne q) { return new Tonne(q.Value + 1d); }
        public static Tonne operator --(Tonne q) { return new Tonne(q.Value - 1d); }
        public static Tonne operator -(Tonne q) { return new Tonne(-q.Value); }
        public static Tonne operator *(double lhs, Tonne rhs) { return new Tonne(lhs * rhs.Value); }
        public static Tonne operator *(Tonne lhs, double rhs) { return new Tonne(lhs.Value * rhs); }
        public static Tonne operator /(Tonne lhs, double rhs) { return new Tonne(lhs.Value / rhs); }
        public static double operator /(Tonne lhs, Tonne rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Tonne.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Tonne.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Tonne.Format, Value, Tonne.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Kilogram.Sense;
        private static readonly int s_family = Kilogram.Family;
        private static double s_factor = Kilogram.Factor / 1000d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("t");

        private static readonly Tonne s_one = new Tonne(1d);
        private static readonly Tonne s_zero = new Tonne(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Tonne One { get { return s_one; } }
        public static Tonne Zero { get { return s_zero; } }
        #endregion
    }
}
