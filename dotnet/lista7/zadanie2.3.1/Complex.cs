using System;
using System.Globalization;

namespace zadanie2._3._1
{
    public class Complex : IFormattable
    {
        private double _real, _imag;

        public Complex()
        {
            _real = 0;
            _imag = 0;
        }

        public Complex(double real, double imaginary)
        {
            _real = real;
            _imag = imaginary;
        }

        public double Real
        {
            get => _real;
            set => _real = value;
        }

        public double Imag
        {
            get => _imag;
            set => _imag = value;
        }


        public static Complex operator +(Complex ca) => ca;
        public static Complex operator -(Complex ca) => new Complex(-ca.Real, -ca.Imag);

        public static Complex operator +(Complex ca, Complex cb)
            => new Complex(ca.Real + cb.Real, ca.Imag + cb.Imag);

        public static Complex operator -(Complex ca, Complex cb)
            => new Complex(ca.Real - cb.Real, ca.Imag - cb.Imag);

        public static Complex operator *(Complex ca, Complex cb)
        {
            var nreal = ca.Real * cb.Real - ca.Imag * cb.Imag;
            var nimag = ca.Real * cb.Imag + ca.Imag * cb.Real;
            return new Complex(nreal, nimag);
        }

        public static Complex operator /(Complex ca, Complex cb)
        {
            if (cb.Real.Equals(0.0) && cb.Imag.Equals(0.0))
            {
                throw new DivideByZeroException("nie można dzielić przez zerową liczbę zespoloną");
            }

            var realnum = ca.Real * cb.Real + ca.Imag * cb.Imag;
            var imagnum = ca.Imag * cb.Real - ca.Real * cb.Imag;
            var denom = cb.Real * cb.Real + cb.Imag * cb.Imag;
            return new Complex(realnum / denom, imagnum / denom);
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "d";
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToLowerInvariant())
            {
                case "w":
                    return "[" + _real.ToString("G", formatProvider) + ", "
                           + _real.ToString("G", formatProvider) + "]";
                default:
                    return _real.ToString("G", formatProvider) + " " + (_imag >= 0 ? "+" : "-") +
                           " " + Math.Abs(_imag).ToString("G", formatProvider) + "i";
            }
        }
    }
}