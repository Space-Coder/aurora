using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NetCoreWpf
{
    class Animation
    {
        private static FrameworkElement _element;
        private static bool _isFadeAnim = false;
        private static ExponentialEase expEase = new ExponentialEase() { EasingMode = EasingMode.EaseInOut };

        public static void SlideAnimation(FrameworkElement animObj, Thickness from, Thickness to, double time)
        {
            ThicknessAnimation anim = new ThicknessAnimation()
            {
                From = from,
                To = to,
                Duration = new Duration(TimeSpan.FromSeconds(time)),
                EasingFunction = expEase
            };
            animObj.BeginAnimation(FrameworkElement.MarginProperty, anim);
            
        }

        public static void OpacityAnimation(FrameworkElement animObj, bool isFadeAnim, double time)
        {
            _element = animObj;
            _isFadeAnim = isFadeAnim;
            DoubleAnimation anim = new DoubleAnimation();
            anim.From = isFadeAnim == true ? 1 : 0;
            anim.To = isFadeAnim == true ? 0 : 1;
            anim.Duration = new Duration(TimeSpan.FromSeconds(time));
            anim.Completed += Anim_Completed;
            if (_isFadeAnim == false)
                animObj.Visibility = Visibility.Visible;
            animObj.BeginAnimation(FrameworkElement.OpacityProperty, anim);
        }

        private static void Anim_Completed(object sender, EventArgs e)
        {
            if (_isFadeAnim == true)
            {
                _element.Visibility = Visibility.Collapsed;
            }           
        }
    }
}
