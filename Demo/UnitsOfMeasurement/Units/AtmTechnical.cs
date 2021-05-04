/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct AtmTechnical : IQuantity<double>, IEquatable<AtmTechnical>, IComparable<AtmTechnical>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return AtmTechnical.Proxy; } }
        #endregion

        #region Constructor(s)
        public AtmTechnical(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator AtmTechnical(double q) { return new AtmTechnical(q); }
        public static explicit operator AtmTechnical(Bar q) { return new AtmTechnical((AtmTechnical.Factor / Bar.Factor) * q.m_value); }
        public static explicit operator AtmTechnical(Pascal q) { return new AtmTechnical((AtmTechnical.Factor / Pascal.Factor) * q.m_value); }
        public static explicit operator AtmTechnical(MillimeterHg q) { return new AtmTechnical((AtmTechnical.Factor / MillimeterHg.Factor) * q.m_value); }
        public static explicit operator AtmTechnical(AtmStandard q) { return new AtmTechnical((AtmTechnical.Factor / AtmStandard.Factor) * q.m_value); }
        public static AtmTechnical From(IQuantity<double> q)
        {
            if (q.Unit.Family != AtmTechnical.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"AtmTechnical\"", q.GetType().Name));
            }
            return new AtmTechnical((AtmTechnical.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<AtmTechnical>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is AtmTechnical) && Equals((AtmTechnical)obj); }
        public bool /* IEquatable<AtmTechnical> */ Equals(AtmTechnical other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<AtmTechnical>
        public static bool operator ==(AtmTechnical lhs, AtmTechnical rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(AtmTechnical lhs, AtmTechnical rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(AtmTechnical lhs, AtmTechnical rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(AtmTechnical lhs, AtmTechnical rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(AtmTechnical lhs, AtmTechnical rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(AtmTechnical lhs, AtmTechnical rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<AtmTechnical> */ CompareTo(AtmTechnical other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static AtmTechnical operator +(AtmTechnical lhs, AtmTechnical rhs) { return new AtmTechnical(lhs.m_value + rhs.m_value); }
        public static AtmTechnical operator -(AtmTechnical lhs, AtmTechnical rhs) { return new AtmTechnical(lhs.m_value - rhs.m_value); }
        public static AtmTechnical operator ++(AtmTechnical q) { return new AtmTechnical(q.m_value + 1d); }
        public static AtmTechnical operator --(AtmTechnical q) { return new AtmTechnical(q.m_value - 1d); }
        public static AtmTechnical operator -(AtmTechnical q) { return new AtmTechnical(-q.m_value); }
        public static AtmTechnical operator *(double lhs, AtmTechnical rhs) { return new AtmTechnical(lhs * rhs.m_value); }
        public static AtmTechnical operator *(AtmTechnical lhs, double rhs) { return new AtmTechnical(lhs.m_value * rhs); }
        public static AtmTechnical operator /(AtmTechnical lhs, double rhs) { return new AtmTechnical(lhs.m_value / rhs); }
        public static double operator /(AtmTechnical lhs, AtmTechnical rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? AtmTechnical.Format, q, AtmTechnical.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Pascal.Sense;
        public const int Family = Pascal.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("at");
        public static readonly Unit<double> Proxy = new AtmTechnical_Proxy();
        public const double Factor = Pascal.Factor / 98066.5d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly AtmTechnical One = new AtmTechnical(1d);
        public static readonly AtmTechnical Zero = new AtmTechnical(0d);
        #endregion
    }

    public partial class AtmTechnical_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return AtmTechnical.Sense; } }
        public override int Family { get { return AtmTechnical.Family; } }
        public override double Factor { get { return AtmTechnical.Factor; } }
        public override SymbolCollection Symbol { get { return AtmTechnical.Symbol; } }
        public override string Format { get { return AtmTechnical.Format; } set { AtmTechnical.Format = value; } }
        #endregion

        #region Constructor(s)
        public AtmTechnical_Proxy() :
            base(typeof(AtmTechnical))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new AtmTechnical(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return AtmTechnical.From(quantity);
        }
        #endregion
    }
}
