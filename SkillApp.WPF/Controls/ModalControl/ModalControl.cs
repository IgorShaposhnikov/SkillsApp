using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SkillApp.WPF.Controls
{
    public sealed class ModalControl : ContentControl
    {
        public static readonly DependencyProperty IsOpenProperty
            = DependencyProperty.Register("IsOpen", typeof(bool), typeof(ModalControl), new FrameworkPropertyMetadata(false));

        public static readonly DependencyProperty ContentWidthProperty
            = DependencyProperty.Register("ContentWidth", typeof(double), typeof(ModalControl), new FrameworkPropertyMetadata(500d));

        public static readonly DependencyProperty ContentHeightProperty
            = DependencyProperty.Register("ContentHeight", typeof(double), typeof(ModalControl), new FrameworkPropertyMetadata(600d));

        public static readonly DependencyProperty ContentBackgroundProperty
            = DependencyProperty.Register("ContentBackground", typeof(Brush), typeof(ModalControl), new FrameworkPropertyMetadata(Brushes.White));

        public static readonly DependencyProperty ContentPaddingProperty
            = DependencyProperty.Register("ContentPadding", typeof(Thickness), typeof(ModalControl), new FrameworkPropertyMetadata(new Thickness(16)));

        public static readonly DependencyProperty DimmingBackgroundProperty
            = DependencyProperty.Register("DimmingBackground", typeof(Color), typeof(ModalControl), new FrameworkPropertyMetadata(Colors.Black));

        public static readonly DependencyProperty DimmingOpacityProperty
            = DependencyProperty.Register("DimmingOpacity", typeof(double), typeof(ModalControl), new FrameworkPropertyMetadata(1.0d));

        public bool IsOpen 
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }

        public double ContentWidth 
        {
            get => (double)GetValue(ContentWidthProperty);
            set => SetValue(ContentWidthProperty, value);
        }

        public double ContentHeight
        {
            get => (double)GetValue(ContentHeightProperty);
            set => SetValue(ContentHeightProperty, value);
        }

        public Brush ContentBackground
        {
            get => (Brush)GetValue(ContentBackgroundProperty);
            set => SetValue(ContentBackgroundProperty, value);
        }

        public Thickness ContentPadding 
        {
            get => (Thickness)GetValue(ContentPaddingProperty);
            set => SetValue(ContentPaddingProperty, value);
        }

        public Color DimmingBackground 
        {
            get => (Color)GetValue(DimmingBackgroundProperty);
            set => SetValue(DimmingBackgroundProperty, value);
        }

        public double DimmingOpacity
        {
            get => (double)GetValue(DimmingOpacityProperty);
            set => SetValue(DimmingOpacityProperty, value);
        }


        #region Constructors

        
        static ModalControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModalControl), new FrameworkPropertyMetadata(typeof(ModalControl)));
        }


        #endregion Constructors


        private static void OnOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) 
        {

        }
    }
}
