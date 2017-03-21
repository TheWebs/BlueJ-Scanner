using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace Desenho
{
     class MyControl : FrameworkElement
    {
        public Color color = Colors.Green;
        public List<Cordenadas> linhas = new List<Cordenadas>();

        protected override void OnRender(DrawingContext dc)
        {
            SolidColorBrush brush = new SolidColorBrush();
            Rect rect = new Rect(0, 0, RenderSize.Width, RenderSize.Height);
                brush.Color = color;
                dc.DrawRectangle(brush, null, rect);
                rect.X += RenderSize.Width;
            
            dc.DrawEllipse(new SolidColorBrush(Colors.Blue), new Pen(), new Point(300, 300), 100, 100);
            foreach (Cordenadas linha in linhas)
            {
                dc.DrawLine(linha.pen, linha.x, linha.y);
            }
            dc.DrawText(new FormattedText("12", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 20, new SolidColorBrush(Colors.Yellow)), new Point(290, 200));
            linhas.Clear();
            
        }
    }
}