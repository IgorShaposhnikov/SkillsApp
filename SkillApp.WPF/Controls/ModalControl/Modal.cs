using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SkillApp.WPF.Controls
{
    [TemplatePart(Name = "PART_BackgroundLayer", Type = typeof(Grid))]
    [TemplatePart(Name = "PART_ContentContainer", Type = typeof(Border))]
    [TemplatePart(Name = "PART_Content", Type = typeof(ContentPresenter))]
    public class Modal : ContentControl
    {
        private Grid _partBackgroundLayer;
        private Border _partContentContainer;
        private ContentPresenter _partContent;


        #region Properties


        public static readonly DependencyProperty IsOpenProperty 
            = DependencyProperty.Register("IsOpen", typeof(bool), typeof(Modal), new PropertyMetadata(false, OnIsOpenChanged));

        public static readonly DependencyProperty BackgroundOpacityProperty
            = DependencyProperty.Register("BackgroundOpacity", typeof(double), typeof(Modal), new FrameworkPropertyMetadata(0.7));

        public static readonly DependencyProperty WindowWidthProperty
            = DependencyProperty.Register("WindowWidth", typeof(double), typeof(Modal), new FrameworkPropertyMetadata(0.7));

        public static readonly DependencyProperty WindowHeightProperty
            = DependencyProperty.Register("WindowHeight", typeof(double), typeof(Modal), new FrameworkPropertyMetadata(0.7));

        public static readonly DependencyProperty IsAnimationEnableProperty
            = DependencyProperty.Register("IsAnimationEnableProperty", typeof(bool), typeof(Modal), new PropertyMetadata(true));

        //public static readonly DependencyProperty AnimationInTimeProperty 
        //    = DependencyProperty.Register("AnimationInTimePropertry", typeof(ff))

        public bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }

        public double BackgroundOpacity
        {
            get => (double)GetValue(BackgroundOpacityProperty);
            set => SetValue(BackgroundOpacityProperty, value);
        }

        public double WindowWidth
        {
            get => (double)GetValue(WindowWidthProperty);
            set => SetValue(WindowWidthProperty, value);
        }

        public double WindowHeight
        {
            get => (double)GetValue(WindowHeightProperty);
            set => SetValue(WindowWidthProperty, value);
        }

        public bool IsAnimationEnable 
        {
            get => (bool)GetValue(IsAnimationEnableProperty);
            set => SetValue(IsAnimationEnableProperty, value);
        }


        #endregion Properties


        #region Constructors


        static Modal()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Modal), new FrameworkPropertyMetadata(typeof(Modal)));
        }


        #endregion Constructors


        #region Public & Protected Methods


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _partBackgroundLayer = GetTemplateChild("PART_BackgroundLayer") as Grid;
            _partContentContainer = GetTemplateChild("PART_ContentContainer") as Border;
            _partContent = GetTemplateChild("PART_Content") as ContentPresenter;

            _partBackgroundLayer.Visibility = Visibility.Collapsed;

            if (_partBackgroundLayer == null || _partContent == null || _partContentContainer == null)
            {
                throw new NullReferenceException("Template parts not available");
            }
        }


        #endregion Public & Protected Methods


        #region Private Methods


        public void Close() 
        {
            _partBackgroundLayer.Visibility = Visibility.Collapsed;
        }

        public void Open() 
        {
            _partBackgroundLayer.Visibility = Visibility.Visible;
        }

        private void ShowModalAnimation()
        {
            _partBackgroundLayer.Opacity = 0.0;
            _partBackgroundLayer.Visibility = Visibility.Visible;

            DoubleAnimation doubleAnimation = new DoubleAnimation()
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(0.2)
            };
            _partBackgroundLayer.BeginAnimation(FrameworkElement.OpacityProperty, doubleAnimation);
        }

        private void CloseModalAnimation()
        {
            _partBackgroundLayer.Visibility = Visibility.Visible;
            var doubleAnimation = new DoubleAnimation()
            {
                From = 1.0,
                To = 0.0,
                Duration = TimeSpan.FromSeconds(0.2)
            };

            doubleAnimation.Completed += (object sender, EventArgs e) =>
            {
                _partBackgroundLayer.Visibility = Visibility.Collapsed;
            };

            _partBackgroundLayer.BeginAnimation(FrameworkElement.OpacityProperty, doubleAnimation);
        }

        private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dObj = (Modal)d;

            var newValue = (bool)e.NewValue;
            if (dObj.IsAnimationEnable)
            {
                if (newValue)
                {
                    dObj.ShowModalAnimation();
                }
                else
                {
                    dObj.CloseModalAnimation();
                }
            }
            else 
            {
                if (newValue)
                {
                    dObj.Open();
                }
                else 
                {
                    dObj.Close();
                }
            }
        }


        #endregion Private Methods
    }
}