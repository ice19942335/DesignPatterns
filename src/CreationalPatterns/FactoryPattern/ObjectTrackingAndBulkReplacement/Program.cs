﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectTrackingAndBulkReplacement
{
    public interface ITheme
    {
        string TextColor { get; }
        
        string BgrColor { get; }
    }
    
    public class LightTheme : ITheme
    {
        public string TextColor => "black";

        public string BgrColor => "white";
    }
    
    public class DarkTheme : ITheme
    {
        public string TextColor => "white";

        public string BgrColor => "dark gray";
    }

    public class TrackingThemeFactory
    {
        private readonly List<WeakReference<ITheme>> _themes = new List<WeakReference<ITheme>>();
        
        public ITheme CreateTheme(bool dark)
        {
            ITheme theme = dark ? new DarkTheme() : new LightTheme();
            _themes.Add(new WeakReference<ITheme>(theme));
            return theme;
        }

        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var reference in _themes)
                {
                    if (reference.TryGetTarget(out var theme))
                    {
                        bool dark = theme is DarkTheme;
                        sb.Append(dark ? "Dark" : "Light")
                            .AppendLine(" theme");
                    }
                }

                return sb.ToString();
            }
        }
    }

    public class ReplaceableThemeFactory
    {
        private readonly List<WeakReference<Ref<ITheme>>> _themes = new List<WeakReference<Ref<ITheme>>>();

        private ITheme CreateThemeImpl(bool dark)
        {
            return dark ? new DarkTheme() : new LightTheme();
        }

        public Ref<ITheme> CreateTheme(bool dark)
        {
            var r = new Ref<ITheme>(CreateThemeImpl(dark));
            _themes.Add(new WeakReference<Ref<ITheme>>(r));
            return r;
        }

        public void ReplaceTheme(bool dark)
        {
            foreach (var wr in _themes)
            {
                if (wr.TryGetTarget(out var reference))
                {
                    reference.Value = CreateThemeImpl(dark);
                }
            }
        }
    }

    public class Ref<T> where T : class
    {
        public T Value;

        public Ref(T value)
        {
            Value = value;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new TrackingThemeFactory();
            var theme1 = factory.CreateTheme(false);
            var theme2 = factory.CreateTheme(true);
            
            Console.WriteLine(factory.Info);

            var factory2 = new ReplaceableThemeFactory();
            var magicTheme = factory2.CreateTheme(true);
            Console.WriteLine(magicTheme.Value.BgrColor);
            factory2.ReplaceTheme(false);
            Console.WriteLine(magicTheme.Value.BgrColor);
        }
    }
}