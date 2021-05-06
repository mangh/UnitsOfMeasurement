/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct Radian : IQuantity<double>, IEquatable<Radian>, IComparable<Radian>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Radian.Proxy; } }
        #endregion

        #region Constructor(s)
        public Radian(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Radian(double q) { return new Radian(q); }
        public static explicit operator Radian(Degree q) { return new Radian((Radian.Factor / Degree.Factor) * q.m_value); }
        public static Radian From(IQuantity<double> q)
        {
            if (q.Unit.Family != Radian.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Radian\"", q.GetType().Name));
            }
            return new Radian((Radian.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Radian>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Radian) && Equals((Radian)obj); }
        public bool /* IEquatable<Radian> */ Equals(Radian other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Radian>
        public static bool operator ==(Radian lhs, Radian rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Radian lhs, Radian rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Radian lhs, Radian rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Radian lhs, Radian rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Radian lhs, Radian rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Radian lhs, Radian rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Radian> */ CompareTo(Radian other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Radian operator +(Radian lhs, Radian rhs) { return new Radian(lhs.m_value + rhs.m_value); }
        public static Radian operator -(Radian lhs, Radian rhs) { return new Radian(lhs.m_value - rhs.m_value); }
        public static Radian operator ++(Radian q) { return new Radian(q.m_value + 1d); }
        public static Radian operator --(Radian q) { return new Radian(q.m_value - 1d); }
        public static Radian operator -(Radian q) { return new Radian(-q.m_value); }
        public static Radian operator *(double lhs, Radian rhs) { return new Radian(lhs * rhs.m_value); }
        public static Radian operator *(Radian lhs, double rhs) { return new Radian(lhs.m_value * rhs); }
        public static Radian operator /(Radian lhs, double rhs) { return new Radian(lhs.m_value / rhs); }
        public static double operator /(Radian lhs, Radian rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Radian.Format, q, Radian.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Dimension.None;
        public const int Family = 5;
        public static readonly SymbolCollection Symbol = new SymbolCollection("rad");
        public static readonly Unit<double> Proxy = new Radian_Proxy();
        public const double Factor = 1d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Radian One = new Radian(1d);
        public static readonly Radian Zero = new Radian(0d);
        #endregion
    }

    public partial class Radian_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Radian.Sense; } }
        public override int Family { get { return Radian.Family; } }
        public override double Factor { get { return Radian.Factor; } }
        public override SymbolCollection Symbol { get { return Radian.Symbol; } }
        public override string Format { get { return Radian.Format; } set { Radian.Format = value; } }
        #endregion

        #region Constructor(s)
        public Radian_Proxy() :
            base(typeof(Radian))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Radian(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Radian.From(quantity);
        }
        #endregion
    }
}
