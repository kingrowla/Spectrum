﻿using Xamarin.Forms;

namespace TestAppCC.Effects
{
    public class VisualFeedbackEffect : RoutingEffect
    {
        public VisualFeedbackEffect() : base($"Effects.{nameof(VisualFeedbackEffect)}")
        {
        }

        public static readonly BindableProperty FeedbackColorProperty = BindableProperty.CreateAttached("FeedbackColor", typeof(Color), typeof(VisualFeedbackEffect), Color.Default);

        public static Color GetFeedbackColor(BindableObject view) => (Color)view.GetValue(FeedbackColorProperty);

        public static void SetFeedbackColor(BindableObject view, Color value) => view.SetValue(FeedbackColorProperty, value);

        public static bool IsFeedbackColorSet(BindableObject element) => GetFeedbackColor(element) != Color.Default;
    }
}

