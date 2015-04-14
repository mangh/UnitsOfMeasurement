﻿/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;
using System.Collections.Generic;

namespace Man.UnitsOfMeasurement
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class Parser
    {
        #region Fields
        private Lexer m_lexer;
        private Lexer.Symbol m_symbol;
        private List<UnitType> m_units;
        private List<ScaleType> m_scales;
        private SenseEncoderCS m_senseEncoder;
        private NumExprEncoderCS m_exprEncoder;
        #endregion

        #region Properties
        #endregion

        #region Constructor(s)
        public Parser(Lexer lexer, List<UnitType> units, List<ScaleType> scales)
        {
            m_lexer = lexer;
            m_units = units;
            m_scales = scales;
            m_senseEncoder = new SenseEncoderCS();
            m_exprEncoder = new NumExprEncoderCS();

            GetToken();
        }
        #endregion

        #region Methods
        // <UnitsOfMeasure> ::=  <UnitsOfMeasure> <Entity> | <Entity>
        // <Entity> ::= <Unit> | <Scale>
        // <Unit> ::= 'unit'<ValueType> Identifier <Tags> <Format> '=' <Dim Expr> ';'
        // <Scale> ::= 'scale' Identifier <Format> Identifier '=' Identifier <Num Expr> ';'
        public void Parse()
        {
            UnitType.ResetFamilyID();

            string badTokenFormat = "\"{0}\": expecting \"unit\" or \"scale\" keyword (or a comment)";

            while (m_symbol != Lexer.Symbol.EOF)
            {
                string token = m_lexer.TokenText;

                if (m_symbol != Lexer.Symbol.Identifier)
                    Note(badTokenFormat, token);
                else if (token == "unit")
                    { GetToken(); ParseUnit();}
                else if (token == "scale")
                    { GetToken(); ParseScale(); }
                else
                    Note(badTokenFormat, token);

                Synchronize();
            }
        }

        private Lexer.Symbol GetToken()
        {
            return (m_symbol = m_lexer.GetToken());
        }

        private void CheckSemicolon()
        {
            if (m_symbol != Lexer.Symbol.Semicolon) Note("\"{0}\": expected semicolon \";\"", m_lexer.TokenText);
        }

        private UnitType FindUnit(string name) { return m_units.Find(u => u.Name == name); }
        private ScaleType FindScale(string name) { return m_scales.Find(s => s.Name == name); }
        private bool IsUniqueName(string name) { return (FindUnit(name) == null) && (FindScale(name) == null); }

        private void Synchronize()
        {
            while (m_symbol != Lexer.Symbol.EOF)
            {
                if (m_symbol == Lexer.Symbol.Semicolon) { GetToken(); return; }
                if (m_symbol == Lexer.Symbol.Identifier)
                {
                    string token = m_lexer.TokenText;
                    if ((token == "unit") || (token == "scale")) return;
                }
                GetToken();
            }
        }

        private void Note(string info)
        {
            m_lexer.Note(info);
        }
        public void Note(string format, params object[] info)
        {
            m_lexer.Note(format, info);
        }
        #endregion
    }
}
