﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Adorners_in_WPF
{
    public class ResizeAdorner : Adorner
    {
        VisualCollection AdornerVisuals;
        Thumb thumb1, thumb2, thumb3, thumb4,centerThumb;
        Rectangle Rec;
       
        public ResizeAdorner(UIElement adornedElement) : base(adornedElement)
        {
      
            AdornerVisuals = new VisualCollection(this);
            thumb1 = new Thumb() { Background = Brushes.Coral, Height = 10, Width = 10 };
            thumb2 = new Thumb() { Background = Brushes.Coral, Height = 10, Width = 10 };
            thumb3 = new Thumb() { Background = Brushes.Coral, Height = 10, Width = 10 };
            thumb4 = new Thumb() { Background = Brushes.Coral, Height = 10, Width = 10 };
            centerThumb = new Thumb() { Background = Brushes.Coral, Height = 10, Width = 10 };
            Rec = new Rectangle() {Fill=Brushes.Transparent, Stroke = Brushes.Coral, StrokeThickness = 2, StrokeDashArray = { 3, 2 } };

            
            thumb1.DragDelta += Thumb1_DragDelta;
            thumb2.DragDelta += Thumb2_DragDelta;
            thumb3.DragDelta += Thumb3_DragDelta;
            thumb4.DragDelta += Thumb4_DragDelta;
            AdornerVisuals.Add(Rec);
            AdornerVisuals.Add(thumb1);
            AdornerVisuals.Add(thumb2);
            AdornerVisuals.Add(thumb3);
            AdornerVisuals.Add(thumb4);
            AdornerVisuals.Add(centerThumb);

        }

        private void Thumb3_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var ele = (FrameworkElement)AdornedElement;
            ele.Height = ele.Height + e.VerticalChange < 0 ? 0 : ele.Height + e.VerticalChange;

            ele.Width = ele.Width + e.HorizontalChange < 0 ? 0 : ele.Width + e.HorizontalChange;
        }

        private void Thumb4_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var ele = (FrameworkElement)AdornedElement;
            ele.Height = ele.Height + e.VerticalChange < 0 ? 0 : ele.Height + e.VerticalChange;

            ele.Width = ele.Width + e.HorizontalChange < 0 ? 0 : ele.Width + e.HorizontalChange;
        }

        private void Thumb2_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var ele = (FrameworkElement)AdornedElement;
            ele.Height = ele.Height + e.VerticalChange < 0 ? 0 : ele.Height + e.VerticalChange;

            ele.Width = ele.Width + e.HorizontalChange < 0 ? 0 : ele.Width + e.HorizontalChange;

        }

        private void Thumb1_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var ele = (FrameworkElement)AdornedElement;
            //ele.Height = ele.Height + e.VerticalChange < 0 ? 0 : ele.Height + e.VerticalChange;

            //ele.Width = ele.Width + e.HorizontalChange < 0 ? 0 : ele.Width + e.HorizontalChange;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            // base.OnMouseDown(e);

            AdornedElement.RaiseEvent(e);
        }


        protected override Visual GetVisualChild(int index)
        {
            return AdornerVisuals[index];
        }

        protected override int VisualChildrenCount => AdornerVisuals.Count;



        protected override Size ArrangeOverride(Size finalSize)
        {

            Rec.Arrange(new Rect(-2.5, -2.5, AdornedElement.DesiredSize.Width + 5, AdornedElement.DesiredSize.Height + 5));
            thumb1.Arrange(new Rect(-5, -5, 10, 10));
            thumb2.Arrange(new Rect(AdornedElement.DesiredSize.Width -5, AdornedElement.DesiredSize.Height-5, 10, 10));

            
            return base.ArrangeOverride(finalSize);
        }



    }
}
