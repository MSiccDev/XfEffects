using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace XfEffects.Effects
{
    public static class ImageButtonTintEffectExtensions
    {
        public static readonly BindableProperty TintColorProperty = BindableProperty.CreateAttached("TintColor", typeof(Color), typeof(ImageButtonTintEffectExtensions), default, propertyChanged: OnTintColorPropertyChanged);

        public static Color GetTintColor(BindableObject bindable)
        {
            return (Color)bindable.GetValue(TintColorProperty);
        }

        public static void SetTintColor(BindableObject bindable, Color value)
        {
            bindable.SetValue(TintColorProperty, value);
        }

        private static void OnTintColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ImageButton current)
            {
                if ((Color)newValue != default)
                {
                    if (!current.Effects.Any(e => e is ImageButtonTintEffect))
                        current.Effects.Add(Effect.Resolve(nameof(ImageButtonTintEffect)));
                }
                else
                {
                    if (current.Effects.Any(e => e is ImageButtonTintEffect))
                    {
                        var existingEffect = current.Effects.FirstOrDefault(e => e is ImageButtonTintEffect);
                        current.Effects.Remove(existingEffect);
                    }
                }
            }
        }
    }





    public class ImageButtonTintEffect : RoutingEffect
    {
        public ImageButtonTintEffect() : base($"XfEffects.{nameof(ImageButtonTintEffect)}")
        {
        }
    }
}
